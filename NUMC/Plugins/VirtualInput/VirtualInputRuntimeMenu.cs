using NUMC.Design.Controls;
using NUMC.Plugin.Runtime;
using NUMC.Script;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUMC.Plugins.VirtualInput
{
    public class VirtualInputRuntimeMenu : IRuntimeMenu
    {
        public VirtualInputRuntimeMenu(VirtualInputRuntimeDialog dialog)
        {
            Dialog = dialog;
            (EditMenu = new ToolStripMenuItem(Language.Language.Program_Edit_Button)).Click += EditMenu_Click;
            (AddMenu = new ToolStripMenuItem(Language.Language.Program_Add_Button)).Click += AddMenu_Click;

            _menus = new ToolStripItem[] { AddMenu, EditMenu };
        }

        private void AddMenu_Click(object sender, EventArgs e)
        {
            if (ScriptEditor == null || KeyObject == null || KeyObject.Script == null)
                return;

            var script = new RuntimeScript();

            if (Dialog.ShowDialog(script, KeyObject) && script != null && script.RuntimeName != null)
                KeyObject.Script.AddRuntimeScript(script);

            ScriptEditor.RefreshView();
        }

        private void EditMenu_Click(object sender, EventArgs e)
        {
            if (ScriptEditor == null || RuntimeScript == null || KeyObject == null)
                return;

            if (!Dialog.ShowDialog(RuntimeScript, KeyObject) &&
                (RuntimeScript == null || RuntimeScript.RuntimeName == null))
                    KeyObject?.Script?.RemoveScriptByRuntimeScript(RuntimeScript);

            ScriptEditor.RefreshView();
        }

        private readonly VirtualInputRuntimeDialog Dialog;
        private readonly ToolStripMenuItem EditMenu;
        private readonly ToolStripMenuItem AddMenu;
        private readonly ToolStripItem[] _menus;

        private ScriptEditor.IScriptEditor ScriptEditor;
        private RuntimeScript RuntimeScript;
        private KeyObject KeyObject;

        public ToolStripItem[] Menus
        {
            get {
                if (EditMenu != null)
                    EditMenu.Text = Language.Language.Program_Edit_Button;

                if (AddMenu != null)
                    AddMenu.Text = Language.Language.VirtualInput_Runtime_Add_Text;

                return _menus;
            }
        }

        public void MenuClicking(ScriptEditor.IScriptEditor scriptEditor, 
            IListViewItem listViewItem, RuntimeScript runtimeScript, KeyObject obj)
        {
            ScriptEditor = scriptEditor;
            RuntimeScript = runtimeScript;
            KeyObject = obj;

            if (AddMenu != null && EditMenu != null)
                EditMenu.Visible = runtimeScript != null && 
                    VirtualInputRuntime.RuntimeNames.Contains(runtimeScript.RuntimeName);
        }

        public void Dispose()
        {
            if (Menus != null)
                Menu.MenuStripSupport.DisposeItems(_menus);
        }
    }
}
