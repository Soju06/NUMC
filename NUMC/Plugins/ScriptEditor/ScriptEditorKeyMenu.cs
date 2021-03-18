using NUMC.Config.Object;
using System;
using System.Windows.Forms;

namespace NUMC.Plugins.ScriptEditor {
    public class ScriptEditorKeyMenu : Plugin.Menu.IKeyMenu {
        public ScriptEditorKeyMenu() =>
            _menus = new [] { 
                _menu = new ToolStripMenuItem(Language.Language.ScriptEditor_Menu_Text, null, Click) 
            };

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
        private Service Service;

        public void Click(object sender, EventArgs e) {
            using ScriptEditorDialog dialog = new ScriptEditorDialog(KeyObject, Service.GetScript());
            if (dialog.ShowDialog() == DialogResult.OK)
                Service.GetService()?.Save();
        }

        public void Dispose() => Menu.MenuStripSupport.DisposeItems(Menus);

        public void Initialize(Service service) => Service = service;

        public void MenuClicking(KeyObject keyObject, Keys selectedKey)
        {
            var v = keyObject?.Scripts?.Count;
            _menu.Checked = v != null && v.Value > 0;
            KeyObject = keyObject;
        }
    }
}
