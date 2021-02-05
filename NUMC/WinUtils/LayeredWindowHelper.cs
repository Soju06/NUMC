using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WinUtils
{
    public class LayeredWindowHelper : IDisposable
    {
        private readonly WndProcDelegate m_CtrlWndProcDelegate;
        private readonly Dictionary<IntPtr, IntPtr> m_WndProcMap = new Dictionary<IntPtr, IntPtr>();
        private bool m_bIsRefreshing = false;
        private readonly Control host;
        public Color BackColor;

        public LayeredWindowHelper(Control host)
        {
            this.host = host;
            m_CtrlWndProcDelegate = CtrlWndProc;

            HookChildControl(host);
            RefreshCtrl();
        }

        private void RefreshCtrl()
        {
            if (m_bIsRefreshing)
                return;

            int width = host.ClientRectangle.Width + 14;
            int height = host.ClientRectangle.Height + 14;

            m_bIsRefreshing = true;

            IntPtr hDC = WinAPI.GetDC(host.Handle);
            if (hDC == IntPtr.Zero)
            {
                m_bIsRefreshing = false;
                //Debug.Assert(false, "GetDC failed.");
                return;
            }

            IntPtr hdcMemory = WinAPI.CreateCompatibleDC(hDC);

            int nBytesPerLine = ((width * 32 + 31) & (~31)) >> 3;
            BITMAPINFO stBmpInfoHeader = new BITMAPINFO();
            stBmpInfoHeader.bmiHeader.biSize = Marshal.SizeOf(stBmpInfoHeader);
            stBmpInfoHeader.bmiHeader.biWidth = width;
            stBmpInfoHeader.bmiHeader.biHeight = height;
            stBmpInfoHeader.bmiHeader.biPlanes = 1;
            stBmpInfoHeader.bmiHeader.biBitCount = 32;
            stBmpInfoHeader.bmiHeader.biCompression = 0;
            stBmpInfoHeader.bmiHeader.biClrUsed = 0;
            stBmpInfoHeader.bmiHeader.biSizeImage = nBytesPerLine * height;
            IntPtr hbmpMem = WinAPI.CreateDIBSection(hDC
                , ref stBmpInfoHeader
                , Constants.DIB_RGB_COLORS
                , out _
                , IntPtr.Zero
                , 0
                );

            //Debug.Assert(hbmpMem != IntPtr.Zero, "CreateDIBSection failed.");

            if (hbmpMem != null)
            {
                IntPtr hbmpOld = WinAPI.SelectObject(hdcMemory, hbmpMem);

                Graphics graphic = Graphics.FromHdcInternal(hdcMemory);
                graphic.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                //  graphic.SmoothingMode = SmoothingMode.HighQuality;
                graphic.FillRectangle(new SolidBrush(BackColor), graphic.ClipBounds);

                foreach (Control ctrl in host.Controls)
                {
                    Point realpos = ctrl.Location;
                    realpos.Offset(7, 7);//BORDER COMPENSATE
                    Bitmap bmp = new Bitmap(ctrl.Width, ctrl.Height, PixelFormat.Format32bppArgb);
                    Rectangle rect = new Rectangle(0, 0, ctrl.Width, ctrl.Height);
                    if (ctrl is Label)
                    {
                        #region Render_Label

                        if (ctrl is LinkLabel tti)
                        {
                            tti.Font = new Font(tti.Font, FontStyle.Underline);

                            if (tti.Capture)
                            {
                                SolidBrush drawBrush = new SolidBrush((tti.ActiveLinkColor));
                                graphic.DrawString(ctrl.Text, tti.Font, drawBrush, realpos);
                            }
                            else if (tti.LinkVisited == true)
                            {
                                SolidBrush drawBrush = new SolidBrush((tti.VisitedLinkColor));
                                graphic.DrawString(ctrl.Text, tti.Font, drawBrush, realpos);
                            }
                            else
                            {
                                SolidBrush drawBrush = new SolidBrush((tti.LinkColor));
                                graphic.DrawString(ctrl.Text, tti.Font, drawBrush, realpos);
                            }
                        }
                        else
                        {
                            SolidBrush drawBrush = new SolidBrush(ctrl.ForeColor);
                            graphic.DrawString(ctrl.Text, ctrl.Font, drawBrush, realpos);
                        }

                        #endregion Render_Label
                    }
                    else if (ctrl is CheckBox)
                    {
                        #region Render_CheckBox

                        bmp = new Bitmap(13, ctrl.Height, PixelFormat.Format32bppArgb);
                        ctrl.DrawToBitmap(bmp, rect);
                        bmp.MakeTransparent();
                        graphic.DrawImage(bmp, realpos);

                        if (ctrl.Text.Length > 0)
                        {
                            SolidBrush drawBrush = new SolidBrush(ctrl.ForeColor);
                            graphic.DrawString(ctrl.Text, ctrl.Font, drawBrush, realpos.X + 18, realpos.Y);
                        }

                        #endregion Render_CheckBox
                    }
                    else if (ctrl is RadioButton)
                    {
                        #region Render_RadioButton

                        bmp = new Bitmap(13, ctrl.Height, PixelFormat.Format32bppArgb);
                        ctrl.DrawToBitmap(bmp, rect);
                        bmp.MakeTransparent();

                        //CLEAN EDGES
                        Dialogs.LockBitmap lockOrrig = new Dialogs.LockBitmap(bmp);
                        lockOrrig.LockBits();

                        lockOrrig.SetPixel(1, 13, Color.Transparent);
                        lockOrrig.SetPixel(3, 14, Color.Transparent);
                        lockOrrig.SetPixel(0, 11, Color.Transparent);

                        lockOrrig.SetPixel(9, 14, Color.Transparent);
                        lockOrrig.SetPixel(11, 13, Color.Transparent);
                        lockOrrig.SetPixel(12, 11, Color.Transparent);

                        lockOrrig.SetPixel(12, 5, Color.Transparent);
                        lockOrrig.SetPixel(11, 3, Color.Transparent);
                        lockOrrig.SetPixel(9, 2, Color.Transparent);

                        lockOrrig.SetPixel(3, 2, Color.Transparent);
                        lockOrrig.SetPixel(1, 3, Color.Transparent);
                        lockOrrig.SetPixel(0, 5, Color.Transparent);

                        lockOrrig.UnlockBits();
                        graphic.DrawImage(bmp, realpos);

                        if (ctrl.Text.Length > 0)
                        {
                            SolidBrush drawBrush = new SolidBrush(ctrl.ForeColor);
                            graphic.DrawString(ctrl.Text, ctrl.Font, drawBrush, realpos.X + 18, realpos.Y);
                        }

                        #endregion Render_RadioButton
                    }
                    else if (ctrl is Button)
                    {
                        #region Render_Button

                        ctrl.DrawToBitmap(bmp, rect);
                        if ((ctrl as Button).FlatStyle == FlatStyle.Flat)
                            graphic.DrawImage(bmp, realpos);
                        else
                        {
                            Rectangle selection = new Rectangle(1, 1, ctrl.Width - 2, ctrl.Height - 2);
                            Bitmap cropBmp = bmp.Clone(selection, bmp.PixelFormat);
                            bmp.Dispose();
                            graphic.DrawImage(cropBmp, realpos);
                        }

                        #endregion Render_Button
                    }
                    else
                    {
                        ctrl.DrawToBitmap(bmp, rect);
                        graphic.DrawImage(bmp, realpos);
                    }
                }

                POINT ptSrc = new POINT(0, 0);
                POINT ptWinPos = new POINT(host.Left, host.Top);
                SIZE szWin = new SIZE(width, height);
                BLENDFUNCTION stBlend = new BLENDFUNCTION(Constants.AC_SRC_OVER, 0, 0xFF, Constants.AC_SRC_ALPHA);

                WinAPI.UpdateLayeredWindow(host.Handle, hDC, ref ptWinPos, ref szWin
                    , hdcMemory, ref ptSrc, 0, ref stBlend, Constants.ULW_ALPHA);

                graphic.Dispose();
                WinAPI.SelectObject(hbmpMem, hbmpOld);
                WinAPI.DeleteObject(hbmpMem);
            }

            WinAPI.DeleteDC(hdcMemory);
            WinAPI.DeleteDC(hDC);

            m_bIsRefreshing = false;
        }

        private IntPtr CtrlWndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            if (!m_WndProcMap.ContainsKey(hWnd))
                return WinAPI.defWindowProc(hWnd, msg, wParam, lParam);

            IntPtr nRet = WinAPI.CallWindowProc(m_WndProcMap[hWnd], hWnd, msg, wParam, lParam);

            switch (msg)
            {
                case Constants.WM_PAINT:
                case Constants.WM_CTLCOLOREDIT:
                case Constants.WM_CTLCOLORBTN:
                case Constants.WM_CTLCOLORSTATIC:
                case Constants.WM_CTLCOLORMSGBOX:
                case Constants.WM_CTLCOLORDLG:
                case Constants.WM_CTLCOLORLISTBOX:
                case Constants.WM_CTLCOLORSCROLLBAR:
                case Constants.WM_CAPTURECHANGED:
                    RefreshCtrl();
                    break;
            }

            return nRet;
        }

        #region Hooks

        private void HookChildControl(Control ctrl)
        {
            if (WinAPI.IsWindow(ctrl.Handle))
            {
                m_WndProcMap[ctrl.Handle]
                    = WinAPI.GetWindowLongPtr(ctrl.Handle, Constants.GWL_WNDPROC);

                WinAPI.SetWindowLongPtr(ctrl.Handle, Constants.GWL_WNDPROC,
                    Marshal.GetFunctionPointerForDelegate(m_CtrlWndProcDelegate));
            }

            if (!ctrl.HasChildren)
                return;

            foreach (Control child in ctrl.Controls)
                HookChildControl(child);
        }

        private void UnHookControls()
        {
            foreach (IntPtr hWnd in m_WndProcMap.Keys)
                WinAPI.SetWindowLongPtr(hWnd, Constants.GWL_WNDPROC,
                    m_WndProcMap[hWnd]);
        }

        #endregion Hooks

        public void Dispose()
        {
            try
            {
                UnHookControls();
            }
            finally
            {
            }
        }
    }
}