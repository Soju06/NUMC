using NUMC.Menu;
using NUMC.Script;
using System;
using System.Windows.Forms;

namespace TestPlugin
{
    public class Asdf : IKeyMenuModule
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

        public ToolStripItem[] Menus
        {
            get
            {
                return new ToolStripItem[] { Item };
            }
        }

        public int Index => 5;

        public void MenuClicking(KeyObject keyObject, Keys selectedKey)
        {
            Console.WriteLine("asdsadasdasd");
        }

        private void Item_Click(object sender, EventArgs e)
        {
            Console.WriteLine("asdasdasdasdasdasdasasdasdasdas");
        }
    }
}