using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace NUMC.Plugin {
    public static class PluginExp {
        public static void PluginExpInitialize(IList plugins, Service service) {
            if (plugins == null) return;
            for (int i = 0; i < plugins.Count; i++)
                try {
                    if (plugins[i] is not IPluginExp plugin) continue;
                    plugin.Initialize(service);
                } catch (Exception ex) {
                    PluginExpInitializeException(ex, plugins[i]);
                }
        }

        public static void PluginExpInitialize(IList<IPluginExp> plugins, Service service) {
            if (plugins == null) return;
            for (int i = 0; i < plugins.Count; i++)
                try {
                    if (plugins[i] == null)
                        continue;

                    plugins[i].Initialize(service);
                } catch (Exception ex) {
                    PluginExpInitializeException(ex, plugins[i]);
                }
        }

        private static void PluginExpInitializeException(Exception ex, object obj) =>
                    Plugin.PluginException(ex, obj?.GetType(), "PluginExp initialize failed", "PluginExp");
    }
}
