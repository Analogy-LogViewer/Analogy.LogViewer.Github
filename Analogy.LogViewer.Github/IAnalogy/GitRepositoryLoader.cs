using Analogy.Interfaces;
using Analogy.LogViewer.Github.Data_Types;
using Analogy.LogViewer.Github.Managers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Analogy.LogViewer.Github
{
    public class GitRepositoryLoader : Template.OnlineDataProvider
    {

        public override Guid Id { get; set; } = new Guid("B92CA79D-3621-416E-ADA7-52EEAF243759");

        public override Image? ConnectedLargeImage { get; set; } = null;
        public override Image? ConnectedSmallImage { get; set; } = null;
        public override Image? DisconnectedLargeImage { get; set; } = null;
        public override Image? DisconnectedSmallImage { get; set; } = null;

        public override string? OptionalTitle { get; set; }
        public override Task<bool> CanStartReceiving() => Task.FromResult(true);
        public override IAnalogyOfflineDataProvider? FileOperationsHandler { get; set; } = null;

        private RepositorySettings Repository { get; }
        public override bool UseCustomColors { get; set; } = false;
        public override IEnumerable<(string originalHeader, string replacementHeader)> GetReplacementHeaders()
            => new List<(string originalHeader, string replacementHeader)> { ("Module", "Downloads"), ("User", "Type") , ("Category", "URL") };

        public override (Color backgroundColor, Color foregroundColor) GetColorForMessage(IAnalogyLogMessage logMessage)
            => (Color.Empty, Color.Empty);

        private Timer? fetcher;
        public GitRepositoryLoader(RepositorySettings repo)
        {
            Repository = repo;
            OptionalTitle = "Release for: " + Repository.DisplayName;

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
            try
            {
                var (_, releases) = await Utils.GetAsync<GithubReleaseEntry[]>(Repository.RepoApiReleasesUrl, UserSettingsManager.UserSettings.GithubSettings.GitHubToken, DateTime.MinValue).ConfigureAwait(false);
                if (releases == null)
                {
                    return;
                }
                foreach (GithubReleaseEntry entry in releases)
                {
                    AnalogyLogMessage m = new AnalogyLogMessage
                    {
                        Text =
                            $"{entry.TagName}{Environment.NewLine}{entry.Content}{Environment.NewLine}{string.Join(Environment.NewLine, entry.Assets.Select(e => e.ToString()))}",
                        Level = AnalogyLogLevel.Information,
                        Source = Repository.DisplayName,
                        Date = entry.Published,
                        FileName = entry.Id,
                        Category = entry.HtmlUrl,
                        User = "Release",
                        Module = entry.Assets.Sum(a => a.Downloads).ToString()
                    };
                    MessageReady(this, new AnalogyLogMessageArgs(m, Repository.DisplayName, "Github", Id));

                }
                int total = releases.SelectMany(e => e.Assets).Sum(a => a.Downloads);
                AnalogyLogMessage d = new AnalogyLogMessage
                {
                    Text = $"Total Downloads: {total}",
                    Level = AnalogyLogLevel.Information,
                    Source = Repository.DisplayName,
                    Date = DateTime.Now,
                    FileName = "",
                    Category = "",
                    User = "Release",
                    Module = total.ToString()
                };
                MessageReady(this, new AnalogyLogMessageArgs(d, Repository.DisplayName, "Github", Id));

            }
            catch (Exception e)
            {
                Template.Managers.LogManager.Instance.LogError($@"Error reading {Repository}: {e}", nameof(StartReceiving));
                AnalogyLogMessage m = new AnalogyLogMessage
                {
                    Date = DateTime.Now,
                    Module = Repository.DisplayName,
                    Text = $"Error: {e}",
                    Level = AnalogyLogLevel.Error,
                    Class = AnalogyLogClass.General
                };
                MessageReady(this, new AnalogyLogMessageArgs(m, "", "", Id));
            }

        }
    }
}
