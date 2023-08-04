using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;

namespace Analogy.LogViewer.Github.Managers
{
    public class UserSettingsManager
    {
        private static readonly Lazy<UserSettingsManager> _instance =
            new Lazy<UserSettingsManager>(() => new UserSettingsManager());
        public static UserSettingsManager UserSettings { get; set; } = _instance.Value;
        private string RepositoriesSettingFile { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Analogy.LogViewer", "AnalogyGitHubSettings.json");
        public GithubSettings GithubSettings { get; }

        public UserSettingsManager()
        {
            GithubSettings = new GithubSettings();
            if (File.Exists(RepositoriesSettingFile))
            {
                try
                {
                    string data = File.ReadAllText(RepositoriesSettingFile);
                    GithubSettings = JsonConvert.DeserializeObject<GithubSettings>(data);

                }
                catch (Exception ex)
                {
                    Template.Managers.LogManager.Instance.LogCritical(ex, $"Unable to read file {RepositoriesSettingFile}: {ex}");
                }
            }
        }

        public void Save()
        {
            try
            {
                File.WriteAllText(RepositoriesSettingFile, JsonConvert.SerializeObject(GithubSettings));
            }
            catch (Exception ex)
            {
                Template.Managers.LogManager.Instance.LogCritical($"Unable to save file {RepositoriesSettingFile}: {ex}", "");

            }


        }
    }
}
