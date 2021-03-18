using System;
using System.Drawing;

namespace NUMC.WinUtils {
    public class FormUtils {
        public static void DragWindow(IntPtr hwnd) {
            WinAPI.ReleaseCapture();
            WinAPI.SendMessage(hwnd, Constants.WM_SYSCOMMAND, (IntPtr)(Constants.SC_MOVE + Constants.HTCAPTION), IntPtr.Zero);
        }

        public static void ShowSystemMenu(IntPtr hwnd) {
            if (hwnd == IntPtr.Zero) return;
            var defPnt = new Point();
            WinAPI.GetCursorPos(ref defPnt);
            var hmenu = WinAPI.GetSystemMenu(hwnd, false);
            var cmd = WinAPI.TrackPopupMenuEx(hmenu, Constants.TPM_LEFTBUTTON | Constants.TPM_RETURNCMD, 
                (uint)defPnt.X, (uint)defPnt.Y, hwnd, IntPtr.Zero);
            if (cmd != IntPtr.Zero) WinAPI.PostMessage(hwnd, Constants.WM_SYSCOMMAND, cmd, IntPtr.Zero);
        }
    }
}