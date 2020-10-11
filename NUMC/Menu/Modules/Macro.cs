using NUMC.Script;
using System;
using System.Windows.Forms;

namespace NUMC.Menu.Modules
{
    public class Macro : IMenuModule
    {
        public Macro()
        {
            Item = new ToolStripMenuItem()
            {
                Text = Language.Language.Main_Macro
            };

            Item.Click += Item_Click;
        }

        private readonly ToolStripMenuItem Item;
        private KeyObject KeyObject;

        public ToolStripItem[] Menus
        {
            get
            {
                Item.Text = Language.Language.Main_Macro;

                return new ToolStripItem[] { Item };
            }
        }

        public void MenuClicking(KeyObject keyObject, Keys selectedKey)
        {
            KeyObject = keyObject;

            Item.Checked =
            keyObject.KeyScript != null &&
            keyObject.KeyScript.Length >= 1 &&
            keyObject.KeyScript[0] != null &&
            keyObject.KeyScript[0].Macro != null;
        }

        private void Item_Click(object sender, EventArgs e)
        {
            KeyScript keyScript;

            if (KeyObject != null && KeyObject.KeyScript != null && KeyObject.KeyScript.Length >= 1)
                keyScript = KeyObject.KeyScript[0];
            else
                keyScript = (KeyObject.KeyScript = new KeyScript[] { new KeyScript() })[0];

            using (Forms.Dialogs.Macro.MacroSettingDialog dialog = new Forms.Dialogs.Macro.MacroSettingDialog(keyScript))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }
    }
}