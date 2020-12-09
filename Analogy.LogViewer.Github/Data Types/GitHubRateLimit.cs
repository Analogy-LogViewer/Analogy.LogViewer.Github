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
    public class GitHubRateLimit
    {
        [JsonProperty("resources")] public GitHubResources Resources { get; set; }
        [JsonProperty("rate")] public RateLimit Rate { get; set; }
    }
}
