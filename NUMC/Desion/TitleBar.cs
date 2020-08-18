using System;
using System.Windows.Forms;
using WinUtils;

namespace Design
{
    public partial class TitleBar : UserControl
    {
        public Form Form { get; set; } = null;

        public TitleBar()
        {
            InitializeComponent();
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
    }
}