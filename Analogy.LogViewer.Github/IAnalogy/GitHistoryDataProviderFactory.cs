using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.LogViewer.Github.Data_Types;
using Analogy.LogViewer.Github.Managers;
using System;
using System.Collections.Generic;

namespace Analogy.LogViewer.Github.IAnalogy
{
    public class GitHubDataProviderFactory : IAnalogyDataProvidersFactory
    {
        public Guid FactoryId { get; } = GitHistoryFactory.Id;
        public string Title => "Repositories";

        public IEnumerable<IAnalogyDataProvider> DataProviders
        {
            get
            {
                foreach (string rs in UserSettingsManager.UserSettings.RepositoriesSetting.Repositories)
                {
                    string repo = rs;
                    GitHubOperationType op = GitHubOperationType.MainPage;
                    if (repo.EndsWith("/"))
                        repo = repo.Substring(0, repo.Length - 2);
                    if (repo.EndsWith("Releases", StringComparison.InvariantCultureIgnoreCase))
                        op = GitHubOperationType.Releases;

                    yield return new GitRepositoryLoader(rs, op);
                }
            }

        }
    }
    //public class GitFetchDataProviderFactory : IAnalogyDataProvidersFactory
    //{
    //    public Guid FactoryId { get; } = GitHistoryFactory.Id;
    //    public string Title => "Repositories Fetches";

    //    public IEnumerable<IAnalogyDataProvider> DataProviders
    //    {
    //        get
    //        {
    //            foreach (string rs in UserSettingsManager.UserSettings.RepositoriesSetting.Repositories)
    //            {
    //                yield return new GitRepositoryLoader(rs, GitHubOperationType.Fetch);
    //            }
    //        }

    //    }
    //}
}
