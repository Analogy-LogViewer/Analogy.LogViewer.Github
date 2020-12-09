using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Analogy.LogViewer.Github.Data_Types
{
    [Serializable]
    [JsonObject]
    public class GitHubResources
    {
        [JsonProperty("core")] public RateLimit Core { get; set; }
        [JsonProperty("graphql")] public RateLimit Graphql { get; set; }
        [JsonProperty("integration_manifest")] public RateLimit IntegrationManifest { get; set; }
        [JsonProperty("search")] public RateLimit Search { get; set; }
    }

    [Serializable]
    [JsonObject]
    public class RateLimit
    {
        [JsonProperty("limit")] public int Limit { get; set; }
        [JsonProperty("remaining")] public int Remaining { get; set; }
        [JsonProperty("reset")] public int Reset { get; set; }
        public DateTime ResetTime => DateTimeOffset.FromUnixTimeSeconds(Reset).ToLocalTime().DateTime;

        public override string ToString()
        {
            return $"remaining: {Remaining}/{Limit}. Reset at: {ResetTime}";
        }
    }
}
