using NUMC.Expansion;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUMC.Plugin
{
    public static class Extract
    {
        private static DirectoryInfo _pluginDirectory = new DirectoryInfo(Path.Combine(Application.StartupPath, "Plugin"));
        public static DirectoryInfo PluginDirectory {
            get {
                if (_pluginDirectory == null) _pluginDirectory = new DirectoryInfo(
                     Path.Combine(Application.StartupPath, "Plugin"));
                if (!_pluginDirectory.Exists) _pluginDirectory.Create();
                return _pluginDirectory;
            }
            set { 
                _pluginDirectory = value; var _ = PluginDirectory; 
            }
        }

        public static List<TypeContainer> GetPluginContainers(IList<Assembly> assemblies) =>
            GetPluginContainers(assemblies, GetPluginInterfaces(Assembly.GetExecutingAssembly(), typeof(IPlugin), true));

        public static List<TypeContainer> GetPluginContainers(IList<Assembly> assemblies, IList<Type> pluginTypes)
        {
            var containers = new List<TypeContainer>();
            var types = GetPluginContainer(assemblies, null).Types;
            for (int i = 0; i < pluginTypes.Count; i++)
                containers.Add(new TypeContainer(pluginTypes[i], GetPluginInterfaces(types, pluginTypes[i], false).ToArray()));
            return containers;
        }

        public static TypeContainer GetPluginContainer(IList<Assembly> assemblies, Type pluginType)
        {
            var types = new List<Type>();

            for (int i = 0; i < assemblies.Count; i++)
                types.AddRange(GetPluginInterfaces(assemblies[i], pluginType, false));

            return new TypeContainer(pluginType, types.ToArray());
        }

        public static List<Type> GetPluginInterfaces<T>(Assembly assembly, bool onlyInterface = false) =>
            GetPluginInterfaces(assembly, typeof(T), onlyInterface);

        public static List<Type> GetPluginInterfaces(Assembly assembly, Type pluginType, bool onlyInterface = false)
        {
            try {
                return GetPluginInterfaces(assembly.GetExportedTypes(), pluginType, onlyInterface);
            } catch (Exception ex) {
                PluginLoadFailedMessageBoxShow(assembly.FullName, ex);
            } return Array.Empty<Type>().ToList();
        }

        public static List<Type> GetPluginInterfaces(IList<Type> types, Type pluginType, bool onlyInterface = false)
        {
            var items = new List<Type>();
            try {
                if(types != null) {
                    if (pluginType == null) return types.ToList();
                    for (int i = 0; i < types.Count; i++)
                        if (types[i].GetInterface(pluginType.Name) == pluginType &&
                            (onlyInterface && types[i].IsInterface || (!onlyInterface && !types[i].IsInterface)))
                            items.Add(types[i]);
                }
            } catch (Exception ex) {
                PluginLoadFailedMessageBoxShow(pluginType?.Name, ex);
            } return items;
        }

        public static List<Assembly> GetPluginAssemblies()
        {
            var pluginFiles = GetPlugins();
            var assemblies = new List<Assembly>() {
                Assembly.GetExecutingAssembly()
            };

            for (int i = 0; i < pluginFiles.Length; i++)
                try {
                    assemblies.Add(Assembly.LoadFile(pluginFiles[i].FullName));
                } catch (Exception ex) {
                    PluginLoadFailedMessageBoxShow(pluginFiles[i].FullName, ex);
                }

            return assemblies;
        }

        public static FileInfo[] GetPlugins()
        {
            if (PluginDirectory == null ||!PluginDirectory.Exists)
                return Array.Empty<FileInfo>();

            return PluginDirectory.GetFiles("*.dll");
        }

        public static void PluginLoadFailedMessageBoxShow(string pluginName, Exception exception)
        {
            MessageBox.Show($"Plugin load failed!\nAssemblyName:{pluginName}\n{exception}", "Plugin Extract", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
