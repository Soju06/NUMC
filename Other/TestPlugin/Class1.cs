using NUMC.Plugin.Menu;
using NUMC.Script;
using System;
using System.Windows.Forms;

namespace TestPlugin
{
    public class Asdf : IApplicationMenu
    {
        public Asdf()
        {
            Item = new ToolStripMenuItem()
            {
                Text = "sdadsa"
            };

            Item.Click += Item_Click;
        }

        private readonly ToolStripMenuItem Item;

        public ToolStripItem[] Menus => new ToolStripItem[] { Item };

        public int Index => 5;
        
        private void Item_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void Dispose()
        {

        }

        public void MenuClicking()
        {

        }

        public void Initialize(Script script)
        {

        }
    }
}