using Analogy.Interfaces;
using Analogy.LogViewer.Github.Data_Types;
using Analogy.LogViewer.Github.Managers;
using System;
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
