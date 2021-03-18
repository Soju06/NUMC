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
    public static class Plugin
    {
        public static List<Container> _containers;
        public static List<TypeContainer> _typeContainers;
        public static List<Assembly> _assemblies;

        public static bool Initializing { get; private set; } = false;
        public static bool Initialized { get; private set; } = false;

        public static void Initialize()
        {
            if (Initializing)
                return;

            Initializing = true;
            Initialized = false;

            Debug.WriteLine("plugin initializing...");

            _assemblies = Extract.GetPluginAssemblies();
            _typeContainers = Extract.GetPluginContainers(_assemblies);
            _containers = new List<Container>();

            for (int i = 0; i < _typeContainers.Count; i++)
                _containers.Add(Container.CreateContainer(_typeContainers[i]));

            Debug.WriteLine("plugin initialized.");

            Initialized = true;
        }

        public static void DisposeAll()
        {
            if(_containers != null)
            {
                for (int i = 0; i < _containers.Count; i++)
                {
                    try {
                        _containers[i].Dispose();
                    } catch (Exception ex) {
                        Debug.WriteLine("PluginContainer dispose failed!\nbt:\t{0}\tex: {1}", _containers[i]?.BaseType?.Name, ex);
                    }
                }
            }
        }

        public static List<T> ExtractPlugin<T>()
        {
            if (_containers == null)
                Initialize();

            Type type = typeof(T);

            for (int i = 0; i < _containers.Count; i++)
                if (_containers[i].BaseType == type) {
                    var a = new List<T>();

                    for (int l = 0; l < _containers[i].Plugins.Length; l++)
                        a.Add((T)_containers[i].Plugins[l]);

                    return a;
                }

            return Array.Empty<T>().ToList();
        }

        public static void PluginException(Exception ex, string pluginName, string exceptionMessage, string title = null)
        {
            Debug.WriteLine("em\t{0}\tpn:\t{1}\t\te:\t{2}", exceptionMessage, pluginName, ex);

            MessageBox.Show(string.Format(Language.Language.Message_Error_Plugin_Exception, exceptionMessage, pluginName, ex),
                title == null ? Service.TitleName : Service.GetTitleName(title), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void PluginException(Exception ex, Type pluginType, string exceptionMessage, string title = null) => 
            PluginException(ex, pluginType != null ? pluginType.Name : (ex != null ? ex.Message : "null"), exceptionMessage, title);

        public static List<Container> GetContainers() => _containers;
        public static List<TypeContainer> GetTypeContainers() => _typeContainers;
        public static List<Assembly> GetAssemblies() => _assemblies;
    }
}
