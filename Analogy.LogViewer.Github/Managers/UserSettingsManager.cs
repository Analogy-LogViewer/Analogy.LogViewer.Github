using System;
using System.IO;
using Newtonsoft.Json;

namespace Analogy.LogViewer.Github.Managers
{
    public class UserSettingsManager
    {
        private static readonly Lazy<UserSettingsManager> _instance =
            new Lazy<UserSettingsManager>(() => new UserSettingsManager());
        public static UserSettingsManager UserSettings { get; set; } = _instance.Value;
        private string RepositoriesSettingFile { get; } = "AnalogyGitHistory.Settings";
        public RepositoriesSetting RepositoriesSetting { get; }

        public UserSettingsManager()
        {
            RepositoriesSetting = new RepositoriesSetting();
            if (File.Exists(RepositoriesSettingFile))
            {
                try
                {
                    string data = File.ReadAllText(RepositoriesSettingFile);
                    RepositoriesSetting = JsonConvert.DeserializeObject<RepositoriesSetting>(data);
                }
                catch (Exception ex)
                {
                    LogManager.Instance.LogCritical("", $"Unable to read file {RepositoriesSettingFile}: {ex}");
                }
            }
        }

        public void Save()
        {
            try
            {
                File.WriteAllText(RepositoriesSettingFile, JsonConvert.SerializeObject(RepositoriesSetting));
            }
            catch (Exception ex)
            {
                LogManager.Instance.LogCritical("", $"Unable to save file {RepositoriesSettingFile}: {ex}");

            }


        }
    }
}
