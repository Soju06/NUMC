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
    public class CustomKey : IMM
    {
        public CustomKey()
        {
            Item = new ToolStripMenuItem()
            {
                Text = Language.Language.Main_CustomKey
            };

            Item.Click += Item_Click;
        }

        private readonly ToolStripMenuItem Item;
        private KeyObject KeyObject;

        public ToolStripItem[] Menus
        {
            get
            {
                Item.Text = Language.Language.Main_CustomKey;

                return new ToolStripItem[] { Item };
            }
        }

        public void MenuClicking(KeyObject keyObject, Keys selectedKey)
        {
            KeyObject = keyObject;
            Item.Checked =
            keyObject.KeyScript != null &&
            keyObject.KeyScript.Length >= 1 &&
            (keyObject.KeyScript[0].SendKeys != null ||
            keyObject.KeyScript[0].VirtualKey != null);
        }

        private void Item_Click(object sender, EventArgs e)
        {
            KeyScript keyScript;

            if (KeyObject != null && KeyObject.KeyScript != null && KeyObject.KeyScript.Length >= 1)
                keyScript = KeyObject.KeyScript[0];
            else
                keyScript = (KeyObject.KeyScript = new KeyScript[] { new KeyScript() })[0];

            using (CustomKeyDialog customKey = new CustomKeyDialog(keyScript))
            {
                if (customKey.ShowDialog() == DialogResult.OK)
                {
                    // 확인
                }
            }
        }
    }
}
