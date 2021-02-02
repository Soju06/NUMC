using System.Collections.Generic;
using System.Windows.Forms;

namespace NUMC.Script
{
    public class Menu
    {
        public static ToolStripItem[] GetSampleItems()
        {
            List<ToolStripItem> SampleItems = new List<ToolStripItem>();

            int[] SeparatorIndex = new int[] { 2, 4, 6, 11 };

            string[] Names = Language.Language.Sample_Menu_Items.Split('|');

            // 샘플 배열보다 낮다면
            if (Names.Length < 13)
                return SampleItems.ToArray();

            KeyObject[] KeyObjects = new KeyObject[]
            {
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

            for (int i = 0; i < Names.Length; i++)
            {
                for (int si = 0; si < SeparatorIndex.Length; si++)
                {
                    if (i == SeparatorIndex[si])
                    {
                        SampleItems.Add(new ToolStripSeparator());
                        break;
                    }
                }

                ToolStripItem item = new ToolStripMenuItem
                {
                    Text = Names[i],
                    Tag = KeyObjects[i]
                };
                SampleItems.Add(item);
            }

            return SampleItems.ToArray();
        }

        public static KeyObject NewKeyObjectVirtualKey(Keys[] virtualKeys)
        {
            return new KeyObject
            (
                Keys.None,
                true,
                new KeyScript[]
                {
                    new KeyScript
                    (
                        "VirtualKey",
                        null,
                        new VirtualKey
                        (
                            virtualKeys
                        )
                    )
                }
            );
        }

        public static KeyObject DisableMenuItem()
        {
            return new KeyObject
            (
                Keys.None,
                false,
                null
            );
        }

        public static KeyObject DisableDisabledIgnoreMenuItem()
        {
            return new KeyObject
            (
                Keys.None,
                true,
                null
            );
        }
    }
}