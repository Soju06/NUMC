using NUMC.Plugin.Menu;
using NUMC.Script;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TestPlugin
{
    public class Asdf : IApplicationMenu
    {
        public Asdf()
        {
            var items = new List<ToolStripItem>();
            NUMC.Menu.MenuStripSupport.AddMenuItem(items, "asdf", "asd").Click += Item_Click;
            NUMC.Menu.MenuStripSupport.AddMenuItem(items, "dasdf", "asd").Click += Asdf_Click;
            Menus = items.ToArray();
        }

        private void Asdf_Click(object sender, EventArgs e)
        {
            NUMC.Plugin.Plugin.Initialize();
        }

        public ToolStripItem[] Menus { get; private set; }

        public int Index => 5;
        
        private void Item_Click(object sender, EventArgs e)
        {
            NUMC.Plugin.Plugin.DisposeAll();
        }

        public void Dispose()
        {

        }

        public void MenuClicking()
        {

        }

        public void Initialize(NUMC.Service service)
        {

        }
    }
}