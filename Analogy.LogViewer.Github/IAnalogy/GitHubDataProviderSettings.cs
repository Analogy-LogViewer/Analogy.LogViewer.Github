using Analogy.DataProviders.Extensions;
using Analogy.LogViewer.Github.Managers;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.LogViewer.Github.IAnalogy
{
    public class GitHubDataProviderSettings : IAnalogyDataProviderSettings
    {

        public string Title { get; } = "GitHub settings";
        public UserControl DataProviderSettings { get; } = new GitRepositoriesSettings();
        public Image SmallImage { get; }
        public Image LargeImage { get; }
        public Guid FactoryId { get; set; } = GitHubFactory.Id;
        public Guid ID { get; set; } = new Guid("2B46268B-0BB7-4D3B-9ED1-8E3C5B206F2F");

        public Task SaveSettingsAsync()
        {
            UserSettingsManager.UserSettings.Save();
            return Task.CompletedTask;
        }
    }
}
