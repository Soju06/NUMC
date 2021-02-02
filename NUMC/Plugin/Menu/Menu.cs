using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUMC.Plugin.Menu
{
    public static class Menu
    {
        public static ToolStripItem[] InitializeMenuAndGetMenuItems(IList plugins, Script.Script script)
        {
            if (plugins == null && plugins.Count > 0)
                return null;

            PluginExp.PluginExpInitialize(plugins, script);

            return GetMenusItems(plugins);
        }

        public static ToolStripItem[] GetMenusItems(IList plugins)
        {
            var menus = new List<ToolStripItem>();

            if (plugins != null)
                for (int i = 0; i < plugins.Count; i++)
                {
                    var items = GetMenuItems(plugins[i] as IMenu);

                    if(items != null)
                        menus.AddRange(items);
                }

            return menus.ToArray();
        }


        public static ToolStripItem[] GetMenuItems(IMenu plugin)
        {
            if(plugin != null)
                try {
                    return plugin.Menus;
                } catch (Exception ex) {
                    Plugin.PluginException(ex, plugin.GetType(), "IMenu get Menus failed", "Menu");
                }

            return null;
        }
    }
}
