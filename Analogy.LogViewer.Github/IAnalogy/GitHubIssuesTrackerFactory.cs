using Analogy.Interfaces;
using Analogy.Interfaces.WinForms;
using Analogy.LogViewer.Template.WinForms;

namespace Analogy.LogViewer.Github.IAnalogy
{
    public class GitHubIssuesTrackerFactory : DataProvidersFactoryWinForms
    {
        public override Guid FactoryId { get; set; } = PrimaryFactory.Id;
        public override string Title { get; set; } = "Repositories Releases";
        public override IEnumerable<IAnalogyDataProvider> DataProviders { get; set; } = GenerateDataProviders();

        private static IEnumerable<IAnalogyDataProvider> GenerateDataProviders()
        {
            yield return new IssuesTracker();
        }
    }
}