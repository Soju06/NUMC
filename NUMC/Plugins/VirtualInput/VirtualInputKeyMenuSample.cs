using NUMC.Config.Object;
using NUMC.Menu;
using NUMC.Plugin.Menu;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NUMC.Plugins.VirtualInput {
    public class VirtualInputKeyMenuSample : IKeyMenu {
        public ToolStripItem[] Menus {
            get {
                MenuStripSupport.DisposeItems(Items);
                var v = GetSampleItems();
                for (int i = 0; i < v.Length; i++)
                    if (v[i].GetType() == typeof(ToolStripMenuItem)) {
                        v[i].Click += MenuItem_Click;
                        if (v.Length - 2 == i)
                            DisableSample1 = (ToolStripMenuItem)v[i];
                        else if (v.Length - 1 == i)
                            DisableSample2 = (ToolStripMenuItem)v[i];
                    }
                Items = v;
                return v;
            }
        }


        public int Index => 30;

        private ToolStripItem[] Items;
        private ToolStripMenuItem DisableSample1;
        private ToolStripMenuItem DisableSample2;
        private KeyObject KeyObject;

        public void MenuClicking(KeyObject keyObject, Keys selectedKey) {
            KeyObject = keyObject;
            if (Items == null) return;
            for (int i = 0; i < Items.Length; i++)
                if (Items[i].Tag != null && Items[i].Tag.GetType() == typeof(KeyObject))
                    ((ToolStripMenuItem)Items[i]).Checked = CheckSampleKey((KeyObject)Items[i].Tag, keyObject, false);

            if (DisableSample1 != null && DisableSample2 != null) {
                var d = CheckDisableSampleKey(keyObject);
                DisableSample1.Checked = false;
                DisableSample2.Checked = false;

                switch (d) {
                    case 1:
                        DisableSample1.Checked = true;
                        break;

                    case 2:
                        DisableSample2.Checked = true;
                        break;
                }
            }
        }

        private void MenuItem_Click(object sender, EventArgs e) {
            if (sender.GetType() != typeof(ToolStripMenuItem)) return;
            if (sender is ToolStripMenuItem menu && menu.Tag != null 
                && menu.Tag.GetType() == typeof(KeyObject)) {
                var SampleScript = (KeyObject)menu.Tag;
                var script = KeyObject;

                //if (System.Array.IndexOf(Items, menu) >= (Items.Length - 2))
                script.Ignore = SampleScript.Ignore;
                script.Scripts = SampleScript.Scripts;
            } Service.GetService()?.Save();
        }


        public void Dispose() =>
            MenuStripSupport.DisposeItems(Items);

        public void Initialize(Service service) {

        }

        private static ToolStripItem[] GetSampleItems() {
            List<ToolStripItem> SampleItems = new();
            var SeparatorIndex = new int[] { 2, 4, 6, 11 };
            var Names = Language.Language.VirtualInput_Sample_Menu_Items.Split('|');
            if (Names.Length < 13) return SampleItems.ToArray();
            KeyObject[] KeyObjects = new[]  {
                NewKeyObjectVirtualKey(new Keys[] { Keys.ControlKey, Keys.Z }),
                NewKeyObjectVirtualKey(new Keys[] { Keys.ControlKey, Keys.ShiftKey, Keys.Z }),
                NewKeyObjectVirtualKey(new Keys[] { Keys.Oem6 }),
                NewKeyObjectVirtualKey(new Keys[] { Keys.Oem4 }),
                NewKeyObjectVirtualKey(new Keys[] { Keys.ControlKey, Keys.Oemplus }),
                NewKeyObjectVirtualKey(new Keys[] { Keys.ControlKey, Keys.OemMinus }),
                NewKeyObjectVirtualKey(new Keys[] { Keys.B }),
                NewKeyObjectVirtualKey(new Keys[] { Keys.E }),
                NewKeyObjectVirtualKey(new Keys[] { Keys.G }),
                NewKeyObjectVirtualKey(new Keys[] { Keys.Space }),
                NewKeyObjectVirtualKey(new Keys[] { Keys.Z }),
                DisableDisabledIgnoreMenuItem(),
                DisableMenuItem()
            };

            for (int i = 0; i < Names.Length; i++) {
                for (int si = 0; si < SeparatorIndex.Length; si++)
                    if (i == SeparatorIndex[si]) {
                        SampleItems.Add(new ToolStripSeparator());
                        break;
                    }
                var item = new ToolStripMenuItem {
                    Text = Names[i], Tag = KeyObjects[i]
                }; SampleItems.Add(item);
            } return SampleItems.ToArray();
        }

        private static bool CheckSampleKey(KeyObject var1, KeyObject var2, bool checkIgnoreVal = false) => var1 != null && var2 != null && 
            KeyScript.Equals(var1.Scripts, var2.Scripts) && (!checkIgnoreVal || var1.Ignore == var2.Ignore);

        private static int CheckDisableSampleKey(KeyObject obj) {
            if (obj != null && (obj.Scripts == null || obj.Scripts.Count <= 0))
                return obj.Ignore ? 1 : 2;
            else return 0;
        }

        private static KeyObject NewKeyObjectVirtualKey(Keys[] virtualKeys) => new KeyObject
            (Keys.None, true, new KeyScript(new RuntimeScript("NUMC.VirtualKey", VirtualInputRuntime.ConvertString(virtualKeys))));

        private static KeyObject DisableMenuItem() => new KeyObject (Keys.None, false, null);

        private static KeyObject DisableDisabledIgnoreMenuItem() => new KeyObject (Keys.None, true, null);
    }
}
