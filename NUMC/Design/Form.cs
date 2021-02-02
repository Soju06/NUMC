using NUMC.Design.Controls;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WinUtils;

namespace NUMC.Design
{
    public class Form : System.Windows.Forms.Form
    {
        public event EventHandler TitleBarClick;
        public event MouseEventHandler TitleBarMouseClick;
        public event EventHandler TitleBarDrag;
        public event EventHandler CloseButtonClick;
        public event EventHandler MaximizeButtonClick;
        public event EventHandler MinimizeButtonClick;

        protected readonly Designer.TitleBarDesigner TitleBarDesigner;
        protected readonly Styles _styles = Styles.GetStyles();
        protected ColorBlend BackgroundColorBlend;
        protected Color[] BorderGradient;

        private readonly bool _enableTransparent;
        private bool aeroEnabled;

        private readonly byte[] _titleBarRightButtonStates = new byte[3];
        private Rectangle _titleBarRightButtonsRect;
        private Rectangle[] _titleBarRightButtonRects;
        private Rectangle _titleBarRect;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new FormBorderStyle FormBorderStyle { get => base.FormBorderStyle; }

        public bool Resizing { get; set; } = true;

        public new string Text { get => TitleBarDesigner?.Title; set { TitleBarDesigner.Title = value; base.Text = value; } }

        public new bool MinimizeBox { get => TitleBarDesigner.Minimize; set { TitleBarDesigner.Minimize = value; base.MinimizeBox = value; } }

        public new bool MaximizeBox { get => TitleBarDesigner.Maximize; set { TitleBarDesigner.Maximize = value; base.MaximizeBox = value; } }

        public bool CloseBox { get => TitleBarDesigner.Close; set => TitleBarDesigner.Close = value; }

        public new Padding Padding { get => base.Padding; set { var b = Constant.Form.Border; base.Padding = 
            new Padding(value.Left < b ? b + value.Left : value.Left, value.Top < b + Constant.Form.TitleBarHeight ?
            b + Constant.Form.TitleBarHeight + value.Top : value.Top, value.Right < b ? b + value.Right : value.Right,
            value.Bottom < b ? b + value.Bottom : value.Bottom); try { Invalidate(); } catch { } } }

        public new Bitmap Icon { get => TitleBarDesigner?.Icon; set { TitleBarDesigner.Icon = value;
                base.Icon = value != null ? System.Drawing.Icon.FromHandle(value.GetHicon()) : null; } }

        public Form()
        {
            TitleBarDesigner = new Designer.TitleBarDesigner(_styles);
            _enableTransparent = Constant.Form.EnableTransparent;
            base.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            InitializeForm();

            BackColor = _styles.Form.BackgroundColor;
            ForeColor = _styles.Form.Color;
            BackgroundColorBlend = _styles.Form.BackgroundGradient;
            BorderGradient = _styles.Form.BorderGradient;
            Padding = new Padding(Constant.Form.Border);
        }

