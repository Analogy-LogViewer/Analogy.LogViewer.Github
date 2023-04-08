using Analogy.Interfaces;

namespace Analogy.LogViewer.Github.IAnalogy
{
    public class GitHubIssuesTrackerFactory : Template.DataProvidersFactory
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
