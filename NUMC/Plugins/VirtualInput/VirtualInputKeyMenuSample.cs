using NUMC.Menu;
using NUMC.Plugin.Menu;
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
    public class VirtualInputKeyMenuSample : IKeyMenu
    {
        public ToolStripItem[] Menus
        {
            get
            {
                MenuStripSupport.DisposeItems(Items);

                var v = Script.Menu.GetSampleItems();

                for (int i = 0; i < v.Length; i++)
                    if (v[i].GetType() == typeof(ToolStripMenuItem))
                    {
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

        public void MenuClicking(KeyObject keyObject, Keys selectedKey)
        {
            KeyObject = keyObject;

            if (Items == null)
                return;

            for (int i = 0; i < Items.Length; i++)
                if (Items[i].Tag != null && Items[i].Tag.GetType() == typeof(KeyObject))
                    ((ToolStripMenuItem)Items[i]).Checked = Script.Menu.CheckSampleKey((KeyObject)Items[i].Tag,
                        keyObject, false);

            if (DisableSample1 != null && DisableSample2 != null)
            {
                var d = Script.Menu.CheckDisableSampleKey(keyObject);

                DisableSample1.Checked = false;
                DisableSample2.Checked = false;

                switch (d)
                {
                    case 1:
                        DisableSample1.Checked = true;
                        break;

                    case 2:
                        DisableSample2.Checked = true;
                        break;
                }
            }
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            if (sender.GetType() != typeof(ToolStripMenuItem))
                return;

            var menu = (ToolStripMenuItem)sender;

            if (menu.Tag != null && menu.Tag.GetType() == typeof(KeyObject))
            {
                var SampleScript = (KeyObject)menu.Tag;
                var script = KeyObject;

                //if (System.Array.IndexOf(Items, menu) >= (Items.Length - 2))
                script.Ignore = SampleScript.Ignore;
                script.Scripts = SampleScript.Scripts;
            }

            Service.GetService()?.Save();
        }


        public void Dispose() => MenuStripSupport.DisposeItems(Items);

        public void Initialize(Script.Script script)
        {

        }
    }
}
