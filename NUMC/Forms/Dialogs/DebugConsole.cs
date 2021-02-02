#if DEBUG

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUMC.Forms.Dialogs
{
    public class DebugConsole : Design.Form
    {
        private readonly TextBox textBox1;
        private readonly TextWriterTraceListener _writer;

        public DebugConsole()
        {
            textBox1 = new TextBox();

            SuspendLayout();

            textBox1.TextChanged += TextBox1_TextChanged;

            textBox1.Dock = DockStyle.Fill;
            textBox1.Multiline = true;
            textBox1.TabIndex = 1;
            textBox1.MaxLength = int.MaxValue;
            textBox1.Location = new System.Drawing.Point(2, 34);
            textBox1.ReadOnly = true;
            textBox1.BackColor = _styles.Control.BackgroundColor;
            textBox1.ForeColor = _styles.Control.Color;
            textBox1.Font = new System.Drawing.Font(Font.FontFamily, 13f, System.Drawing.FontStyle.Bold);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.WordWrap = false;
            ClientSize = new System.Drawing.Size(1100, 610);
            Name = "debug console";
            Text = "debug console";

            Controls.Add(textBox1);
            Controls.SetChildIndex(textBox1, 0);

            ResumeLayout(false);
            PerformLayout();
            Debug.Listeners.Add(_writer = new TextWriterTraceListener(new TextBoxWriter(textBox1)));

            FormClosing += DebugConsole_FormClosing;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= 100000)
                textBox1.Text = textBox1.Text.Substring((100000 / 3) - 10000);

            textBox1.SelectionStart = textBox1.TextLength;
            textBox1.ScrollToCaret();
        }

        private void DebugConsole_FormClosing(object sender, FormClosingEventArgs e) =>
            Debug.Listeners.Remove(_writer);
    }

    public class TextBoxWriter : TextWriter
    {
        private readonly Control _control;

        public TextBoxWriter(Control control) =>
            _control = control;

        public override void WriteLine() =>
            Invoke(() => { _control.Text += Environment.NewLine; });

        public override void WriteLine(string value) =>
            Invoke(() => { _control.Text += value + Environment.NewLine; });

        public override void Write(string value) =>
            Invoke(() => { _control.Text += value + Environment.NewLine; });

        private void Invoke(Action value) =>
            _control?.Invoke(value);

        public override Encoding Encoding => Encoding.UTF8;
    }
}

#endif