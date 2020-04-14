using System.Net.Http;
using System.Threading.Tasks;

namespace Analogy.LogViewer.Github
{
    public static class Utils
    {
        public static async Task<string> GetAsync(string uri)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.UserAgent.TryParseAdd("Analogy");//Set the User Agent to "request"
                using (HttpResponseMessage response = await client.GetAsync(uri))
                {
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync();
                }
            }

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            ////Get the headers associated with the request.
            //request.Headers[HttpRequestHeader.UserAgent] = "Analogy";
            //request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            //using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            //using (Stream stream = response.GetResponseStream())
            //using (StreamReader reader = new StreamReader(stream))
            //{
            //    return await reader.ReadToEndAsync();
            //}
        }
    }
}
