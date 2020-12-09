using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analogy.Interfaces;
using Analogy.LogViewer.Github.Managers;
using Analogy.LogViewer.Template;

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

        public override IEnumerable<(string originalHeader, string replacementHeader)> GetReplacementHeaders()
            => new List<(string originalHeader, string replacementHeader)> {("Module", "Downloads"), ("User", "Type")};

        public override (Color backgroundColor, Color foregroundColor) GetColorForMessage(IAnalogyLogMessage logMessage)
            => (Color.Empty, Color.Empty);

        public override Task InitializeDataProviderAsync(IAnalogyLogger logger)
        {
            LogManager.Instance.SetLogger(logger);
            return base.InitializeDataProviderAsync(logger);
        }

        public override Task StartReceiving()
        {

            try
            {
            }
            catch (Exception e)
            {
            }

            return Task.CompletedTask;

        }
        public override Task StopReceiving() => Task.CompletedTask;
    }
}
