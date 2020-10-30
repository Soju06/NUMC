using System;
using System.Drawing;
using System.Windows.Forms;

namespace NUMC.Forms.Controls
{
    public class KeyboardLayoutControl : Design.Controls.UserControl, IKeyboardLayout
    {
        new public event Click Click;

        new public event MouseClick MouseClick;

        new public event DoubleClick DoubleClick;

        private IKeyboardLayout _keyboardLayout;

        public IKeyboardLayout KeyboardLayout
        {
            get
            {
                return _keyboardLayout;
            }
            set
            {
                if (SetLayout(value))
                {
                    _keyboardLayout = value;
                    var parentForm = ParentForm;

                    if (parentForm != null)
                        CalcSize(parentForm);
                }
            }
        }

        public Keys[] VKeys
        {
            get
            {
                return null;
            }
        }

        public KeyboardLayoutControl()
        {
            SuspendLayout();
            BackColor = Color.Transparent;
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(20, 20, 20);
            Load += KeyboardLayoutControl_Load;

            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);

            ResumeLayout();
        }

        private void KeyboardLayoutControl_Load(object sender, EventArgs e)
        {
            var parentForm = ParentForm;

            if (parentForm != null)
            {
                SuspendLayout();
                CalcSize(parentForm);
                ResumeLayout();
            }

            InitializeLayout();
        }

        private void CalcSize(Form form)
        {
            Location = new Point(Constant.Form.Padding.Left, Constant.Form.Padding.Top);
            Size = new Size(form.Size.Width - (Constant.Form.Padding.Left + Constant.Form.Padding.Right),
                form.Size.Height - (Constant.Form.Padding.Top + Constant.Form.Padding.Bottom));

            if (_keyboardLayout == null)
                return;

            var control = (Design.Controls.UserControl)_keyboardLayout;
            var miniSize = control.MinimumSize.IsEmpty ? control.Size : control.MinimumSize;
            var maxSize = control.MaximumSize.IsEmpty ? control.Size : control.MaximumSize;
            var size = control.Size;

            form.MaximumSize = CalcSize(maxSize);
            form.MinimumSize = CalcSize(miniSize);
            form.Size = CalcSize(size);

            control.Size = size;
        }

        private Size CalcSize(Size insize)
        {
            return new Size(insize.Width + Constant.Form.Padding.Left + Constant.Form.Padding.Right,
                insize.Height + Constant.Form.Padding.Top + Constant.Form.Padding.Bottom);
        }

        private bool SetLayout(IKeyboardLayout layout)
        {
            if (layout == null || !layout.GetType().IsSubclassOf(typeof(Design.Controls.UserControl)))
                return false;

            SuspendLayout();
            ClearControls();

            var control = (Design.Controls.UserControl)layout;

            Controls.Add(control);

            layout.Click += Click;
            layout.DoubleClick += DoubleClick;
            layout.MouseClick += MouseClick;

            control.Location = new Point(0, 0);
            control.Dock = DockStyle.None;
            control.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;

            ResumeLayout();

            return true;
        }

        private void ClearControls()
        {
            for (int i = 0; i < Controls.Count; i++)
            {
                Controls.Remove(Controls[i]);
                //try
                //{
                //    var item = Controls[i];

                //    Controls.Remove(item);
                //    item.Dispose();
                //}
                //catch { }
            }
        }

        private void InitializeLayout()
        {
            IKeyboardLayout[] layouts = Plugin.Handler.ExtractPlugin<IKeyboardLayout>();

            if (layouts != null)
                for (int i = 0; i < layouts.Length; i++)
                {
                    if (layouts[i] != null && layouts[i].GetType().IsSubclassOf(typeof(Design.Controls.UserControl)))
                    {
                        KeyboardLayout = layouts[i];
                        break;
                    }
                }

            ChkPad();
        }

        private void ChkPad()
        {
            if (_keyboardLayout != null)
                return;

            KeyboardLayout = new DefaultLayout();
        }
    }
}