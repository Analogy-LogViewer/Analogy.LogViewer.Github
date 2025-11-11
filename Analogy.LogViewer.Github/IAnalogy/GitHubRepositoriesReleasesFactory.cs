using Analogy.Interfaces;
using Analogy.Interfaces.WinForms;
using Analogy.LogViewer.Github.Managers;

namespace Analogy.LogViewer.Github.IAnalogy
{
    public class GitHubRepositoriesReleasesFactory : Template.DataProvidersFactoryWinForms
    {
        public override Guid FactoryId { get; set; } = PrimaryFactory.Id;
        public override string Title { get; set; } = "Repositories Releases";
        public override IEnumerable<IAnalogyDataProviderWinForms> DataProviders { get; set; } = GenerateDataProviders();

        private static IEnumerable<IAnalogyDataProviderWinForms> GenerateDataProviders()
        {
            foreach (var repo in UserSettingsManager.UserSettings.GithubSettings.Repositories.Select(rs =>
                new GitRepositoryLoader(rs)))
            {
                yield return repo;
            }
        }
    }
}