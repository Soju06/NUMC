using NUMC.Design.Bright;
using NUMC.Forms.Dialogs;
using NUMC.Script;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUMC.Menu.Modules
{
    public class KeyIgnore : IMM
    {
        public KeyIgnore()
        {
            Item = new ToolStripMenuItem()
            {
                Text = Language.Language.Main_KeyIgnore
            };
            Item1 = new ToolStripSeparator();
            Item2 = new ToolStripSeparator();

            Item.Click += Item_Click;
        }

        private readonly ToolStripMenuItem Item;
        private readonly ToolStripSeparator Item1;
        private readonly ToolStripSeparator Item2;
        private KeyObject KeyObject;

        public ToolStripItem[] Menus
        {
            get
            {
                Item.Text = Language.Language.Main_KeyIgnore;

                return new ToolStripItem[] { Item1, Item, Item2 };
            }
        }

        public void MenuClicking(KeyObject keyObject, Keys selectedKey)
        {
            KeyObject = keyObject;
            Item.Checked = keyObject.Ignore;
        }

        private void Item_Click(object sender, EventArgs e)
        {
            KeyObject.Ignore = !KeyObject.Ignore;
        }
    }
}
