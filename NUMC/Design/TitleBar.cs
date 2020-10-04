using System;
using System.Windows.Forms;
using WinUtils;
using System.Drawing;

namespace NUMC.Design
{
    public partial class TitleBar : UserControl
    {
        public event EventHandler IconClick;
        public System.Windows.Forms.Form Form { get; set; } = null;

        public TitleBar()
        {
            InitializeComponent();

            for (int i = 0; i < Controls.Count; i++)
                Controls[i].MouseDown += TitleBar_MouseDown;
            MouseDown += TitleBar_MouseDown;

            SetColor();

            BackColorChanged += TitleBar_BackColorChanged;
            Load += TitleBar_Load;
        }

        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && Form != null)
                FormUtils.ShowSystemMenu(Form.Handle);
        }

        private void SetButtonImage(bool bright)
        {
            try
            {
                if (CloseButton.Image != null)
                    CloseButton.Image.Dispose();
                CloseButton.Image = Resources.Images.GetImage("close_16px", bright);

                if (MaximizeButton.Image != null)
                    MaximizeButton.Image.Dispose();
                MaximizeButton.Image = Resources.Images.GetImage("maximize_16px", bright);

                if (MinimizeButton.Image != null)
                    MinimizeButton.Image.Dispose();
                MinimizeButton.Image = Resources.Images.GetImage("minimize_16px", bright);
            }
            catch
            {

            }
        }

        private void SetColor()
        {
            bool l = Resources.Render.IsBrightColor(BackColor);
            Color foreColor = l ? Color.Black : Color.White;

            TitleLabel.ForeColor = foreColor;

            SetButtonColor(l);

            SetButtonImage(l);
            SetIconColor(l);
        }

        private void SetButtonColor(bool l)
        {
            Button[] buttons = new Button[] { IconButton, MinimizeButton, MaximizeButton };
            Color over, down;
            int d = 30, o = 10;

            if (l)
            {
                o *= -1;
                d *= -1;
            }

            down = Color.FromArgb(BackColor.A, BackColor.R + d, BackColor.G + d, BackColor.B + d);
            over = Color.FromArgb(BackColor.A, BackColor.R + o, BackColor.G + o, BackColor.B + o);

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].FlatAppearance.MouseDownBackColor = down;
                buttons[i].FlatAppearance.MouseOverBackColor = over;
            }
        }

        private void SetIconColor(bool bright)
        {
            if (_icon == null)
                return;

            if (bright)
                IconButton.Image = _icon;
            else
                IconButton.Image = _iconB;
        }

        private void TitleBar_BackColorChanged(object sender, EventArgs e)
        {
            SetColor();
        }

        private void TitleBarMouseDown(object sender, MouseEventArgs e)
        {
            if (Form != null)
                FormUtils.DragWindow(Form.Handle);
        }

        private void CloseClick(object sender, EventArgs e)
        {
            if (Form != null)
                Form.Close();
        }

        private void MaximizeClick(object sender, EventArgs e)
        {
            if (Form != null)
            {
                if (Form.WindowState != FormWindowState.Maximized)
                    Form.WindowState = FormWindowState.Maximized;
                else
                    Form.WindowState = FormWindowState.Normal;
            }
        }

        private void MinimizeClick(object sender, EventArgs e)
        {
            if (Form != null)
            {
                if (Form.WindowState != FormWindowState.Minimized)
                    Form.WindowState = FormWindowState.Minimized;
                else
                    Form.WindowState = FormWindowState.Normal;
            }
        }

        private void TitleBarMouseClick(object sender, MouseEventArgs e)
        {
            if (Form != null && e.Button == MouseButtons.Right)
                FormUtils.ShowSystemMenu(Form.Handle);
        }

        private void TitleBar_Load(object sender, EventArgs e)
        {
            if (Form == null)
                Form = ParentForm;

            MaximumSize = new Size(0, 35);

            Size = new Size(Size.Width, 35);
        }

        public string Title
        {
            get
            {
                return TitleLabel.Text;
            }
            set
            {
                TitleLabel.Text = value;
            }
        }

        public bool MinimizeBox
        {
            get
            {
                return MinimizeButton.Visible;
            }
            set
            {
                MinimizeButton.Visible = value;
            }
        }

        public bool MaximizeBox
        {
            get
            {
                return MaximizeButton.Visible;
            }
            set
            {
                MaximizeButton.Visible = value;
            }
        }

        public bool CloseBox
        {
            get
            {
                return CloseButton.Visible;
            }
            set
            {
                CloseButton.Visible = value;
            }
        }

        public Font ForeFont
        {
            get
            {
                return TitleLabel.Font;
            }
            set
            {
                TitleLabel.Font = value;
            }
        }

        public bool ChangeIconColor { get; set; } = true;

        private bool _icon_isBright;
        private Bitmap _iconB;
        private Bitmap _icon;
        public Bitmap Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                if (_icon != null)
                    _icon.Dispose();
                if (_iconB != null)
                    _iconB.Dispose();
                if (IconButton.Image != null)
                    IconButton.Image.Dispose();

                _icon_isBright = Resources.Render.IsBright(value);
                Bitmap f = Resources.Render.Reversal(value);

                if (_icon_isBright)
                {
                    _iconB = value;
                    _icon = f;
                }
                else
                {
                    _icon = value;
                    _iconB = f;
                }

                SetColor();
            }
        }

        private void IconButton_Click(object sender, EventArgs e)
        {
            IconClick?.Invoke(sender, e);
        }
    }
}