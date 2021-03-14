using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NUMC.Expansion;

namespace NUMC.Client
{
    public static class APIClient
    {
        private static HttpClient _client;
        private static HttpClient Client {
            get {
                _client = _client ?? (_client = new HttpClient());
                var userAgent = _client.DefaultRequestHeaders.UserAgent;
                foreach (var item in userAgent)
                    if(item?.Product?.Name == "request")
                        return _client;
                _client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
                return _client;
            }
        }

        public static async Task<T> GetHttpApiJsonObject<T>(string url) =>
            Json.Json.Convert<T>(await Client.GetStringAsync(url));

        public static HttpClient GetHttpClient() => Client;
    }
}
