using Analogy.LogViewer.Github.Data_Types;
using Analogy.LogViewer.Github.Managers;
using System;
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
        }

        private void RefreshList()
        {
            lstRepositores.DataSource = null;
            lstRepositores.DataSource = UserSettingsManager.UserSettings.RepositoriesSetting.Repositories;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRepository.Text))
            {
                RepositorySettings r = new RepositorySettings(txtRepository.Text, txtRepository.Text, 0);
                UserSettingsManager.UserSettings.RepositoriesSetting.AddRepository(r);
                RefreshList();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lstRepositores.SelectedItem is RepositorySettings repo)
            {
                UserSettingsManager.UserSettings.RepositoriesSetting.DeleteRepository(repo);
                RefreshList();
            }
        }
    }
}
