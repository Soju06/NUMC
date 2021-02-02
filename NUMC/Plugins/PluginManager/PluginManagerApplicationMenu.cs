using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUMC.Plugins.PluginManager
{
    public class PluginManagerApplicationMenu : Plugin.Menu.IApplicationMenu
    {
        private readonly ToolStripItem[] _menus;
        private readonly ToolStripMenuItem pmItem;

        public PluginManagerApplicationMenu()
        {
            var items = new List<ToolStripItem>();
            (pmItem = Menu.MenuStripSupport.AddMenuItem(items, Language.Language.PluginManager_Menu_Text, "pm"))
                .Click += ApplicationMenu_Click;
            _menus = items.ToArray();
        }

        private void ApplicationMenu_Click(object sender, EventArgs e)
        {
            if(((sender as ToolStripMenuItem)?.Tag as string) == "pm")
                using (var pmd = new PluginManagerDialog())
                    pmd.ShowDialog();
        }

        public int Index => 10;

        public ToolStripItem[] Menus { get { pmItem.Text = Language.Language.PluginManager_Menu_Text; return _menus; } }

        public void Dispose() => Menu.MenuStripSupport.DisposeItems(_menus);

        public void Initialize(Script.Script script) { }

        public void MenuClicking() { }
    }
}
