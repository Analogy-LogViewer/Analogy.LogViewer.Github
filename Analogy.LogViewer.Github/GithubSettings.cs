using Analogy.LogViewer.Github.DataTypes;
using System.Runtime.Serialization;

namespace Analogy.LogViewer.Github
{

    public class GithubSettings
    {
        public string RegistryGitHubToken { get; set; } = Environment.GetEnvironmentVariable("Analogy.LogViewer.Github_Token");
        public string LocalGitHubToken { get; set; }
        public string GitHubToken => string.IsNullOrEmpty(LocalGitHubToken) ? RegistryGitHubToken : LocalGitHubToken;

        public List<RepositorySettings> Repositories { get; set; }
        public int GitHubNotificationIntervalMilliseconds { get; set; } = 15 * 60 * 1000;
        public DateTime LastReadUserNotification { get; set; }
        public GithubSettings()
        {
            LastReadUserNotification = DateTime.MinValue;
            Repositories = new List<RepositorySettings>();
        }

        public void AddRepository(RepositorySettings repository)
        {
            if (!Repositories.Contains(repository))
            {
                Repositories.Add(repository);
            }
        }
        public void DeleteRepository(RepositorySettings repository)
        {
            if (Repositories.Contains(repository))
            {
                Repositories.Remove(repository);
            }
        }


    }
}
