using System.Drawing;

namespace NUMC.Design
{
    public class Dialog : Controls.Dialog
    {
        public Dialog()
        {
            SuspendLayout();
            //
            // NDialog
            //
            AutoScaleDimensions = new SizeF(7F, 17F);
            ClientSize = new Size(888, 472);
            ControlBox = false;
            Controls.Add(titleBar);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            titleBar.MaximizeBox = false;
            titleBar.MinimizeBox = false;
            Name = "NDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Controls.SetChildIndex(titleBar, 0);
            ResumeLayout(false);
        }
    }
}