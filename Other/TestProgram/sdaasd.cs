using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUMC.Design
{
    public partial class sdaasd : Controls.UserControl
    {
        public event EventHandler TitleBarClick;
        public event MouseEventHandler TitleBarMouseClick;
        public event EventHandler TitleBarDrag;
        public event EventHandler CloseButtonClick;
        public event EventHandler MaximizeButtonClick;
        public event EventHandler MinimizeButtonClick;

        protected readonly Designer.TitleBarDesigner Designer;
        private readonly byte[] _rightButtonStates = new byte[3];
        private Rectangle _rightButtonsRect;
        private Rectangle[] _rightButtonRects;
        private Rectangle _titleBarRect;


        public sdaasd()
        {
            Designer = new Designer.TitleBarDesigner(_styles);
            InitializeComponent();
            //Designer.Icon = Images.NUMC_PNG_ICON.ToBitmap();
            Load += UserControl1_Load;
            SetStyle(ControlStyles.SupportsTransparentBackColor |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint, true);
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            Designer.Invalidate += Designer_Invalidate;
        }

        private void Designer_Invalidate(object sender, EventArgs e)
        {
            try {
                Invoke(new MethodInvoker(delegate () {
                    Invalidate();
                }));
            } catch { 

            }
        }

        public string Title { get => Designer?.Title; set => Designer.Title = value; }

        public bool MinimizeBox { get => Designer.Minimize; set => Designer.Minimize = value; }

        public bool MaximizeBox { get => Designer.Maximize; set => Designer.Maximize = value; }

        public bool CloseBox { get => Designer.Close; set => Designer.Close = value; }

        public Bitmap Icon { get => Designer?.Icon; set => Designer.Icon = value; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            Designer.Drawing(ClientRectangle, e.Graphics,
                _rightButtonStates, out _rightButtonsRect, out _rightButtonRects, out _titleBarRect, out _);
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
                if(_titleBarRect != null && _titleBarRect.Contains(e.Location))
                    TitleBarDrag?.Invoke(this, default);
                else base.OnMouseDown(e);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if(!SetButtonEmpha(e.Location, 1, true)) {
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
            if (_rightButtonsRect == null || !_rightButtonsRect.Contains(loc) || _rightButtonRects == null)
                return false;
            var rf = false;
            for (int i = 0; i < _rightButtonRects.Length; i++) {
                byte o = _rightButtonStates[i], n = _rightButtonStates[i] = (f || o != 2) ?
                    (byte)(_rightButtonRects[i].Contains(loc) ? state : 0) : o;
                if(o == 2 && n == 1) (i == 0 ? MinimizeButtonClick : i == 1 ? MaximizeButtonClick
                    : CloseButtonClick)?.Invoke(this, default);
                if (o != n) rf = true;
            } if (rf) Invalidate();
            return true;
        }

        private void StatesClear()
        {
            if (_rightButtonRects != null) {
                var rf = false;
                for (int i = 0; i < _rightButtonRects.Length; i++) {
                    byte o = _rightButtonStates[i], n = _rightButtonStates[i] = 0;
                    if (o != n) rf = true; 
                } if (rf) Invalidate();
            }
        }
    }
}
