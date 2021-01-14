using Analogy.Interfaces;
using System;
using System.Collections.Generic;

namespace Analogy.LogViewer.Github.IAnalogy
{
    public class GitHubAccountNotificationsFactory : Template.DataProvidersFactory
    {
        public override Guid FactoryId { get; set; } = PrimaryFactory.Id;
        public override string Title { get; set; } = "Account Notifications";
        public override IEnumerable<IAnalogyDataProvider> DataProviders { get; set; } = GenerateDataProviders();


        private static IEnumerable<IAnalogyDataProvider> GenerateDataProviders()
        {
            yield return new NotificationChecker();
        }
    }

}
