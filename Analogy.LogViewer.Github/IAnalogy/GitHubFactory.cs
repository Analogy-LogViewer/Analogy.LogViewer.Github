using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using System;
using System.Collections.Generic;
using System.Drawing;
using Analogy.LogViewer.Github.Properties;

namespace Analogy.LogViewer.Github.IAnalogy
{
    public class GitHubFactory : IAnalogyFactory
    {
        internal static Guid Id = new Guid("8064229A-2605-42FA-9E72-75444E4AB13F");
        public void RegisterNotificationCallback(INotificationReporter notificationReporter)
        {
            
        }

        public Guid FactoryId { get; set; } = Id;

        public string Title { get; set; } = "Github";
        public Image SmallImage { get; set; } = Resources.Git_icon_16x16;
        public Image LargeImage { get; set; } = Resources.Git_icon_32x32;
        public IEnumerable<IAnalogyChangeLog> ChangeLog { get; set; } = new List<AnalogyChangeLog>
        {
            new AnalogyChangeLog("Initial version",AnalogChangeLogType.None, "Lior Banai",new DateTime(2020, 04, 14))
        };
        public IEnumerable<string> Contributors { get; set; } = new List<string> { "Lior Banai" };
        public string About { get; set; } = "Github Info";
    }
}
