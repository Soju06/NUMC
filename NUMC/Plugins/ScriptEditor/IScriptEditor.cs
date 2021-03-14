using NUMC.Design.Controls;
using NUMC.Script;

namespace NUMC.Plugins.ScriptEditor
{
    public interface IScriptEditor
    {
        event ScriptAddingEventHandler ScriptAdding;

        void RefreshView();
        void SelectScript(RuntimeScript script);
        TreeNode GetSelectedItem();
    }

    public delegate void ScriptAddingEventHandler(IScriptEditor scriptEditor, 
        RuntimeScript runtimeScript, TreeNode node);
}
