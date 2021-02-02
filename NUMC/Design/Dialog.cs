using System.Drawing;

namespace NUMC.Design
{
    public class Dialog : Controls.Dialog
    {
        public Dialog()
        {
            SuspendLayout();
            //
            // Dialog
            //
            AutoScaleDimensions = new SizeF(7F, 17F);
            ClientSize = new Size(888, 472);
            ControlBox = false;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Dialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ResumeLayout(false);
        }
    }
}