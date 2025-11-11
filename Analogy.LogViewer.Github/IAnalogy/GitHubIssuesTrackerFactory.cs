using Analogy.Interfaces;
using Analogy.Interfaces.WinForms;

namespace Analogy.LogViewer.Github.IAnalogy
{
    public class GitHubIssuesTrackerFactory : Template.DataProvidersFactoryWinForms
    {
        public override Guid FactoryId { get; set; } = PrimaryFactory.Id;
        public override string Title { get; set; } = "Repositories Releases";
        public override IEnumerable<IAnalogyDataProviderWinForms> DataProviders { get; set; } = GenerateDataProviders();

        private static IEnumerable<IAnalogyDataProviderWinForms> GenerateDataProviders()
        {
            yield return new IssuesTracker();
        }
    }
}