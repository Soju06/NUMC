using System;
using System.Drawing;
using System.Windows.Forms;
using NUMC.Expansion;
using NUMC.Plugin.KeyboardLayout;

namespace TestPlugin
{
    public partial class NUMPadLayout : NUMC.Design.Controls.UserControl, IKeyboardLayout
    {
        public new event MouseClickEventHandler MouseClick;

        public event LayoutMenuShowEventHandler LayoutMenuShow;

        public Keys[] VKeys { get; } = new Keys[]
        {
            Keys.NumLock,
            Keys.Divide,
            Keys.Multiply,
            Keys.Subtract,
            Keys.NumPad7,
            Keys.NumPad8,
            Keys.NumPad9,
            Keys.Add,
            Keys.NumPad4,
            Keys.NumPad5,
            Keys.NumPad6,
            Keys.NumPad1,
            Keys.NumPad2,
            Keys.NumPad3,
            Keys.Return,
            Keys.NumPad0,
            Keys.Decimal
        };

        public new string Name { get => "teeeeeeeeeeeeeeesssssst"; }

        public int Index { get => -1; }

        public NUMPadLayout()
        {
            InitializeComponent();
            InitializeButtons();
            InitializeEvents();

            for (int i = 0; i < Controls.Count; i++)
                Controls[i].Tag = VKeys[i];
        }

        private void InitializeButtons()
        {
            var buttonType = typeof(Button);

            for (int i = 0; i < Controls.Count; i++)
            {
                var control = Controls[i];

                if (control == null || control.GetType() != buttonType)
                    return;
                    var button = (Button)control;

                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(48, 48, 48);
                    button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(40, 40, 40);
                    button.FlatAppearance.BorderSize = 0; 
                    button.ForeColor = System.Drawing.Color.FromArgb(237, 237, 237);
            }

            var baseFont = Font;

            // Num Button
            Button1.Font = new System.Drawing.Font(baseFont.FontFamily, 16F, baseFont.Style);
            // Enter Button
            Button15.Font = new System.Drawing.Font(baseFont.FontFamily, 16F, baseFont.Style);
        }

        private void InitializeEvents()
        {
            for (int i = 0; i < Controls.Count; i++)
                Controls[i].MouseUp += NUMPadUI_MouseUp;
            MouseUp += NUMPadUI_MouseUp;
        }
        
        private void NUMPadUI_MouseUp(object sender, MouseEventArgs e) {
            var parentForm = ParentForm;
            if (parentForm == null || new Rectangle(parentForm.Location, parentForm.Size).Contains(MousePosition)) {
                var k = sender != this ? VKeys[Controls.IndexOf((Control)sender)] : Keys.None;
                if (e.Button == MouseButtons.Left) LayoutMenuShow?.Invoke(k, MousePosition);
                MouseClick?.Invoke(k, e.Button);
            }
        }

        public void LayoutLoad() { }

        public void LayoutRemove() { }
    }
}