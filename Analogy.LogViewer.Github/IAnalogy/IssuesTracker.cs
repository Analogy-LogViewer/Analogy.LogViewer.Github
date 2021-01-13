using Analogy.Interfaces;
using Analogy.LogViewer.Github.Data_Types;
using Analogy.LogViewer.Github.Managers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Analogy.LogViewer.Github.IAnalogy
{
    public class IssuesTracker : Template.OnlineDataProvider
    {

        public override Guid Id { get; set; } = new Guid("a6f0882d-c39a-4c38-9f9d-267d5d012db3");

        public override Image? ConnectedLargeImage { get; set; } = null;
        public override Image? ConnectedSmallImage { get; set; } = null;
        public override Image? DisconnectedLargeImage { get; set; } = null;
        public override Image? DisconnectedSmallImage { get; set; } = null;

        public override string? OptionalTitle { get; set; } = "Issues Tracker";
        public override Task<bool> CanStartReceiving() => Task.FromResult(true);
        public override IAnalogyOfflineDataProvider? FileOperationsHandler { get; set; } = null;

        public override bool UseCustomColors { get; set; } = false;
        public override IEnumerable<(string originalHeader, string replacementHeader)> GetReplacementHeaders()
            => new List<(string originalHeader, string replacementHeader)> { ("Module", "Comments"), ("User", "Id"), ("User", "Type"), ("Category", "URL") };

        public override (Color backgroundColor, Color foregroundColor) GetColorForMessage(IAnalogyLogMessage logMessage)
            => (Color.Empty, Color.Empty);
        public List<RepositorySettings> Repositories => UserSettingsManager.UserSettings.GithubSettings.Repositories;

        private Timer? fetcher;
        public IssuesTracker()
        {
        }


        public override Task StartReceiving()
        {
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
                    var (_, issues) = await Utils.GetAsync<GitHubIssue[]>(repo.RepoApiIssuesUrl,
                        UserSettingsManager.UserSettings.GithubSettings.GitHubToken, DateTime.MinValue)
                    .ConfigureAwait(false);
                    if (issues == null)
                    {
                        return;
                    }

                    foreach (var entry in issues)
                    {

                        AnalogyLogMessage m = new AnalogyLogMessage
                        {
                            Text = $"{entry.Title}{Environment.NewLine}URL:{entry.html_url}{Environment.NewLine}Body:{entry.body}{Environment.NewLine}",
                            Level = AnalogyLogLevel.Information,
                            Source = repo.DisplayName,
                            Date = entry.updated_at,
                            FileName = entry.Id,
                            Category = entry.html_url,
                            User = entry.Id,
                            Module = $"Comments: {entry.comments} ({ entry.comments_url })"
                        };
                        if (entry.comments > 0)
                        {
                            var comments = await Utils.GetAsync<GitHubComment[]>(entry.comments_url,
                                UserSettingsManager.UserSettings.GithubSettings.GitHubToken, DateTime.MinValue);
                            if (comments.newData)
                            {
                                StringBuilder sb = new StringBuilder(Environment.NewLine + "### Comments:" +
                                                                     Environment.NewLine);
                                sb.Append("| User   |      Comment      |" + Environment.NewLine + "| ----------|:---------------| ");
                                foreach (var comment in comments.result)
                                {
                                    sb.Append($"{Environment.NewLine}|{comment.user.Login} ![image]({comment.user.avatarUrl})|{comment.body}.At: {comment.created_at}");
                                }

                                m.Text += Environment.NewLine + sb;
                            }
                        }

                        MessageReady(this, new AnalogyLogMessageArgs(m, repo.DisplayName, "Github", Id));

                    }
                }
                catch (Exception e)
                {
                    Template.Managers.LogManager.Instance.LogError($@"Error reading {repo.DisplayName}: {e}",
                        nameof(StartReceiving));
                    AnalogyLogMessage m = new AnalogyLogMessage
                    {
                        Date = DateTime.Now,
                        Module = repo.DisplayName,
                        Text = $"Error: {e}",
                        Level = AnalogyLogLevel.Error,
                        Class = AnalogyLogClass.General
                    };
                    MessageReady(this, new AnalogyLogMessageArgs(m, "", "", Id));
                }

            }
        }
    }
}
