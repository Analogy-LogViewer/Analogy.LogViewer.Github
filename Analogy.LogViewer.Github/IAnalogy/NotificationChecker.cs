using Analogy.Interfaces;
using Analogy.LogViewer.Github.Data_Types;
using Analogy.LogViewer.Github.Managers;
using Analogy.LogViewer.Template;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Analogy.LogViewer.Github.IAnalogy
{
    public class NotificationChecker : OnlineDataProvider
    {
        public override Guid Id { get; set; } = new Guid("47e095e9-65bd-4328-bd8a-eb261180c2f2");
        public override Image? ConnectedLargeImage { get; set; } = null;
        public override Image? ConnectedSmallImage { get; set; } = null;
        public override Image? DisconnectedLargeImage { get; set; } = null;
        public override Image? DisconnectedSmallImage { get; set; } = null;
        public override string OptionalTitle { get; set; }
        public override Task<bool> CanStartReceiving() => Task.FromResult(true);
        public override IAnalogyOfflineDataProvider? FileOperationsHandler { get; set; } = null;
        public override bool UseCustomColors { get; set; } = false;
        private Timer RefreshTimer { get; set; }
        public override IEnumerable<(string originalHeader, string replacementHeader)> GetReplacementHeaders()
            => new List<(string originalHeader, string replacementHeader)> { ("Module", "Downloads"), ("User", "Type") };

        public override (Color backgroundColor, Color foregroundColor) GetColorForMessage(IAnalogyLogMessage logMessage)
            => (Color.Empty, Color.Empty);

        public override Task InitializeDataProviderAsync(IAnalogyLogger logger)
        {
            LogManager.Instance.SetLogger(logger);
            return base.InitializeDataProviderAsync(logger);
        }

        public override Task StartReceiving()
        {
            RefreshTimer = new Timer(CheckStatus, null, 0,
                    UserSettingsManager.UserSettings.GithubSettings.GitHubNotificationIntervalMilliseconds);
            return Task.CompletedTask;

        }
        public override Task StopReceiving() => Task.CompletedTask;
        private async void CheckStatus(Object stateInfo)
        {
            var (newData, notifications) = await Utils.GetAsync<GitHubUserNotification[]>(
                "https://api.github.com/notifications", UserSettingsManager.UserSettings.GithubSettings.GitHubToken,
                UserSettingsManager.UserSettings.GithubSettings.LastReadUserNotification);
            UserSettingsManager.UserSettings.GithubSettings.LastReadUserNotification = DateTime.Now;
            if (newData)
            {
                UserSettingsManager.UserSettings.GithubSettings.LastUnReadUserNotifications = notifications.Where(n => n.Unread).ToList();
            }

            if (notifications != null)
            {
                foreach (GitHubUserNotification n in notifications)
                {
                    AnalogyInformationMessage m = new AnalogyInformationMessage(n.Subject.Title,n.Repository.FullName);
                    m.Category = n.Subject.Type;
                    m.Module = n.Subject.URL;
                    MessageReady(this,new AnalogyLogMessageArgs(m,"","Notifications",Id));
                }
            }
        }
    }
}

