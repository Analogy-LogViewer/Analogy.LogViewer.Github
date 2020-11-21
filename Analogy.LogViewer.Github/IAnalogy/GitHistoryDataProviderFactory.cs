using Analogy.Interfaces;
using Analogy.LogViewer.Github.Managers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Analogy.LogViewer.Github.IAnalogy
{
    public class GitHubDataProviderFactory : Template.DataProvidersFactory
    {
        public override Guid FactoryId { get; set; } = PrimaryFactory.Id;
        public override string Title { get; set; } = "Repositories";
        public override IEnumerable<IAnalogyDataProvider> DataProviders { get; set; } = UserSettingsManager.UserSettings.RepositoriesSetting.Repositories.Select(rs => new GitRepositoryLoader(rs));
    }

}
