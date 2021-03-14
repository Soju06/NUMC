using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinUtils;

namespace NUMC.Keyboard
{
    public delegate bool KeyboardEventCallback(Keys key);
    public delegate void KeyboardEventNonStopCallback(Keys key);

    public static class KeyboardHook
    {
        public static bool GetSystemKeyEvent { get; set; } = true;

        public static event KeyboardEventCallback KeyDown;
        public static event KeyboardEventCallback KeyUp;
        public static event KeyboardEventNonStopCallback NonStopKeyDown;
        public static event KeyboardEventNonStopCallback NonStopKeyUp;
        //public static event KeyboardEventNonStopCallback NonStopKeyDown;
        //public static event KeyboardEventNonStopCallback NonStopKeyUp;

        private static readonly LowLevelProc _proc;
        private static IntPtr _hookID = IntPtr.Zero;

        static KeyboardHook() {
            _proc = HookCallback;
            Task.Run(Loop);
        }

        private static async Task Loop() {
            while (true) {
                if(NonStopKeyDownKey.Count > 0) {
                    var i = NonStopKeyDownKey[0];
                    try {
                        NonStopKeyDown?.Invoke(i);
                    } catch (Exception ex) {
                        Debug.WriteLine(ex);
                    } NonStopKeyDownKey.Remove(i);
                }
                if(NonStopKeyUpKey.Count > 0) {
                    var i = NonStopKeyUpKey[0];
                    try {
                        NonStopKeyUp?.Invoke(i);
                    } catch (Exception ex) {
                        Debug.WriteLine(ex);
                    } NonStopKeyUpKey.Remove(i);
                }
                await Task.Delay(20);
            }
        }

        private static List<Keys> NonStopKeyDownKey = new List<Keys>();
        private static List<Keys> NonStopKeyUpKey = new List<Keys>();

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                var hookStruct = Marshal.PtrToStructure<KBDLLHOOKSTRUCT>(lParam);
                var flags = hookStruct.Flags;
                Keys vkCode = (Keys)hookStruct.VkCode;

                if (wParam == (IntPtr)Constants.WM_KEYDOWN || (GetSystemKeyEvent
                    && wParam == (IntPtr)Constants.WM_SYSKEYDOWN)) {
                    NonStopKeyDownKey.Add(vkCode);
                    if(KeyDown?.Invoke(vkCode) == false) return (IntPtr)1;
                }
                //new Thread(() => 
                //{
                //    for (int i = 0; i < keyDownCallbackEvents.Count; i++)
                //        if (keyDownCallbackEvents[i].Key == vkCode && keyDownCallbackEvents[i].Callback != null)
                //            keyDownCallbackEvents[i].Callback.DynamicInvoke(vkCode);
                //}) { IsBackground = true }.Start();

                if (wParam == (IntPtr)Constants.WM_KEYUP || (GetSystemKeyEvent 
                    && wParam == (IntPtr)Constants.WM_SYSTEMKEYUP)) {
                    NonStopKeyUpKey.Add(vkCode);
                    if (KeyUp?.Invoke(vkCode) == false) return (IntPtr)1;
                }
                //new Thread(() =>
                //{
                //    for (int i = 0; i < keyUpCallbackEvents.Count; i++)
                //    if (keyUpCallbackEvents[i].Key == vkCode && keyDownCallbackEvents[i].Callback != null)
                //        keyDownCallbackEvents[i].Callback.DynamicInvoke(vkCode);
                //})
                //{ IsBackground = true }.Start();
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

        //private static List<KeyCallbackEvent> keyDownCallbackEvents = new List<KeyCallbackEvent>();
        //private static List<KeyCallbackEvent> keyUpCallbackEvents = new List<KeyCallbackEvent>();

        //#region RegKeyEvent

        //public static bool RegKeyDownEvent(KeyboardEventCallback callback, Keys key)
        //{
        //    for (int i = 0; i < keyDownCallbackEvents.Count; i++)
        //        if (keyDownCallbackEvents[i].Callback == (Delegate)callback && keyDownCallbackEvents[i].Key == key)
        //            return false;

        //    keyDownCallbackEvents.Add(new KeyCallbackEvent() { Callback = callback, Key = key });

        //    return true;
        //}

        //public static bool RegKeyUpEvent(KeyboardEventCallback callback, Keys key)
        //{
        //    for (int i = 0; i < keyUpCallbackEvents.Count; i++)
        //        if (keyUpCallbackEvents[i].Callback == (Delegate)callback && keyUpCallbackEvents[i].Key == key)
        //            return false;

        //    keyUpCallbackEvents.Add(new KeyCallbackEvent() { Callback = callback, Key = key });

        //    return true;
        //}

        //#endregion

        //#region UnRegKeyEvent

        //public static void UnRegKeyDownEvent(KeyboardEventCallback callback)
        //{
        //    for (int i = 0; i < keyDownCallbackEvents.Count; i++)
        //        if (keyDownCallbackEvents[i].Callback == (Delegate)callback)
        //            keyDownCallbackEvents.RemoveAt(i);
        //}

        //public static void UnRegKeyUpEvent(KeyboardEventCallback callback)
        //{
        //    for (int i = 0; i < keyUpCallbackEvents.Count; i++)
        //        if (keyUpCallbackEvents[i].Callback == (Delegate)callback)
        //            keyUpCallbackEvents.RemoveAt(i);
        //}

        //public static void UnRegKeyDownEvent(Keys key)
        //{
        //    for (int i = 0; i < keyDownCallbackEvents.Count; i++)
        //        if (keyDownCallbackEvents[i].Key == key)
        //            keyDownCallbackEvents.RemoveAt(i);
        //}

        //public static void UnRegKeyUpEvent(Keys key)
        //{
        //    for (int i = 0; i < keyUpCallbackEvents.Count; i++)
        //        if (keyUpCallbackEvents[i].Key == key)
        //            keyUpCallbackEvents.RemoveAt(i);
        //}

        //public static void UnRegKeyDownEvent(KeyboardEventCallback callback, Keys key)
        //{
        //    for (int i = 0; i < keyDownCallbackEvents.Count; i++)
        //        if (keyDownCallbackEvents[i].Key == key && keyDownCallbackEvents[i].Callback == (Delegate)callback)
        //            keyDownCallbackEvents.RemoveAt(i);
        //}

        //public static void UnRegKeyUpEvent(KeyboardEventCallback callback, Keys key)
        //{
        //    for (int i = 0; i < keyUpCallbackEvents.Count; i++)
        //        if (keyUpCallbackEvents[i].Key == key && keyDownCallbackEvents[i].Callback == (Delegate)callback)
        //            keyUpCallbackEvents.RemoveAt(i);
        //}

        //#endregion

        //private struct KeyCallbackEvent
        //{
        //    public Delegate Callback;
        //    public Keys Key;
        //}
    }
}