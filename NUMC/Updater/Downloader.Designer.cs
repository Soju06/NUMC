namespace NUMC.Updater
{
    partial class Downloader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.darkLabel1 = new System.Windows.Forms.Label();
            this.darkLabel2 = new System.Windows.Forms.Label();
            this.progressBar = new NUMC.Design.Controls.ProgressBar();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.CloseBox = true;
            this.titleBar.MaximumSize = new System.Drawing.Size(0, 35);
            this.titleBar.Size = new System.Drawing.Size(404, 35);
            // 
            // darkLabel1
            // 
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(12, 42);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(380, 17);
            this.darkLabel1.TabIndex = 4;
            this.darkLabel1.Text = "0 / 0 Bytes";
            // 
            // darkLabel2
            // 
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Location = new System.Drawing.Point(9, 100);
            this.darkLabel2.Name = "darkLabel2";
            this.darkLabel2.Size = new System.Drawing.Size(380, 17);
            this.darkLabel2.TabIndex = 4;
            this.darkLabel2.Text = "0%";
            this.darkLabel2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.Transparent;
            this.progressBar.Location = new System.Drawing.Point(12, 63);
            this.progressBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(380, 33);
            this.progressBar.TabIndex = 5;
            this.progressBar.Value = 0D;
            // 
            // Downloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 169);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.darkLabel2);
            this.Controls.Add(this.darkLabel1);
            this.DialogButtons = NUMC.Design.Controls.MessageBoxButtons.Close;
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Downloader";
            this.Text = "Downloader";
            this.Controls.SetChildIndex(this.titleBar, 0);
            this.Controls.SetChildIndex(this.darkLabel1, 0);
            this.Controls.SetChildIndex(this.darkLabel2, 0);
            this.Controls.SetChildIndex(this.progressBar, 0);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label darkLabel1;
        private System.Windows.Forms.Label darkLabel2;
        private Design.Controls.ProgressBar progressBar;
    }
}