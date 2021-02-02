using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using WinUtils;

namespace BlurTest
{
    public partial class Form1 : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                // cp.Style |= 0x40000;
                CreateParams cParms = base.CreateParams;
                cParms.Style |= 0x00040000;//Constants.WS_SYSMENU; 0x00040000
                cParms.ExStyle |= Constants.WS_EX_LAYERED;
                return cParms;
            }
        }

        public Form1()
        {
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //SetStyle(ControlStyles.UserPaint, true);
            InitializeComponent();

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }


        //private static WinAPI.WndProcDelegate m_CtrlWndProcDelegate;
        //private static WinAPI.WndProcDelegate m_CtrlWndProcDelegate_1;
        //private Dictionary<IntPtr, IntPtr> m_WndProcMap = new Dictionary<IntPtr, IntPtr>();
        private bool m_bIsRefreshing = false;


        #region const message

        public bool en_ResizeTop = true;
        public bool en_ResizeBot = true;
        public bool en_ResizeLeft = true;
        public bool en_ResizeRight = true;

        public bool en_ResizeTopLeft = true;
        public bool en_ResizeTopRight = true;
        public bool en_ResizeBotLeft = true;
        public bool en_ResizeBotRight = true;

        const int HTLEFT = 10;

        const int HTRIGHT = 11;

        const int HTTOP = 12;

        const int HTTOPLEFT = 13;

        const int HTTOPRIGHT = 14;

        const int HTBOTTOM = 15;

        const int HTBOTTOMLEFT = 0x10;

        const int HTBOTTOMRIGHT = 17;

        //left mouse button down while the cursor is in the client area of a window

        const int WM_LBUTTONDOWN = 0x0201;

        //left mouse button down while the cursor is within the nonclient area of a window 

        const int WM_NCLBUTTONDOWN = 0x00A1;

        #endregion

        bool resizing = false;



     

        //protected override void WndProc(ref Message m)
        //{

 
         
        //    //    switch (m.Msg)
        //    //    {
        //    //        case 0x0084:
        //    //            base.WndProc(ref m);
        //    //            Point vPoint = new Point((int)m.LParam & 0xFFFF, (int)m.LParam >> 16 & 0xFFFF);
        //    //            vPoint = PointToClient(vPoint);
        //    //            resizing = true;
        //    //            //Setting drag response area

        //    //            if (vPoint.X <= 8)
        //    //            {

        //    //                if (vPoint.Y <= 5 && en_ResizeTopLeft)
        //    //                {
        //    //                    m.Result = (IntPtr)HTTOPLEFT;
        //    //                }
        //    //                if (vPoint.Y >= ClientSize.Height - 8 && en_ResizeBotLeft)
        //    //                {
        //    //                    m.Result = (IntPtr)HTBOTTOMLEFT;
        //    //                    resizing = true;
        //    //                }
        //    //                else if (en_ResizeLeft)
        //    //                {
        //    //                    m.Result = (IntPtr)HTLEFT;
        //    //                    resizing = true;
        //    //                }
        //    //            }
        //    //            else if (vPoint.X >= ClientSize.Width - 8)
        //    //            {
        //    //                if (vPoint.Y <= 8 && en_ResizeTopRight)
        //    //                {
        //    //                    m.Result = (IntPtr)HTTOPRIGHT;
        //    //                    resizing = true;
        //    //                }
        //    //                else if (vPoint.Y >= ClientSize.Height - 8 && en_ResizeBotRight)
        //    //                {
        //    //                    m.Result = (IntPtr)HTBOTTOMRIGHT;
        //    //                    resizing = true;
        //    //                }
        //    //                else if (en_ResizeRight)
        //    //                {
        //    //                    m.Result = (IntPtr)HTRIGHT;
        //    //                    resizing = true;
        //    //                }
        //    //            }
        //    //            else if (vPoint.Y <= 8 && en_ResizeTop)
        //    //            {
        //    //                m.Result = (IntPtr)HTTOP;
        //    //                resizing = true;
        //    //            }
        //    //            else if (vPoint.Y >= ClientSize.Height - 8 && en_ResizeBot)
        //    //            {
        //    //                m.Result = (IntPtr)HTBOTTOM;
        //    //                resizing = true;
        //    //            }
        //    //            break;

        //    //        case WM_LBUTTONDOWN:

        //    //            resizing = true;
        //    //            m.Msg = WM_NCLBUTTONDOWN;//change message type

        //    //            m.LParam = IntPtr.Zero;//default


        //    //            //   m.WParam = new IntPtr(2);//set Mouse into titlebar




        //    //            base.WndProc(ref m);

        //    //            break;

        //    //        default:

        //    //            base.WndProc(ref m);


        //    //            resizing = false;
        //    //            break;

        //    //    }

        //}


        private void Form1_Load(object sender, EventArgs e)
        {


            //(new LayeredWindowHelper(this)).BackColor = Color.FromArgb(128, Win7Style.GetThemeColor());
            // GC.KeepAlive((new LayeredWindowHelper(this)).BackColor = Color.FromArgb(128, Color.Black)); 

            (new LayeredWindowHelper(this)).BackColor = Color.FromArgb(128, Color.Black);
            // Win7Style.EnableBlurBehindWindow(this.Handle);
            Win10Style.EnableBlur(this.Handle,true);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FormUtils.ShowSystemMenu(this.Handle);
        }

        private void toolStrip1_MouseDown(object sender, MouseEventArgs e)
        { 
                FormUtils.DragWindow(this.Handle);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GC.Collect();
        }
    }
}
