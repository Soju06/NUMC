using System.Collections.Generic;
using System.Windows.Forms;
using WindowsInput.Native;

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
                NewKeyObjectVirtualKey(new VirtualKeyCode[] { VirtualKeyCode.CONTROL, VirtualKeyCode.VK_Z }),
                NewKeyObjectVirtualKey(new VirtualKeyCode[] { VirtualKeyCode.CONTROL, VirtualKeyCode.SHIFT, VirtualKeyCode.VK_Z }),
                NewKeyObjectVirtualKey(new VirtualKeyCode[] { VirtualKeyCode.OEM_6 }),
                NewKeyObjectVirtualKey(new VirtualKeyCode[] { VirtualKeyCode.OEM_4 }),
                NewKeyObjectVirtualKey(new VirtualKeyCode[] { VirtualKeyCode.CONTROL, VirtualKeyCode.OEM_PLUS }),
                NewKeyObjectVirtualKey(new VirtualKeyCode[] { VirtualKeyCode.CONTROL, VirtualKeyCode.OEM_MINUS }),
                NewKeyObjectVirtualKey(new VirtualKeyCode[] { VirtualKeyCode.VK_B }),
                NewKeyObjectVirtualKey(new VirtualKeyCode[] { VirtualKeyCode.VK_E }),
                NewKeyObjectVirtualKey(new VirtualKeyCode[] { VirtualKeyCode.VK_G }),
                NewKeyObjectVirtualKey(new VirtualKeyCode[] { VirtualKeyCode.SPACE }),
                NewKeyObjectVirtualKey(new VirtualKeyCode[] { VirtualKeyCode.VK_Z }),
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

        public static KeyObject NewKeyObjectVirtualKey(VirtualKeyCode[] virtualKeys)
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