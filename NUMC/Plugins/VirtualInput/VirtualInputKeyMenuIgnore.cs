using NUMC.Config.Object;
using NUMC.Menu;
using NUMC.Plugin.Menu;
using System;
using System.Windows.Forms;

namespace NUMC.Plugins.VirtualInput {
    public class VirtualInputKeyMenuIgnore : IKeyMenu {
        public VirtualInputKeyMenuIgnore() {
            Item = new() { Text = Language.Language.VirtualInput_Menu_KeyIgnore };
            Item1 = new(); Item2 = new();
            Items = new ToolStripItem[] { Item1, Item, Item2 };
            Item.Click += Item_Click;
        }

        public int Index => 20;

        private readonly ToolStripMenuItem Item;
        private readonly ToolStripSeparator Item1;
        private readonly ToolStripSeparator Item2;
        private readonly ToolStripItem[] Items;
        private KeyObject KeyObject;

        public ToolStripItem[] Menus {
            get {
                Item.Text = Language.Language.VirtualInput_Menu_KeyIgnore;
                return Items;
            }
        }

        public void MenuClicking(KeyObject keyObject, Keys selectedKey) {
            KeyObject = keyObject; Item.Checked = keyObject.Ignore;
        }

        private void Item_Click(object sender, EventArgs e) {
            KeyObject.Ignore = !KeyObject.Ignore;
            Service.GetService()?.Save();
        }

        public void Dispose() => MenuStripSupport.DisposeItems(Items);
        public void Initialize(Service service) { }
    }
}
