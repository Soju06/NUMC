using NUMC.Array;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
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
            var items = new List<T>();

            {
                var item = ExtractPlugin<T>(Assembly.GetExecutingAssembly());

                if (item != null)
                    items.AddRange(item);
            }
            {
                var item = ExtractPlugin<T>(GetPlugins());

                if (item != null)
                    items.AddRange(item);
            }

            if (items.Count > 1 && typeof(T).GetInterface("ISortIndex") == typeof(ISortIndex))
            {
                var ls = new List<ISortIndex>();

                for (int i = 0; i < items.Count; i++)
                    ls.Add(items[i] as ISortIndex);

                var list = ls.ToArray();

                Sort.QuickSort(list, 0, ls.Count - 1);

                var l = new List<T>();

                for (int i = 0; i < list.Length; i++)
                    l.Add((T)list[i]);

                // What should I do? 🤔

                return l.ToArray();
            }

            return items.ToArray();
        }

        public static T[] ExtractPlugin<T>(FileInfo[] plugins)
        {
            if (plugins == null)
                return null;

            var ts = new List<T>();

            for (int i = 0; i < plugins.Length; i++)
                ts.AddRange(ExtractPlugin<T>(plugins[i]));

            return ts.ToArray();
        }

        public static T[] ExtractPlugin<T>(FileInfo plugin)
        {
            if (plugin == null || !plugin.Exists)
                return null;

            try
            {
                return ExtractPlugin<T>(Assembly.LoadFile(plugin.FullName));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Plugin load failed!\nFileName:{plugin.FullName}\n{ex}", "Plugin Handler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        public static T[] ExtractPlugin<T>(Assembly assembly)
        {
            if (assembly == null)
                return null;

            Type type = typeof(T);
            var ts = new List<T>();

            Type[] types = assembly.GetExportedTypes();

            for (int i = 0; i < types.Length; i++)
                if (types[i].GetInterface(type.Name) == type)
                    ts.Add((T)Activator.CreateInstance(types[i]));

            return ts.ToArray();
        }
    }
}