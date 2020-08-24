using DarkUI.Forms;

namespace NUMC.Desion
{
    public class NDialog : DarkDialog
    {
        public readonly Design.TitleBar titleBar;

        public NDialog()
        {
            titleBar = new Design.TitleBar();
            SuspendLayout();
            //
            // titleBar
            //
            titleBar.BackColor = System.Drawing.Color.FromArgb(32, 34, 37);
            titleBar.CloseBox = true;
            titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            titleBar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            titleBar.ForeColor = System.Drawing.Color.White;
            titleBar.Form = null;
            titleBar.Location = new System.Drawing.Point(0, 0);
            titleBar.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            titleBar.MaximizeBox = false;
            titleBar.MinimizeBox = false;
            titleBar.Name = "titleBar";
            titleBar.Size = new System.Drawing.Size(888, 28);
            titleBar.TabIndex = 3;
            titleBar.Title = "";
            //
            // NDialog
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            ClientSize = new System.Drawing.Size(888, 472);
            ControlBox = false;
            Controls.Add(this.titleBar);
            Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Controls.SetChildIndex(titleBar, 0);
            ResumeLayout(false);
        }
    }
}