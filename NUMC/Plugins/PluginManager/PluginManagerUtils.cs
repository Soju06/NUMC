using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using NUMC.Expansion;
using NUMC.Client.NUMC;
using NUMC.Client;
using System.Drawing;
using System.Drawing.Imaging;

namespace NUMC.Plugins.PluginManager
{
    public class PluginManagerUtils
    {
        public static string GetArchiveURL(string src, string name, string store = null)
        {
            if (store == null) {
                var t = Task.Run(async () => { return await Client.NUMC.PluginManager.GetProxyStoreRedirectUrl(); });
                t.Wait(); store = t.Result;
            }
            var version = Constant.Verison;
            var loc = store;
            for (int i = 0; i < 2; i++)
                loc = loc.Substring(0, loc.LastIndexOf('/'));
            return src.Replace("{/loc}", loc).Replace("{/version}", version).Replace("{/plugin_name}", name);
        }

        public static List<Client.NUMC.PluginManager.Plugin> GetInstalledPlugins()
        {
            var assemblies = Plugin.Plugin.GetAssemblies();
            var plugins = new List<Client.NUMC.PluginManager.Plugin>();
            for (int i = 0; i < assemblies.Count; i++) {
                var assembly = assemblies[i];
                var assemblyName = assembly?.GetName();
                if (assembly == null || assemblyName == null) continue;
                var r = new Client.NUMC.PluginManager.Plugin() { 
                    Title = assembly.GetTitleAttribute()?.Title,
                    Version = assemblyName.Version?.ToString(),
                    Overview = assembly.GetDescriptionAttribute()?.Description,
                    Hash = GetAssemblyHash(assembly), Size = -1,
                    Publisher = assembly.GetCompanyAttribute()?.Company
                };
                if(File.Exists(assembly.Location)) {
                    var file = new FileInfo(assembly.Location);
                    r.Name = file.Name; r.Size = file.Length;
                    using(var ms = new MemoryStream()) {
                        using(var icon = Icon.ExtractAssociatedIcon(file.FullName))
                        using (var image = icon.ToBitmap()) image.Save(ms, ImageFormat.Png);
                        r.ImageURL = "base64:" + Convert.ToBase64String(ms.ToArray());
                    }
                }
                Debug.WriteLine($"plugin info\tt: {r.Title}\tv: {r.Version}\to: {r.Overview}\th: {r.Hash}\tp: {r.Publisher}");
                plugins.Add(r);
            } return plugins;
        }

        public static Assembly IsInstalled(string base64Hash)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            for (int i = 0; i < assemblies.Length; i++) {
                if (GetAssemblyHash(assemblies[i]) == base64Hash)
                    return assemblies[i];
            } return null;
        }

        public static string GetAssemblyHash(Assembly assembly) =>
            assembly == null ? null : Convert.ToBase64String(new Hash(assembly).SHA256);
    }
}
