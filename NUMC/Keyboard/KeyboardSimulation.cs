using NUMC.WinUtils;
using System.Windows.Forms;

namespace NUMC.Keyboard
{
    public static class KeyboardSimulation
    {
        public static void MakeKeyEvent(Keys vkCode, KeyboardEventType type)
        {
            switch (type)
            {
                case KeyboardEventType.KEYDOWN:
                    WinAPI.Keybd_event((byte)vkCode, 0x00, 0x00, 0);
                    break;

                case KeyboardEventType.KEYUP:
                    WinAPI.Keybd_event((byte)vkCode, 0x00, 0x02, 0);
                    break;

                case KeyboardEventType.KEYCLICK:
                    WinAPI.Keybd_event((byte)vkCode, 0x00, 0x00, 0);
                    WinAPI.Keybd_event((byte)vkCode, 0x00, 0x02, 0);
                    break;
            }
        }
    }

    public enum KeyboardEventType
    {
        KEYDOWN,
        KEYUP,
        KEYCLICK
    }
}