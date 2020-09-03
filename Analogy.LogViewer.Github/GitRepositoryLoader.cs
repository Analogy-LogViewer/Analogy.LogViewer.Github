using Analogy.Interfaces;
using Analogy.LogViewer.Github.Data_Types;
using Analogy.LogViewer.Github.Managers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Analogy.LogViewer.Github
{
    public class GitRepositoryLoader : IAnalogyRealTimeDataProvider
    {
        public string GitHubToken { get; } = Environment.GetEnvironmentVariable("GitHubNotifier_Token");
        public Guid Id { get; } = new Guid("B92CA79D-3621-416E-ADA7-52EEAF243759");

        public Image ConnectedLargeImage { get; } = null;
        public Image ConnectedSmallImage { get; } = null;
        public Image DisconnectedLargeImage { get; } = null;
        public Image DisconnectedSmallImage { get; } = null;

        public string OptionalTitle => Repository.DisplayName;
        public Task<bool> CanStartReceiving() => Task.FromResult(true);
        public IAnalogyOfflineDataProvider FileOperationsHandler { get; } = null;
        public bool IsConnected { get; } = true;
        public event EventHandler<AnalogyDataSourceDisconnectedArgs> OnDisconnected;
        public event EventHandler<AnalogyLogMessageArgs> OnMessageReady;
        public event EventHandler<AnalogyLogMessagesArgs> OnManyMessagesReady;
        private RepositorySettings Repository { get; }
        private Task fetcher;
        public bool UseCustomColors { get; set; } = false;
        public IEnumerable<(string originalHeader, string replacementHeader)> GetReplacementHeaders()
            => new List<(string originalHeader, string replacementHeader)>() { ("Module", "Downloads"), ("User", "Type") };

        public (Color backgroundColor, Color foregroundColor) GetColorForMessage(IAnalogyLogMessage logMessage)
            => (Color.Empty, Color.Empty);
        public GitRepositoryLoader(RepositorySettings repo)
        {
            Repository = repo;
        }

        public Task InitializeDataProviderAsync(IAnalogyLogger logger)
        {
            LogManager.Instance.SetLogger(logger);
            return Task.CompletedTask;
        }

        public void MessageOpened(AnalogyLogMessage message)
        {
            //noop
        }

        public async Task StartReceiving()
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
                        Level = AnalogyLogLevel.Event,
                        Source = Repository.DisplayName,
                        Date = entry.Published,
                        FileName = entry.Id,
                        Category = entry.Branch,
                        User = "Release",
                        Module = entry.Assets.Sum(a => a.Downloads).ToString()
                    };
                    OnMessageReady?.Invoke(this, new AnalogyLogMessageArgs(m, Repository.DisplayName, "Github", Id));

                }
                int total = releases.SelectMany(e => e.Assets).Sum(a => a.Downloads);
                AnalogyLogMessage d = new AnalogyLogMessage
                {
                    Text = $"Total Downloads: {total}",
                    Level = AnalogyLogLevel.Event,
                    Source = Repository.DisplayName,
                    Date = DateTime.Now,
                    FileName = "",
                    Category = "",
                    User = "Release",
                    Module = total.ToString()
                };
                OnMessageReady?.Invoke(this, new AnalogyLogMessageArgs(d, Repository.DisplayName, "Github", Id));

            }
            catch (Exception e)
            {
                LogManager.Instance.LogError(nameof(StartReceiving),
                    $@"Error reading {Repository}: {e}");
                AnalogyLogMessage m = new AnalogyLogMessage
                {
                    Date = DateTime.Now,
                    Module = Repository.DisplayName,
                    Text = $"Error: {e}",
                    Level = AnalogyLogLevel.Error,
                    Class = AnalogyLogClass.General
                };
                OnMessageReady?.Invoke(this, new AnalogyLogMessageArgs(m, "", "", Id));
            }
        }

        public Task StopReceiving() => Task.CompletedTask;

    }
}
