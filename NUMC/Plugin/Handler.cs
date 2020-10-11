using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUMC.Plugin
{
    public static class Handler
    {
        public static DirectoryInfo PluginDirectory = new DirectoryInfo(Path.Combine(Application.StartupPath, "Plugin"));

        public static FileInfo[] GetPlugins()
        {
            if (!PluginDirectory.Exists)
                return null;

            return PluginDirectory.GetFiles("*.dll");
        }
        public static T[] ExtractPlugin<T>()
        {
            return ExtractPlugin<T>(GetPlugins());
        }

        public static T[] ExtractPlugin<T>(FileInfo[] plugins)
        {
            if (plugins == null)
                return null;

            List<T> ts = new List<T>();

            for (int i = 0; i < plugins.Length; i++)
            {
                ts.AddRange(ExtractPlugin<T>(plugins[i]));
            }

            return ts.ToArray();
        }

        public static T[] ExtractPlugin<T>(FileInfo plugin)
        {
            if (plugin == null || !plugin.Exists)
                return null;

            Type type = typeof(T);
            List<T> ts = new List<T>();
            try
            {
                Assembly assembly = Assembly.LoadFile(plugin.FullName);
                Type[] types = assembly.GetExportedTypes();

                for (int i = 0; i < types.Length; i++)
                    if (types[i].GetInterface(type.Name) == type)
                        ts.Add((T)Activator.CreateInstance(types[i]));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Plugin load failed!\nFileName:{plugin.FullName}\n{ex}", "Plugin Handler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ts.ToArray();
        }
    }
}
