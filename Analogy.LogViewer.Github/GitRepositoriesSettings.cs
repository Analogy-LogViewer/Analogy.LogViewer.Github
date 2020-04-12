using System;
using System.IO;
using System.Windows.Forms;
using Analogy.LogViewer.Github.Managers;

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
            if (string.IsNullOrEmpty(txtRepository.Text) || Directory.Exists(txtRepository.Text))
            {
                FetchType f = rbCount.Checked ? FetchType.Count : FetchType.DateTime;
                RepositorySetting rs = new RepositorySetting(txtRepository.Text, (int)nudCommits.Value,
                    dateTimePicker1.Value, f);
                UserSettingsManager.UserSettings.RepositoriesSetting.AddRepository(rs);
                RefreshList();
            }
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDlg = new FolderBrowserDialog
            {
                ShowNewFolderButton = false
            })
            {
                // Show the FolderBrowserDialog.  
                DialogResult result = folderDlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtRepository.Text = folderDlg.SelectedPath;
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lstRepositores.SelectedItem is RepositorySetting repo)
            {
                UserSettingsManager.UserSettings.RepositoriesSetting.DeleteRepository(repo);
                RefreshList();
            }
        }
    }
}
