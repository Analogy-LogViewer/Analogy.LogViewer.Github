using System;
using System.Collections.Generic;
using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.LogViewer.Github.Data_Types;
using Analogy.LogViewer.Github.Managers;

namespace Analogy.LogViewer.Github.IAnalogy
{
    public class GitHistoryDataProviderFactory : IAnalogyDataProvidersFactory
    {
        public Guid FactoryId { get; } = GitHistoryFactory.Id;
        public string Title => "Repositories History";

        public IEnumerable<IAnalogyDataProvider> DataProviders
        {
            get
            {
                foreach (RepositorySetting rs in UserSettingsManager.UserSettings.RepositoriesSetting.Repositories)
                {
                    yield return new GitRepositoryLoader(rs, GitOperationType.History);
                }
            }

        }
    }
    public class GitFetchDataProviderFactory : IAnalogyDataProvidersFactory
    {
        public Guid FactoryId { get; } = GitHistoryFactory.Id;
        public string Title => "Repositories Fetches";

        public IEnumerable<IAnalogyDataProvider> DataProviders
        {
            get
            {
                foreach (RepositorySetting rs in UserSettingsManager.UserSettings.RepositoriesSetting.Repositories)
                {
                    yield return new GitRepositoryLoader(rs,GitOperationType.Fetch);
                }
            }

        }
    }
}
