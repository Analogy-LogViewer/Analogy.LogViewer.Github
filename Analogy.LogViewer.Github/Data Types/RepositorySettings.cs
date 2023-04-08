namespace Analogy.LogViewer.Github.Data_Types
{
    [Serializable]

    public class RepositorySettings
    {
        public string Owner { get; set; }
        public string RepoName { get; set; }
        public string DisplayName => $"{Owner}/{RepoName}";
        public string RepoUrl => $"https://github.com/{DisplayName}";
        public int UpdateMinutes { get; set; }
        public bool Enabled { get; set; }

        public RepositorySettings()
        {
            Enabled = true;
        }
        public RepositorySettings(string repoOwner, string repoName, int updateMinutes) : this()
        {
            Owner = repoOwner;
            RepoName = repoName;
            UpdateMinutes = updateMinutes;
        }

        public override string ToString()
        {
            return $"{nameof(RepoName)}: {RepoName}";
        }
    }
}
