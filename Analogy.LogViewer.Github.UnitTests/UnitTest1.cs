using Analogy.CommonUtilities.Github;
using Analogy.Interfaces;
using Analogy.LogViewer.Github.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Analogy.LogViewer.Github.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            //string uri = @"https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer";
            //string data = await Utils.GetAsync(uri);
            ////var dictionary = JsonConvert.DeserializeObject(data);
            //AnalogyLogMessage m = new AnalogyLogMessage();
            //m.Text = data;
            //m.Level = AnalogyLogLevel.Information;
            //m.Source = uri;

            //string repo = await Utils.GetAsync(uri);
            //var repoInfo = JsonConvert.DeserializeObject<GithubRepo>(repo);

            //string releases = await Utils.GetAsync(uri + "/releases");
            //var r = JsonConvert.DeserializeObject<GithubReleaseEntry[]>(releases);
        }
    }
}