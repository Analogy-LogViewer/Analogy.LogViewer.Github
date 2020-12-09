using System;
using Analogy.LogViewer.Github.Data_Types;
using System.Collections.Generic;

namespace Analogy.LogViewer.Github
{

    public class GithubSettings
    {
        public string GitHubToken { get; } = Environment.GetEnvironmentVariable("GitHubNotifier_Token");
        public List<RepositorySettings> Repositories { get; set; }

        public GithubSettings()
        {
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
