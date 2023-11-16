using Analogy.LogViewer.Github.DataTypes;
using Analogy.LogViewer.Github.Managers;
using System.Windows.Forms;

namespace Analogy.LogViewer.Github
{
    public partial class GitRepositoriesSettings : UserControl
    {
        public GitRepositoriesSettings()
        {
            InitializeComponent();
        }

        private void GitRepositoriesSettings_Load(object sender, EventArgs e)
        {
            RefreshList();
            txtbLocalToken.Text = UserSettingsManager.UserSettings.GithubSettings.GitHubToken;
        }

        private void RefreshList()
        {
            lstRepositores.DataSource = null;
            lstRepositores.DataSource = UserSettingsManager.UserSettings.GithubSettings.Repositories;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRepositoryOwner.Text) && !string.IsNullOrEmpty(txtbRepoName.Text))
            {
                RepositorySettings r = new RepositorySettings(txtRepositoryOwner.Text, txtbRepoName.Text, 0);
                UserSettingsManager.UserSettings.GithubSettings.AddRepository(r);
                RefreshList();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lstRepositores.SelectedItem is RepositorySettings repo)
            {
                UserSettingsManager.UserSettings.GithubSettings.DeleteRepository(repo);
                RefreshList();
            }
        }

        private void btnLocalToken_Click(object sender, EventArgs e)
        {
            UserSettingsManager.UserSettings.GithubSettings.LocalGitHubToken = txtbLocalToken.Text;
        }
    }
}