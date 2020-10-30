using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace WinUtils
{
    #region Structs

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int x;
        public int y;

        public POINT(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct SIZE
    {
        public int cx;
        public int cy;

        public SIZE(int cx, int cy)
        {
            this.cx = cx;
            this.cy = cy;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct BLENDFUNCTION
    {
        private readonly byte BlendOp;
        private readonly byte BlendFlags;
        private readonly byte SourceConstantAlpha;
        private readonly byte AlphaFormat;

        public BLENDFUNCTION(byte op, byte flags, byte alpha, byte format)
        {
            BlendOp = op;
            BlendFlags = flags;
            SourceConstantAlpha = alpha;
            AlphaFormat = format;
        }
    }

    public struct KBDLLHOOKSTRUCT
    {
        public int VkCode { get; set; }
        public int ScanCode { get; set; }
        public int Flags { get; set; }
        public int Time { get; set; }
        public int DwExtraInfo { get; set; }
    }

    #endregion Structs

    internal static class WinAPI
    {
        #region User32

        [DllImport("user32.dll")]
        public static extern uint ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "PostMessage", CallingConvention = CallingConvention.Winapi)]
        public static extern uint PostMessage(IntPtr hwnd, uint msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern uint SendMessage(IntPtr hwnd, uint wMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern uint GetCursorPos(ref Point lpPoint);

        [DllImport("user32.dll")]
        public static extern IntPtr GetSystemMenu(IntPtr hWnd, [MarshalAs(UnmanagedType.Bool)] bool bRevert);

        [DllImport("user32.dll")]
        public static extern IntPtr TrackPopupMenuEx(IntPtr hMenu, uint flags, uint x, uint y, IntPtr hWnd, IntPtr lpTPMParams);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("user32.dll")]
        public static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprc, IntPtr hrgn, uint flags);

        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowsHookEx(int idHook, LowLevelProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll")]
        internal static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll")]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll")]
        public static extern void Keybd_event(uint vk, uint scan, uint flags, uint extraInfo);

        #endregion User32

        #region Kernel32

        [DllImport("kernel32.dll")]
        internal static extern IntPtr GetModuleHandle(string lpModuleName);

        #endregion Kernel32
    }

    #region Delegate

    public delegate IntPtr LowLevelProc(int nCode, IntPtr wParam, IntPtr lParam);

    #endregion Delegate

    #region Constants

    public static class Constants
    {
        public const int WM_SYSCOMMAND = 0x0112;
        public const int WM_KEYDOWN = 0x0100;
        public const int WM_KEYUP = 0x101;
        public const int WM_SYSTEMKEYUP = 0x0105;
        public const int WM_SYSKEYDOWN = 0x104;

        public const int TPM_RETURNCMD = 0x0100;
        public const int TPM_LEFTBUTTON = 0x0;

        public const int WH_KEYBOARD_LL = 13;

        public const int SC_MOVE = 0xF010;

        public const int HTCAPTION = 0x0002;
    }

    #endregion Constants
}