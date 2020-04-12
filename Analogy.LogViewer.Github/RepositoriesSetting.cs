using System;
using System.Collections.Generic;

namespace Analogy.LogViewer.Github
{
    public class RepositoriesSetting
    {

        public List<string> Repositories { get; set; }

        public RepositoriesSetting()
        {
            Repositories = new List<string>();
        }

        public void AddRepository(string repository)
        {
            if (!Repositories.Contains(repository))
                Repositories.Add(repository);
        }
        public void DeleteRepository(string repository)
        {
            if (Repositories.Contains(repository))
                Repositories.Remove(repository);
        }

    }

    public class RepositorySetting : IEquatable<RepositorySetting>
    {
        public string RepositoryPath { get; set; }
        public int NumberOfCommits { get; set; }
        public DateTimeOffset HistoryDateTime { get; set; }

        public FetchType FetchType { get; set; }

        public RepositorySetting()
        {

        }
        public RepositorySetting(string repositoryPath, int numberOfCommits, DateTime historyDateTime, FetchType fetchType)
        {
            RepositoryPath = repositoryPath;
            NumberOfCommits = numberOfCommits;
            HistoryDateTime = historyDateTime;
            FetchType = fetchType;
        }

        public bool Equals(RepositorySetting other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return RepositoryPath == other.RepositoryPath && NumberOfCommits == other.NumberOfCommits &&
                   HistoryDateTime.Equals(other.HistoryDateTime) && FetchType == other.FetchType;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RepositorySetting)obj);
        }

        public override int GetHashCode()
        {
#if NETCOREAPP3_1
            return HashCode.Combine(RepositoryPath, NumberOfCommits, HistoryDateTime, (int) FetchType);
#else
            return (RepositoryPath.GetHashCode() * 379) + (NumberOfCommits) + (HistoryDateTime.GetHashCode() * 379);
#endif
        }

        public override string ToString() => $"{nameof(RepositoryPath)}: {RepositoryPath}, {nameof(NumberOfCommits)}: {NumberOfCommits}, {nameof(HistoryDateTime)}: {HistoryDateTime}, {nameof(FetchType)}: {FetchType}";
    }

    public enum FetchType
    {
        Count,
        DateTime,
    }
}
