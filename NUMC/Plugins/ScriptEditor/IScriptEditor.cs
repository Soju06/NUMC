using NUMC.Config.Object;
using NUMC.Design.Controls;

namespace NUMC.Plugins.ScriptEditor {
    public interface IScriptEditor {
        event ScriptAddingEventHandler ScriptAdding;

        public void RefreshView();
        public void SelectScript(RuntimeScript script);
        public TreeNode GetSelectedItem();
    }

    public delegate void ScriptAddingEventHandler(IScriptEditor scriptEditor, 
        RuntimeScript runtimeScript, TreeNode node);
}
