using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NUMC.Client.GitHub
{
    public static class GitHub
    {
        public const string API_Url = "api.github.com";
        public const string Owner = "Soju06";
        public const string NUMCRepositoriesName = "NUMC";
        public const string NUMCPluginManagerRepositoriesName = "NUMC.Plugin";

        public static readonly string Repositories = $"{Uri.UriSchemeHttps}{Uri.SchemeDelimiter}{API_Url}/repos/{Owner}";
        public static readonly string NUMCRepositories = $"{Repositories}/{NUMCRepositoriesName}";
        public static readonly string PluginManagerRepositories = $"{Repositories}/{NUMCPluginManagerRepositoriesName}";
    }

    public class Object<T>
    {
        public HttpResponseMessage ResponseMessage { get; set; }
        public T ResponseObject { get; set; }
    }
}
