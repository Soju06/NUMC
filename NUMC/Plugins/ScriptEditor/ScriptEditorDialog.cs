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
using System.Diagnostics;

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

        public event ScriptAddingEventHandler ScriptAdding;

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
                    runtimeMenu.Initialize(this);
                } catch (Exception ex) {
                    Plugin.Plugin.PluginException(ex, runtimeMenu.GetType().Name, "IRuntimeMenu initialize failed", "Script Editor");
                }

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
            if (KeyObject == null || KeyObject.Scripts == null)
                return;

            var item = SelectedItem;

            if (item != null) {
                if (item.Tag != null && item.Tag.GetType() == typeof(RuntimeScript))
                    KeyObject.Scripts.Remove((RuntimeScript)item.Tag);

                scriptsView.Nodes.Remove(item);
            }
        }

        private void ScriptsView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                ShowContextMenu();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (_ori_keyObject.Scripts == null)
                return;

            var scripts = new List<RuntimeScript>();
            var type = typeof(RuntimeScript);

            for (int i = 0; i < scriptsView.Nodes.Count; i++)
            {
                var item = scriptsView.Nodes[i];

                if (item.Tag != null && item.Tag.GetType() == type)
                    scripts.Add((RuntimeScript)item.Tag);
            }

            _ori_keyObject.Paste(KeyObject);
        }

        public void RefreshView()
        {
            if (KeyObject == null || KeyObject.Scripts == null)
                return;

            scriptsView.Nodes.Clear();

            var scripts = KeyObject.Scripts;

            for (int i = 0; i < scripts.Count; i++)
            {
                var script = scripts[i];

                if (script == null) continue;

                var content = Script.ScriptContent(script, KeyObject);

                if (content == null) continue;

                var item = new Design.Controls.TreeNode() {
                    Text = content,
                    Tag = script
                };

                ScriptAdding?.Invoke(this, script, item);
                scriptsView.Nodes.Add(item);
            }
        }

        private void ShowContextMenu()
        {
            var f = SelectedItem;
            var e = f != null;

            _separatorMenu.Visible = e;
            _removeMenu.Visible = e;

            for (int i = 0; i < _runtimeMenus.Length; i++) {
                try {
                    _runtimeMenus[i].MenuClicking(this, f, f?.Tag as RuntimeScript, KeyObject);
                } catch (Exception ex) { 
                    Plugin.Plugin.PluginException(ex, _runtimeMenus.GetType(), "IRuntimeMenu MenuClicking invoke failed", "Script Editor");
                }
            }

            contextMenuStrip.Show(MousePosition);
        }

        private bool HasSelectedItem { get => scriptsView.SelectedNodes.Count == 1; }
        private Design.Controls.TreeNode SelectedItem { get => HasSelectedItem ? scriptsView.SelectedNodes[0] : null; }

        private void ScriptsView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && HasSelectedItem)
                Remove_Click(null, null);
            else if (e.KeyCode == Keys.Apps)
                ShowContextMenu();
        }

        public Design.Controls.TreeNode GetSelectedItem() => SelectedItem;

        private void Moveup_button_Click(object sender, EventArgs e)
        {
            var node = SelectedItem;
            if (node == null || !(node.Tag is RuntimeScript script)) return;
            var i = KeyObject.Scripts.IndexOf(script);
            if (i < 1) return;
            KeyObject.Scripts.Remove(script);
            KeyObject.Scripts.Insert(i - 1, script);
            RefreshView();
            SelectScript(script);
        }

        private void Movedown_button_Click(object sender, EventArgs e)
        {
            var node = SelectedItem;
            if (node == null || !(node.Tag is RuntimeScript script)) return;
            var i = KeyObject.Scripts.IndexOf(script);
            if (i >= KeyObject.Scripts.Count - 1) return;
            KeyObject.Scripts.Remove(script);
            KeyObject.Scripts.Insert(i + 1, script);
            RefreshView();
            SelectScript(script);
        }

        public void SelectScript(RuntimeScript script)
        {
            scriptsView.SelectedNodes.Clear();
            foreach (var item in scriptsView.Nodes) {
                if (item == null || !(item.Tag is RuntimeScript s)) continue;
                if(s == script) {
                    scriptsView.SelectedNodes.Add(item); continue;
                }
            }
        }
    }
}
