using NUMC.Design.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NUMC.Design
{
    public class Form : System.Windows.Forms.Form
    {
        public readonly TitleBar titleBar;

        public Form()
        {
            titleBar = new TitleBar();
            SuspendLayout();
            titleBar.Dock = DockStyle.Top;
            titleBar.ForeColor = Color.White;
            titleBar.TabIndex = 0;
            titleBar.TabStop = false;
            Controls.Add(titleBar);
            BackColor = Styles.Form.BackgroundColor;
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Styles.Form.Color;
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(189, 108);
            ResumeLayout(false);

            InitializeForm();

            Load += NForm_Load;
            BackColorChanged += Form_BackColorChanged;
        }

        private void InitializeForm()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);

            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }

        private void NForm_Load(object sender, EventArgs e)
        {
            titleBar.Dock = DockStyle.Top;
            titleBar.MinimumSize = new Size(189, 32);
            titleBar.Size = new Size(Size.Width, 32);
        }

        private void Form_BackColorChanged(object sender, EventArgs e)
        {
            if (Pen.Color != BackColor)
                Pen = new Pen(BackColor);
        }

        private const int cGrip = 16;
        private const int cCaption = 32;

        public Pen Pen = new Pen(Color.White);
        private bool _resizing = true;

        public bool Resizing
        {
            get
            {
                return _resizing;
            }
            set
            {
                _resizing = value;
                Refresh();
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (Resizing && m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }
                if (pos.X >= ClientSize.Width - cGrip && pos.Y >= ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }
            base.WndProc(ref m);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                if (!Resizing)
                    return base.CreateParams;

                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x20000;
                return cp;
            }
        }
    }
}