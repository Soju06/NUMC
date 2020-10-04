using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

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

        [DllImport("User32.dll")]
        public static extern IntPtr GetSystemMenu(IntPtr hWnd, [MarshalAs(UnmanagedType.Bool)] bool bRevert);

        [DllImport("user32.dll")]
        public static extern IntPtr TrackPopupMenuEx(IntPtr hMenu, uint flags, uint x, uint y, IntPtr hWnd, IntPtr lpTPMParams);

        #endregion User32
    }

    public static class Constants
    {
        public const uint WM_SYSCOMMAND = 0x0112;
        public const uint SC_MOVE = 0xF010;
        public const uint HTCAPTION = 0x0002;
        public const uint TPM_RETURNCMD = 0x0100;
        public const uint TPM_LEFTBUTTON = 0x0;
    }
}