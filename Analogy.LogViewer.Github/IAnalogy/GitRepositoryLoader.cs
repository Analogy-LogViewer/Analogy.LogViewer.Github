using Analogy.CommonUtilities.Github;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.LogViewer.Github.DataTypes;
using Analogy.LogViewer.Github.Managers;
using Microsoft.Extensions.Logging;
using Octokit;
using System.Drawing;
using System.Threading;

namespace Analogy.LogViewer.Github
{
    public class GitRepositoryLoader : Template.OnlineDataProvider
    {
        public override Guid Id { get; set; } = new Guid("B92CA79D-3621-416E-ADA7-52EEAF243759");

        public override Image? ConnectedLargeImage { get; set; }
        public override Image? ConnectedSmallImage { get; set; }
        public override Image? DisconnectedLargeImage { get; set; }
        public override Image? DisconnectedSmallImage { get; set; }

        public override string? OptionalTitle { get; set; }
        public override Task<bool> CanStartReceiving() => Task.FromResult(true);

        public override IAnalogyOfflineDataProvider? FileOperationsHandler { get; set; }

        private RepositorySettings Repository { get; }
        public override bool UseCustomColors { get; set; }
        public override IEnumerable<(string OriginalHeader, string ReplacementHeader)> GetReplacementHeaders()
            => new List<(string OriginalHeader, string ReplacementHeader)> { ("Module", "Downloads"), ("User", "Type"), ("Category", "URL") };

        public override (Color BackgroundColor, Color ForegroundColor) GetColorForMessage(IAnalogyLogMessage logMessage)
            => (Color.Empty, Color.Empty);

        private GitHubClient? Client { get; set; }
        private Timer? fetcher;
        private UserSettingsManager Settings => UserSettingsManager.UserSettings;
        public GitRepositoryLoader(RepositorySettings repo)
        {
            Repository = repo;
            OptionalTitle = "Release for: " + Repository.DisplayName;
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
            try
            {
                var releases = await Client.Repository.Release.GetAll(Repository.Owner, Repository.RepoName);
                if (releases == null)
                {
                    return;
                }
                foreach (var entry in releases)
                {
                    AnalogyLogMessage m = new AnalogyLogMessage
                    {
                        Text =
                            $"{entry.TagName}{Environment.NewLine}{entry.Body}{Environment.NewLine}{string.Join(Environment.NewLine, entry.Assets.Select(e => e.Name))}",
                        Level = AnalogyLogLevel.Information,
                        Source = Repository.DisplayName,
                        Date = entry.PublishedAt ?? DateTimeOffset.MinValue,
                        FileName = entry.Url,
                        User = "Release",
                        Module = entry.Assets.Sum(a => a.DownloadCount).ToString(),
                    };
                    m.AddOrReplaceAdditionalProperty("Category", entry.HtmlUrl);
                    MessageReady(this, new AnalogyLogMessageArgs(m, Repository.DisplayName, "Github", Id));
                }
                int total = releases.SelectMany(e => e.Assets).Sum(a => a.DownloadCount);
                AnalogyLogMessage d = new AnalogyLogMessage
                {
                    Text = $"Total Downloads: {total}",
                    Level = AnalogyLogLevel.Information,
                    Source = Repository.DisplayName,
                    Date = DateTime.Now,
                    FileName = "",
                    User = "Release",
                    Module = total.ToString(),
                };
                MessageReady(this, new AnalogyLogMessageArgs(d, Repository.DisplayName, "Github", Id));
            }
            catch (Exception e)
            {
                Template.Managers.LogManager.Instance.LogError(e, $@"Error reading {Repository}: {e}");
                AnalogyLogMessage m = new AnalogyLogMessage
                {
                    Date = DateTime.Now,
                    Module = Repository.DisplayName,
                    Text = $"Error: {e}",
                    Level = AnalogyLogLevel.Error,
                    Class = AnalogyLogClass.General,
                };
                MessageReady(this, new AnalogyLogMessageArgs(m, "", "", Id));
            }
        }
        public override Task ShutDown() => Task.CompletedTask;
    }
}