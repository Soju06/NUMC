using NUMC.Design.Controls;
using NUMC.Script;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUMC.Plugin.Runtime
{
    public interface IRuntimeMenu : IDisposable
    {
        ToolStripItem[] Menus { get; }

        void Initialize(Plugins.ScriptEditor.IScriptEditor scriptEditor);
        void MenuClicking(Plugins.ScriptEditor.IScriptEditor scriptEditor, Design.Controls.TreeNode node, RuntimeScript runtimeScript, KeyObject obj);
    }
}