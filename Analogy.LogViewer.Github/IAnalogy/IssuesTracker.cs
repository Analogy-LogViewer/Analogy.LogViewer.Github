using Analogy.Interfaces;
using Analogy.LogViewer.Github.DataTypes;
using Analogy.LogViewer.Github.Managers;
using Microsoft.Extensions.Logging;
using Octokit;
using System.Drawing;
using System.Threading;

namespace Analogy.LogViewer.Github.IAnalogy
{
    public class IssuesTracker : Template.OnlineDataProvider
    {
        public override Guid Id { get; set; } = new Guid("a6f0882d-c39a-4c38-9f9d-267d5d012db3");

        public override Image? ConnectedLargeImage { get; set; }
        public override Image? ConnectedSmallImage { get; set; }
        public override Image? DisconnectedLargeImage { get; set; }
        public override Image? DisconnectedSmallImage { get; set; }

        public override string? OptionalTitle { get; set; } = "Issues Tracker";
        public override Task<bool> CanStartReceiving() => Task.FromResult(true);
        public override IAnalogyOfflineDataProvider? FileOperationsHandler { get; set; }

        public override bool UseCustomColors { get; set; }
        public override IEnumerable<(string OriginalHeader, string ReplacementHeader)> GetReplacementHeaders()
            => new List<(string OriginalHeader, string ReplacementHeader)> { ("Module", "Comments"), ("User", "Id"), ("User", "Type"), ("Category", "URL") };

        public override (Color BackgroundColor, Color ForegroundColor) GetColorForMessage(IAnalogyLogMessage logMessage)
            => (Color.Empty, Color.Empty);
        public List<RepositorySettings> Repositories => UserSettingsManager.UserSettings.GithubSettings.Repositories;
        private UserSettingsManager Settings => UserSettingsManager.UserSettings;

        private Timer? fetcher;
        private GitHubClient? Client { get; set; }

        public IssuesTracker()
        {
        }

        public override Task StartReceiving()
        {
            Client = new GitHubClient(new ProductHeaderValue("Analogy.LogViewer.Github"));
            var tokenAuth = new Credentials(Settings.GithubSettings.GitHubToken);
            Client.Credentials = tokenAuth;
            fetcher = new Timer(Fetch, null, 1, Timeout.Infinite);
            return Task.CompletedTask;
        }

        public override Task StopReceiving()
        {
            fetcher?.Dispose();
            return Task.CompletedTask;
        }

        private async void Fetch(object? state)
        {
            foreach (RepositorySettings repo in Repositories)
            {
                try
                {
                    var  issues = await Client.Issue.GetAllForRepository(repo.Owner, repo.RepoName);
                    foreach (var entry in issues)
                    {
                        AnalogyLogMessage m = new AnalogyLogMessage
                        {
                            Text = $"{entry.Title}{Environment.NewLine}URL: {entry.HtmlUrl}{Environment.NewLine}Body: {entry.Body}{Environment.NewLine}",
                            Level = AnalogyLogLevel.Information,
                            Source = repo.DisplayName,
                            Date = entry.UpdatedAt?.DateTime ?? DateTime.MinValue,
                            FileName = entry.Url,
                            User = "Issue",
                            Module = $"Comments: {entry.Comments} ({entry.CommentsUrl})",
                        };
                        m.AddOrReplaceAdditionalProperty("Category", entry.HtmlUrl);

                        if (entry.Comments > 0)
                        {
                            var comments =await  Client.Issue.Comment.GetAllForIssue(repo.Owner, repo.RepoName, entry.Number);
                            if (comments.Any())
                            {
                                StringBuilder sb = new StringBuilder(Environment.NewLine + "### Comments:" +
                                                                     Environment.NewLine);
                                sb.Append("| User   |      Comment      |" + Environment.NewLine + "| ----------|:---------------| ");
                                foreach (var comment in comments)
                                {
                                    sb.Append($"{Environment.NewLine}|{comment.User.Name} ![image]({comment.User.AvatarUrl})|{comment.Body}.At: {comment.CreatedAt.DateTime}");
                                }

                                m.Text += Environment.NewLine + sb;
                            }
                        }

                        MessageReady(this, new AnalogyLogMessageArgs(m, repo.DisplayName, "Github", Id));
                    }
                }
                catch (Exception e)
                {
                    Template.Managers.LogManager.Instance.LogError(e, $@"Error reading {repo.DisplayName}: {e}",
                        nameof(StartReceiving));
                    AnalogyLogMessage m = new AnalogyLogMessage
                    {
                        Date = DateTime.Now,
                        Module = repo.DisplayName,
                        Text = $"Error: {e}",
                        Level = AnalogyLogLevel.Error,
                        Class = AnalogyLogClass.General,
                    };
                    MessageReady(this, new AnalogyLogMessageArgs(m, "", "", Id));
                }
            }
        }
        public override Task ShutDown() => Task.CompletedTask;
    }
}