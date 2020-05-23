using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.LogViewer.Github.Managers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Analogy.LogViewer.Github.IAnalogy
{
    public class GitHubDataProviderFactory : IAnalogyDataProvidersFactory
    {
        public Guid FactoryId { get; } = GitHubFactory.Id;
        public string Title => "Repositories";

        public IEnumerable<IAnalogyDataProvider> DataProviders => UserSettingsManager.UserSettings.RepositoriesSetting.Repositories.Select(rs => new GitRepositoryLoader(rs));
    }

}
