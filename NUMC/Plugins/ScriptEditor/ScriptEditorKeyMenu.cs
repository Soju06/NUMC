using NUMC.Script;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUMC.Plugins.ScriptEditor
{
    public class ScriptEditorKeyMenu : Plugin.Menu.IKeyMenu
    {
        public ScriptEditorKeyMenu()
        {
            _menus = new ToolStripItem[] { _menu = new ToolStripMenuItem(Language.Language.ScriptEditor_Menu_Text, null, Click) };
        }

        public int Index => 0;

        public ToolStripItem[] Menus {
            get {
                _menu.Text = Language.Language.ScriptEditor_Menu_Text;
                return _menus;
            }
        }

        private readonly ToolStripMenuItem _menu;
        private readonly ToolStripItem[] _menus;

        private KeyObject KeyObject;
        private Script.Script Script;

        public void Click(object sender, EventArgs e)
        {
            using (ScriptEditorDialog dialog = new ScriptEditorDialog(KeyObject, Script))
                if(dialog.ShowDialog() == DialogResult.OK)
                    Service.GetService()?.Save();
        }

        public void Dispose() => Menu.MenuStripSupport.DisposeItems(Menus);

        public void Initialize(Script.Script script) => Script = script;

        public void MenuClicking(KeyObject keyObject, Keys selectedKey)
        {
            var v = keyObject?.Scripts?.Count;
            _menu.Checked = v != null && v.Value > 0;
            KeyObject = keyObject;
        }
    }
}
