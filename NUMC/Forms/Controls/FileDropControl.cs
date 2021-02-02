using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NUMC.Forms.Controls
{
    public partial class FileDropControl : Design.Controls.UserControl
    {
        public event EventHandler FileChanged;

        public string Filter { get; set; }
        public string File { get; set; }
        public string[] AllowExtensions { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new string Text { get => _text; set { _text = value; Invalidate(); } }

        private string _text;

        public FileDropControl() {
            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer |
                    ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                    ControlStyles.SupportsTransparentBackColor, true);

            Text = Language.Language.FileDropControl_Text;
            AllowDrop = true;

            Click += Drop_Click;
            DragEnter += Drag_Enter;
            DragDrop += Drag_Drop;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            var sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            base.OnPaintBackground(e);

            //using (var sb = new SolidBrush(BackColor))
            //    g.FillRectangle(sb, ClientRectangle);

            using (var sb = new SolidBrush(ForeColor))
                g.DrawString(Text,
                    Font, sb, ClientRectangle, sf);
        }

        private void Drop_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog()) {
                dialog.Filter = Filter;
                if (dialog.ShowDialog() == DialogResult.OK)
                    ConfirmProcessing(dialog.FileName);
            }
        }

        private void Drag_Enter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else e.Effect = DragDropEffects.None;
        }

        private void Drag_Drop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length >= 1)
                ConfirmProcessing(files[0]);
        }

        private void ConfirmProcessing(string file)
        {
            if (!System.IO.File.Exists(file))
                return;

            try
            {
                FileInfo info = new FileInfo(file);

                if (AllowExtensions != null && (!AllowExtensions.Contains(info.Extension) || AllowExtensions.Length == 0))
                    return;

                Text = info.Name;

                File = info.FullName;
                FileChanged?.Invoke(this, null);
            }
            catch { }
        }
    }
}