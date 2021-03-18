using NUMC.Client.GitHub;
using NUMC.Config;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NUMC.Client.NUMC
{
    public static class PluginManager
    {
        public static async Task<string> GetProxyStoreRedirectUrl()
        {
            try {
                var client = APIClient.GetHttpClient();
                return (await client.GetStringAsync(NUMC.NUMCStoreAPIPorxy)).Replace("{/version}", Constant.Verison);
            } catch (Exception ex) {
                Debug.WriteLine("get proxy store redirect url failed\tex:\t{0}", ex);
            } return null;
        }

        public static async Task<Object<Store>> GetStoreAsync(string host)
        {
            try {
                var client = APIClient.GetHttpClient();
                var response = await client.GetAsync(host);
                var store = response.StatusCode == System.Net.HttpStatusCode.OK ?
                Json.JsonSerializer.Convert<Store>(await response.Content.ReadAsStringAsync()) : null;
                return new Object<Store>() { ResponseMessage = response, ResponseObject = store };
            } catch (Exception ex) {
                Debug.WriteLine("get plugin store failed\th:\t{0}\tex:\t{1}", host, ex);
            } return null;
        }

        public static async Task<Object<Store>> GetProxyStoreAsync()
        {
            try {
                var h = await GetProxyStoreRedirectUrl();
                if (string.IsNullOrWhiteSpace(h)) return null;
                return await GetStoreAsync(h);
            } catch (Exception ex) {
                Debug.WriteLine("get proxy plugin store failed\tex:\t{0}", ex);
                return null;
            }
        }

        [DataContract]
        public class Store
        {
            [DataMember(Name = "archive_url")]
            public string Archive_URL { get; set; }
            [DataMember(Name = "plugins")]
            public List<Plugin> Plugins { get; set; }
        }
        
        [DataContract]
        public class Plugin
        {
            [DataMember(Name = "name")]
            public string Name { get; set; }
            [DataMember(Name = "title")]
            public string Title { get; set; }
            [DataMember(Name = "version")]
            public string Version { get; set; }
            [DataMember(Name = "overview")]
            public string Overview { get; set; }
            [DataMember(Name = "publisher")]
            public string Publisher { get; set; }
            [DataMember(Name = "image_url")]
            public string ImageURL { get; set; }
            [DataMember(Name = "size")]
            public long Size { get; set; }
            [DataMember(Name = "hash")]
            public string Hash { get; set; }
        }
    }
}
