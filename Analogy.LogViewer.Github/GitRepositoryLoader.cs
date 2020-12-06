using Analogy.Interfaces;
using Analogy.LogViewer.Github.Data_Types;
using Analogy.LogViewer.Github.Managers;
using Analogy.LogViewer.Template;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Analogy.LogViewer.Github
{
    public class GitRepositoryLoader : OnlineDataProvider
    {
        public string GitHubToken { get; } = Environment.GetEnvironmentVariable("GitHubNotifier_Token");
        public override Guid Id { get; set; } = new Guid("B92CA79D-3621-416E-ADA7-52EEAF243759");

        public override Image? ConnectedLargeImage { get; set; } = null;
        public override Image? ConnectedSmallImage { get; set; } = null;
        public override Image? DisconnectedLargeImage { get; set; } = null;
        public override Image? DisconnectedSmallImage { get; set; } = null;

        public override string OptionalTitle { get; set; }
        public override Task<bool> CanStartReceiving() => Task.FromResult(true);
        public override IAnalogyOfflineDataProvider? FileOperationsHandler { get; set; } = null;

        private RepositorySettings Repository { get; }
        private Task fetcher;
        public bool UseCustomColors { get; set; } = false;
        public override IEnumerable<(string originalHeader, string replacementHeader)> GetReplacementHeaders()
            => new List<(string originalHeader, string replacementHeader)> { ("Module", "Downloads"), ("User", "Type") };

        public override (Color backgroundColor, Color foregroundColor) GetColorForMessage(IAnalogyLogMessage logMessage)
            => (Color.Empty, Color.Empty);
        public GitRepositoryLoader(RepositorySettings repo)
        {
            Repository = repo;
            OptionalTitle = Repository.DisplayName;
        }

        public override Task InitializeDataProviderAsync(IAnalogyLogger logger)
        {
            LogManager.Instance.SetLogger(logger);
            return base.InitializeDataProviderAsync(logger); 
        }
        
        public override async Task StartReceiving()
        {

            try
            {
                var (_, releases) = await Utils.GetAsync<GithubReleaseEntry[]>(Repository.RepoApiReleasesUrl, GitHubToken, DateTime.MinValue).ConfigureAwait(false);
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
                        Category = entry.Branch,
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
                LogManager.Instance.LogError($@"Error reading {Repository}: {e}", nameof(StartReceiving));
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

        public override Task StopReceiving() => Task.CompletedTask;

    }
}
