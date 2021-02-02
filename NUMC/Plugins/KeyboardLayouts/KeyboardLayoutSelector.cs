using NUMC.Plugin.KeyboardLayout;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUMC.Plugins.KeyboardLayouts
{
    public class KeyboardLayoutSelector : Plugin.Menu.IApplicationMenu
    {
        public int Index => 20;

        public ToolStripItem[] Menus 
        {
            get {
                Menu.MenuStripSupport.DisposeItems(_menus);
                Menu.MenuStripSupport.DisposeItem(_rootMenu);

                var menus = new List<ToolStripItem>();
                var rootMenu = new ToolStripMenuItem("Keyboard Layouts");
                var layouts = Plugin.Plugin.ExtractPlugin<IKeyboardLayout>();


                if (layouts != null) {
                    for (int i = 0; i < layouts.Count; i++) {
                        var layout = layouts[i];
                        
                        if (layout == null)
                            continue;

                        try {
                            Menu.MenuStripSupport.AddMenuItem(menus, layout.Name, layout);
                        } catch (Exception ex) {
                            Plugin.Plugin.PluginException(ex, layout.GetType(), "", "KeyboardLayoutSelector");
                        }
                    }

                    Menu.MenuStripSupport.AddClickEventSubItemsAdding(rootMenu, menus, Menu_Click);
                }

                _menus = menus;
                _rootMenu = rootMenu;

                return new ToolStripItem[] { _rootMenu };
            }
        }

        private List<ToolStripItem> _menus;
        private ToolStripMenuItem _rootMenu;

        private void Menu_Click(object sender, EventArgs e)
        {
            if (sender.GetType() != typeof(ToolStripMenuItem))
                return;

            var menu = sender as ToolStripMenuItem;
            var keyboardLayout = Service.GetService().GetMain().GetKeyboardLayout();
            var menuKeyboardLayout = menu.Tag as IKeyboardLayout;

            if (keyboardLayout.KeyboardLayout != menuKeyboardLayout)
                keyboardLayout.KeyboardLayout = menuKeyboardLayout;
        }

        public void Dispose()
        {
            Menu.MenuStripSupport.DisposeItems(_menus);
            Menu.MenuStripSupport.DisposeItem(_rootMenu);
        }

        public void Initialize(Script.Script script) { }

        public void MenuClicking()
        {
            var keyboardLayout = Service.GetService()?.GetMain()?.GetKeyboardLayout()?.KeyboardLayout;
            var keyboardLayoutType = keyboardLayout?.GetType();

            for (int i = 0; i < _menus.Count; i++)
            {
                var menu = _menus[i];

                if (menu?.Tag == null)
                    continue;

                (menu as ToolStripMenuItem).Checked = menu?.Tag?.GetType() == keyboardLayoutType;
            }
        }
    }
}
