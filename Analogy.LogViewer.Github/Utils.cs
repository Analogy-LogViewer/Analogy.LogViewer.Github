using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Analogy.LogViewer.Github
{
    public static class Utils
    {
        public static async Task<(bool newData, T result)> GetAsync<T>(string uri, string token, DateTime lastModified)
        {
            try
            {
                Uri myUri = new Uri(uri);
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(myUri);
                myHttpWebRequest.Accept = "application/json";
                myHttpWebRequest.UserAgent = "Analogy>LogViewer.Github";
                if (!string.IsNullOrEmpty(token))
                    myHttpWebRequest.Headers.Add(HttpRequestHeader.Authorization, $"Token {token}");

                myHttpWebRequest.IfModifiedSince = lastModified;

                HttpWebResponse myHttpWebResponse = (HttpWebResponse)await myHttpWebRequest.GetResponseAsync();
                if (myHttpWebResponse.StatusCode == HttpStatusCode.NotModified)
                    return (false, default);

                using (var reader = new System.IO.StreamReader(myHttpWebResponse.GetResponseStream()))
                {
                    string responseText = await reader.ReadToEndAsync();
                    return (true, JsonConvert.DeserializeObject<T>(responseText));
                }
            }
            catch (WebException e) when (((HttpWebResponse)e.Response).StatusCode == HttpStatusCode.NotModified)
            {
                return (false, default);
            }
        }



    }
}
