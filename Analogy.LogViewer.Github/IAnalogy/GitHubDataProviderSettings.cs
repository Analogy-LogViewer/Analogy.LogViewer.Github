using Analogy.LogViewer.Github.Managers;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.Interfaces;

namespace Analogy.LogViewer.Github.IAnalogy
{
    public class GitHubDataProviderSettings : IAnalogyDataProviderSettings
    {

        public string Title { get; set; } = "GitHub settings";
        public UserControl DataProviderSettings { get; } = new GitRepositoriesSettings();
        public Image SmallImage { get; set; }
        public Image LargeImage { get; set; }
        public Guid FactoryId { get; set; } = GitHubFactory.Id;
        public Guid Id { get; set; } = new Guid("2B46268B-0BB7-4D3B-9ED1-8E3C5B206F2F");

        public Task SaveSettingsAsync()
        {
            UserSettingsManager.UserSettings.Save();
            return Task.CompletedTask;
        }
    }
}
