using Analogy.LogViewer.Github.Data_Types;
using System;
using System.Collections.Generic;

namespace Analogy.LogViewer.Github
{

    public class GithubSettings
    {
        public string GitHubToken { get; } = Environment.GetEnvironmentVariable("GitHubNotifier_Token");
        public List<RepositorySettings> Repositories { get; set; }
        public int GitHubNotificationIntervalMilliseconds { get; set; } = 15 * 60 * 1000;
        public DateTime LastReadUserNotification { get; set; }
        public List<GitHubUserNotification> LastUnReadUserNotifications { get; set; }
        public GithubSettings()
        {
            LastReadUserNotification = DateTime.MinValue;
            LastUnReadUserNotifications=new List<GitHubUserNotification>();
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
