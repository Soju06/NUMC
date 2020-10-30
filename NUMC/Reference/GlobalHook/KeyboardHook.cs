using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using WinUtils;

namespace Hook
{
    public delegate bool KeyboardEventCallback(int vkCode);

    public static class KeyboardHook
    {
        public static bool GetSystemKeyEvent { get; set; } = true;

        public static event KeyboardEventCallback KeyDown;

        public static event KeyboardEventCallback KeyUp;

        private static readonly LowLevelProc _proc;
        private static IntPtr _hookID = IntPtr.Zero;

        static KeyboardHook()
        {
            _proc = HookCallback;
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                var hookStruct = Marshal.PtrToStructure<KBDLLHOOKSTRUCT>(lParam);
                int vkCode = hookStruct.VkCode, flags = hookStruct.Flags;

                if ((wParam == (IntPtr)Constants.WM_KEYDOWN
                    || (GetSystemKeyEvent && wParam == (IntPtr)Constants.WM_SYSKEYDOWN))
                    && KeyDown?.Invoke(vkCode) == false)
                    return (IntPtr)1;

                if ((wParam == (IntPtr)Constants.WM_KEYUP
                    || (GetSystemKeyEvent && wParam == (IntPtr)Constants.WM_SYSTEMKEYUP))
                    && KeyUp?.Invoke(vkCode) == false)
                    return (IntPtr)1;
            }

            return WinAPI.CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        public static void HookStart()
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                _hookID = WinAPI.SetWindowsHookEx(Constants.WH_KEYBOARD_LL, _proc,
                    WinAPI.GetModuleHandle("user32"), 0);
            }
        }

        public static void HookEnd()
        {
            WinAPI.UnhookWindowsHookEx(_hookID);
        }
    }
}