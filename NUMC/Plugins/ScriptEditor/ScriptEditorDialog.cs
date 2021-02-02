using NUMC.Plugin.Runtime;
using NUMC.Script;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUMC.Menu;
using NUMC.Expansion;
using System.Windows.Forms;
using NUMC.Design.Controls;

namespace NUMC.Plugins.ScriptEditor
{
    public partial class ScriptEditorDialog : Design.Dialog, IScriptEditor
    {
        private readonly KeyObject KeyObject;
        private readonly KeyObject _ori_keyObject;
        private readonly Script.Script Script;

        private IRuntimeMenu[] _runtimeMenus;
        private ToolStripMenuItem _removeMenu;
        private ToolStripSeparator _separatorMenu;
        private IListViewItem _selectedItem;

        public ScriptEditorDialog(KeyObject keyObject, Script.Script script)
        {
            _ori_keyObject = keyObject;
            KeyObject = keyObject.Clone();
            Script = script;

            InitializeComponent();
            InitializeForm();
            InitializeMenu();
            RefreshView();
        }

        private void InitializeForm()
        {
            Text = Setting.Setting.GetTitleName("Script editor");
            btnOk.Click += BtnOk_Click;
        }

        private void InitializeMenu()
        {
            var menus = new List<ToolStripItem>();
            var runtimes = Script.GetRuntimes();
            var runtimeMenus = new List<IRuntimeMenu>();

            for (int i = 0; i < runtimes.Count; i++)
            {
                IRuntimeMenu runtimeMenu;

                if (runtimes[i] == null || (runtimeMenu = runtimes[i].Menu) == null)
                    continue;

                try {
                    menus.AddRange(runtimeMenu.Menus);
                    runtimeMenus.Add(runtimeMenu);
                } catch (Exception ex) {
                    Plugin.Plugin.PluginException(ex, runtimeMenu.GetType().Name, "IRuntimeMenu get Menus failed", "Script Editor");
                }
            }

            _runtimeMenus = runtimeMenus.ToArray();
            _separatorMenu = MenuStripSupport.AddSeparator(menus);
            (_removeMenu = MenuStripSupport.AddMenuItem(menus, Language.Language.Program_Remove_Button, "remove")).Click += Remove_Click;

            contextMenuStrip.Items.AddRange(menus.ToArray());
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if (KeyObject == null || KeyObject.Script == null || KeyObject.Script.Scripts == null)
                return;

            var f = SelectedItemIndex;

            if (f >= 0) {
                var item = scriptsView.Items[f];

                if (item.Tag != null && item.Tag.GetType() == typeof(RuntimeScript))
                    KeyObject.Script.Scripts.Remove((RuntimeScript)item.Tag);

                scriptsView.Items.Remove(item);
            }
        }

        private void ScriptsView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                ShowContextMenu();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (_ori_keyObject.Script == null || _ori_keyObject.Script.Scripts == null)
                return;

            var scripts = new List<RuntimeScript>();
            var type = typeof(RuntimeScript);

            for (int i = 0; i < scriptsView.Items.Count; i++)
            {
                var item = scriptsView.Items[i];

                if (item.Tag != null && item.Tag.GetType() == type)
                    scripts.Add((RuntimeScript)item.Tag);
            }

            _ori_keyObject.Paste(KeyObject);
        }

        public void RefreshView()
        {
            if (KeyObject == null || KeyObject.Script == null || KeyObject.Script.Scripts == null)
                return;

            scriptsView.Items.Clear();

            var scripts = KeyObject.Script.Scripts;

            for (int i = 0; i < scripts.Count; i++)
            {
                var script = scripts[i];

                if (script == null)
                    continue;

                var content = Script.ScriptContent(script, KeyObject);

                if (content == null)
                    continue;

                var item = new Design.Controls.ListViewItem()
                {
                    Text = content,
                    Tag = script
                };

                scriptsView.Items.Add(item);
            }
        }

        private void ShowContextMenu()
        {
            var f = SelectedItemIndex;
            var e = f != -1;

            _separatorMenu.Visible = e;
            _removeMenu.Visible = e;

            if (e)
            {
                if (f >= scriptsView.Items.Count)
                    return;

                _selectedItem = scriptsView.Items[f];
            }
            else
                _selectedItem = null;

            for (int i = 0; i < _runtimeMenus.Length; i++)
            {
                try {
                    _runtimeMenus[i].MenuClicking(this, _selectedItem, _selectedItem == null ? null : (RuntimeScript)_selectedItem.Tag, KeyObject);
                } catch (Exception ex) { 
                    Plugin.Plugin.PluginException(ex, _runtimeMenus.GetType(), "IRuntimeMenu MenuClicking invoke failed", "Script Editor");
                }
            }

            contextMenuStrip.Show(MousePosition);
        }

        private bool SelectedItem { get => scriptsView.SelectedIndices.Count == 1; }
        private int SelectedItemIndex { get => SelectedItem ? scriptsView.SelectedIndices[0] : -1; }

        private void ScriptsView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && SelectedItem)
                Remove_Click(null, null);
            else if (e.KeyCode == Keys.Apps)
                ShowContextMenu();
        }

        public IListViewItem GetSelectedItem() =>
            scriptsView?.Items?.TryGetValue(SelectedItemIndex);
    }
}