        private void InitializeForm()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint, true);
        }

        protected override void OnLoad(EventArgs e)
        {
            if (_enableTransparent) {
                new LayeredWindowHelper(this).BackColor = _styles.Form.TransparentBackColor;
                Win10Style.EnableBlur(Handle, true);
            }
            TitleBarDesigner.Invalidate += TitleBarDesigner_Invalidate;
            TitleBarDrag += Form_TitleBarDrag;
            CloseButtonClick += Form_CloseButtonClick;
            MaximizeButtonClick += Form_MaximizeButtonClick;
            MinimizeButtonClick += Form_MinimizeButtonClick;
            Invalidate();
            base.OnLoad(e);
        }

        protected override void WndProc(ref Message m)
        {
#if DEBUG
            if(Application.ExecutablePath.IndexOf("devenv.exe", StringComparison.OrdinalIgnoreCase) > -1) {
                base.WndProc(ref m);
                return;
            }
#endif

            if (Resizing && m.Msg == 0x84) {
                var pos = PointToClient(new Point(m.LParam.ToInt32()));
                //if (pos.Y < 32) {
                //    m.Result = (IntPtr)2; return;
                //}

                if (pos.X >= ClientSize.Width - 16 && pos.Y >= ClientSize.Height - 32) {
                    m.Result = (IntPtr)17; return;
                }
            } else if (aeroEnabled && m.Msg == Constants.WM_NCPAINT) {
                var v = 2;
                WinAPI.DwmSetWindowAttribute(Handle, 2, ref v, 4);

                MARGINS margins = new MARGINS() {
                    bottomHeight = 1, leftWidth = 0, rightWidth = 0, topHeight = 0
                };

                WinAPI.DwmExtendFrameIntoClientArea(Handle, ref margins);
                WinAPI.SetWindowLong(Handle, Constants.GWL_EXSTYLE, Constants.WS_EX_LAYERED);
                WinAPI.SetLayeredWindowAttributes(Handle, 0, 0, Constants.LWA_COLORKEY);
            }
            base.WndProc(ref m);

            //if (m.Msg == Constants.WM_NCHITTEST &&
            //    (int)m.Result == Constants.HTCLIENT)
            //    m.Result = (IntPtr)Constants.HTCAPTION;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            var g = e.Graphics;
            var b = Constant.Form.Border;
            var cr = ClientRectangle;
            var clientRect = new Rectangle(cr.X + b, cr.Y + b,
                cr.Width - (b * 2), cr.Height - (b * 2));

            #region Draw Background Gradient

            {
                var r = new Rectangle(0, 0, Width, Height);
                var bcb = BackgroundColorBlend;

                if (bcb != null)
                    using (var brush = new LinearGradientBrush(r, BackColor, BackColor, LinearGradientMode.ForwardDiagonal)) {
                        brush.InterpolationColors = bcb;
                        g.FillRectangle(brush, r);
                    }
            }

            #endregion

            #region Draw Border Gradient

            var cs = BorderGradient;
            if (cs != null && cs.Length >= 2)
            {

                for (int i = 0; i < 4; i++) {
                    var r = new Rectangle(i < 2 ? 0 : (i == 2 ? 0 : Width - b), i < 2 ?
                        (i == 0 ? 0 : Height - b) : 0, i < 2 ? Width : b, i < 2 ? b : Height);

                    using (var brush = new LinearGradientBrush(r, cs[i % 2 == 0 ? 0 : 1],
                        cs[i % 2 == 0 ? 1 : 0], i < 2 ? LinearGradientMode.Horizontal : LinearGradientMode.Vertical))
                            g.FillRectangle(brush, r);
                }
            }

            #endregion

            #region Draw TitleBar

            TitleBarDesigner.Drawing(clientRect, e.Graphics,
                _titleBarRightButtonStates, out _titleBarRightButtonsRect, out _titleBarRightButtonRects, out _titleBarRect, out _);

            #endregion
        }

        protected override CreateParams CreateParams {
            get {
                aeroEnabled = WinAPI.CheckAeroEnabled();
                CreateParams cp = base.CreateParams;
                if (!aeroEnabled)
                    cp.ClassStyle |= Constants.CS_DROPSHADOW;
                //cp.Style |= 0x00040000;
                return cp;
            }
        }
        
        protected override void OnMouseLeave(EventArgs e)
        {
            StatesClear();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!SetButtonEmpha(e.Location, 1, false)) {
                StatesClear();
                base.OnMouseMove(e);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!SetButtonEmpha(e.Location, 2, true)) {
                if(_titleBarRect != null && _titleBarRect.Contains(e.Location)) {
                    TitleBarDrag?.Invoke(this, default);
                }
                else base.OnMouseDown(e);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (!SetButtonEmpha(e.Location, 1, true)) {
                if (_titleBarRect != null && _titleBarRect.Contains(e.Location)) {
                    TitleBarMouseClick?.Invoke(this, e);
                    if (e.Button == MouseButtons.Left)
                        TitleBarClick?.Invoke(this, default);
                }
                else base.OnMouseUp(e);
            }
        }

        protected bool SetButtonEmpha(Point loc, byte state, bool f)
        {
            if (_titleBarRightButtonsRect == null || !_titleBarRightButtonsRect.Contains(loc) || _titleBarRightButtonRects == null)
                return false;
            var rf = false;
            for (int i = 0; i < _titleBarRightButtonRects.Length; i++) {
                if (_titleBarRightButtonRects[i] == Rectangle.Empty) continue;
                byte o = _titleBarRightButtonStates[i], n = _titleBarRightButtonStates[i] = (f || o != 2) ?
                    (byte)(_titleBarRightButtonRects[i].Contains(loc) ? state : 0) : o;
                if(o == 2 && n == 1) (i == 0 ? MinimizeButtonClick : i == 1 ? MaximizeButtonClick
                    : CloseButtonClick)?.Invoke(this, default);
                if (o != n) rf = true;
            } if (rf) Invalidate();
            return true;
        }

        private void StatesClear()
        {
            if (_titleBarRightButtonStates != null) {
                var rf = false;
                for (int i = 0; i < _titleBarRightButtonStates.Length; i++) {
                    byte o = _titleBarRightButtonStates[i], n = _titleBarRightButtonStates[i] = 0;
                    if (o != n) rf = true; 
                } if (rf) Invalidate();
            }
        }

        private void TitleBarDesigner_Invalidate(object sender, EventArgs e)
        {
            try {
                Invoke(new MethodInvoker(delegate () {
                    Invalidate();
                }));
            } catch { 

            }
        }

        private void Form_MinimizeButtonClick(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;
        private void Form_MaximizeButtonClick(object sender, EventArgs e) => WindowState = WindowState == FormWindowState.Normal ? 
            FormWindowState.Maximized : FormWindowState.Normal;
        private void Form_CloseButtonClick(object sender, EventArgs e) => Close();
        private void Form_TitleBarDrag(object sender, EventArgs e) => FormUtils.DragWindow(Handle);
    }
}