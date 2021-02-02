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
    public class Container : IDisposable
    {
        public Container(Type baseType, IPlugin[] plugins)
        {
            BaseType = baseType;
            Plugins = plugins;
        }

        public IPlugin[] Plugins { get; private set; }
        public Type BaseType { get; private set; }

        public static Container CreateContainer(TypeContainer typeContainer)
        {
            var l = new List<IPlugin>();

            for (int i = 0; i < typeContainer.Types.Length; i++)
                if (Activator.CreateInstance(typeContainer.Types[i]) is IPlugin f) l.Add(f);

            var k = l.Cast<ISortIndex>().ToList();
            k.QuickSort(0, l.Count - 1);
            return new Container(typeContainer.BaseType, k.Cast<IPlugin>().ToArray());
        }

        public void Dispose()
        {
            if(Plugins != null) {
                for (int i = 0; i < Plugins.Length; i++) {
                    if (Plugins[i] == null)
                        continue;

                    try {
                        Plugins[i].Dispose();
                    } catch (Exception ex) {
                        Debug.WriteLine("plugin dispose failed!\npn:\t{0}\tex: {1}", Plugins[i].GetType().Name, ex);
                    }
                }
            }
        }
    }

    public class TypeContainer
    {
        public TypeContainer(Type baseType, Type[] types) {
            BaseType = baseType;
            Types = types;
        }

        public Type[] Types { get; private set; }
        public Type BaseType { get; private set; }
    }
}