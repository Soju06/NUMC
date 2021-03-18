using NUMC.Config.Object;
using NUMC.Menu;
using NUMC.Plugin.Menu;
using System;
using System.Windows.Forms;

namespace NUMC.Plugins.VirtualInput {
    public class VirtualInputKeyMenu : IKeyMenu {
        public VirtualInputKeyMenu() {
            Items = new ToolStripItem[] {
                Item = new ToolStripMenuItem() { Text = Language.Language.VirtualInput_Menu_Name }
            }; Item.Click += Item_Click;
        }

        public int Index => 10;
        public KeyObject KeyObject;

        private readonly ToolStripMenuItem Item;
        private readonly ToolStripItem[] Items;
        private Script.Script Script;
        private VirtualInputRuntime Runtime;

        public ToolStripItem[] Menus {
            get {
                Item.Text = Language.Language.VirtualInput_Menu_Name;
                return Items;
            }
        }

        public void MenuClicking(KeyObject keyObject, Keys selectedKey) {
            KeyObject = keyObject;
            if (KeyObject != null)
                Item.Checked = keyObject.Scripts.ScriptByRuntimeNames(VirtualInputRuntime.RuntimeNames) != null;
        }

        private void Item_Click(object sender, EventArgs e) {
            if (KeyObject == null || 
                KeyObject.Scripts == null) return;
            var script = KeyObject.Scripts.ScriptByRuntimeNames(VirtualInputRuntime.RuntimeNames);
            if (script == null) KeyObject.Scripts.AddRuntimeScript(script = new RuntimeScript());
            if(Runtime.Dialog.ShowDialog(script, KeyObject))
                Service.GetService()?.Save();
        }


        public void Dispose() =>
            MenuStripSupport.DisposeItems(Items);

        public void Initialize(Service service) {
            Script = service.GetScript();
            var runtimes = Script.GetRuntimes();
            for (int i = 0; i < runtimes.Count; i++)
                if (runtimes[i].GetType() == typeof(VirtualInputRuntime))
                    Runtime = (VirtualInputRuntime)runtimes[i];
        }
    }
}