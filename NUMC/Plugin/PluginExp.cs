using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUMC.Plugin
{
    public static class PluginExp
    {
        public static void PluginExpInitialize(IList plugins, Script.Script script)
        {
            if (plugins == null)
                return;

            var exp = typeof(IPluginExp);
            var initializeMember = exp.GetMethod("Initialize", BindingFlags.Instance | BindingFlags.Public | BindingFlags.InvokeMethod);

            if (initializeMember == null)
            {
                Debug.WriteLine("initialize member is null");
                return;
            }

            var parms = new object[] { script };

            for (int i = 0; i < plugins.Count; i++)
                try {
                    var plugin = plugins[i];
                    Type plType;

                    if (plugin == null || (plType = plugin.GetType()).GetInterface(exp.Name) != exp)
                        continue;

                    initializeMember.Invoke(plugin, parms);
                } catch (Exception ex) {
                    PluginExpInitializeException(ex, plugins[i]);
                }
        }

        public static void PluginExpInitialize(IList<IPluginExp> plugins, Script.Script script)
        {
            if (plugins == null)
                return;

            for (int i = 0; i < plugins.Count; i++)
                try {
                    if (plugins[i] == null)
                        continue;

                    plugins[i].Initialize(script);
                } catch (Exception ex) {
                    PluginExpInitializeException(ex, plugins[i]);
                }
        }

        private static void PluginExpInitializeException(Exception ex, object obj) =>
                    Plugin.PluginException(ex, obj?.GetType(), "PluginExp initialize failed", "PluginExp");
    }
}
