using Analogy.Interfaces;
using Analogy.LogViewer.Github.Data_Types;
using Analogy.LogViewer.Github.Managers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Analogy.LogViewer.Github
{
    public class GitRepositoryLoader : IAnalogyRealTimeDataProvider
    {
        public Guid ID { get; } = new Guid("B92CA79D-3621-416E-ADA7-52EEAF243759");
        public string OptionalTitle => Repository;
        public Task<bool> CanStartReceiving() => Task.FromResult(true);
        public IAnalogyOfflineDataProvider FileOperationsHandler { get; } = null;
        public bool IsConnected { get; } = true;
        public event EventHandler<AnalogyDataSourceDisconnectedArgs> OnDisconnected;
        public event EventHandler<AnalogyLogMessageArgs> OnMessageReady;
        public event EventHandler<AnalogyLogMessagesArgs> OnManyMessagesReady;
        private string Repository { get; }
        private GitHubOperationType Type { get; }
        private Task fetcher;
        public bool UseCustomColors { get; set; } = false;
        public IEnumerable<(string originalHeader, string replacementHeader)> GetReplacementHeaders()
            => new List<(string originalHeader, string replacementHeader)>() { ("Module", "Downloads") };

        public (Color backgroundColor, Color foregroundColor) GetColorForMessage(IAnalogyLogMessage logMessage)
            => (Color.Empty, Color.Empty);
        public GitRepositoryLoader(string rs, GitHubOperationType type)
        {
            Repository = rs;
            Type = type;
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

        public void StartReceiving()
        {

            Task.Factory.StartNew(async () =>
            {
                try
                {
                    string data = await Utils.GetAsync(Repository);
                    //var dictionary = JsonConvert.DeserializeObject(data);

                    string releases = await Utils.GetAsync(Repository + "/releases");
                    var r = JsonConvert.DeserializeObject<GithubReleaseEntry[]>(releases);
                    foreach (GithubReleaseEntry entry in r)
                    {
                        AnalogyLogMessage m = new AnalogyLogMessage();
                        m.Text = $"{entry.TagName}{Environment.NewLine}{entry.Content}{Environment.NewLine}{string.Join(Environment.NewLine, entry.Assets.Select(e => e.ToString()))}";
                        m.Level = AnalogyLogLevel.Event;
                        m.Source = Repository;
                        m.Date = entry.Published;
                        m.FileName = entry.Id;
                        m.Category = entry.Branch;
                        m.Module = entry.Assets.Sum(a => a.Downloads).ToString();
                        OnMessageReady?.Invoke(this, new AnalogyLogMessageArgs(m, Repository, "Github", ID));

                    }
                    AnalogyLogMessage d = new AnalogyLogMessage();
                    d.Text = $"Total Downloads: {r.SelectMany(e => e.Assets).Sum(a => a.Downloads)}";
                    d.Level = AnalogyLogLevel.Event;
                    d.Source = Repository;
                    d.Date = DateTime.Now;
                    d.FileName = "";
                    d.Category = "";
                    d.Module = "";
                    OnMessageReady?.Invoke(this, new AnalogyLogMessageArgs(d, Repository, "Github", ID));

                }
                catch (Exception e)
                {
                    LogManager.Instance.LogError(nameof(StartReceiving),
                        $@"Error reading {Repository}: {e}");
                    AnalogyLogMessage m = new AnalogyLogMessage
                    {
                        Date = DateTime.Now,
                        Module = Repository,
                        Text = $"Error: {e}",
                        Level = AnalogyLogLevel.Error,
                        Class = AnalogyLogClass.General
                    };
                    OnMessageReady?.Invoke(this, new AnalogyLogMessageArgs(m, "", "", ID));
                }
            });

        }

        public void StopReceiving()
        {
            //noop
        }

    }
}
