namespace NUMC.Forms.Dialogs
{
    partial class ProgramInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgramInformation));
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.darkLabel2 = new DarkUI.Controls.DarkLabel();
            this.githubBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.githubBox)).BeginInit();
            this.SuspendLayout();
            // 
            // darkLabel1
            // 
            this.darkLabel1.Font = new System.Drawing.Font("Segoe UI Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel1.ForeColor = System.Drawing.Color.Gainsboro;
            this.darkLabel1.Location = new System.Drawing.Point(12, 34);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(456, 46);
            this.darkLabel1.TabIndex = 4;
            this.darkLabel1.Text = "NUMC";
            this.darkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // darkLabel2
            // 
            this.darkLabel2.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Location = new System.Drawing.Point(12, 80);
            this.darkLabel2.Name = "darkLabel2";
            this.darkLabel2.Size = new System.Drawing.Size(456, 22);
            this.darkLabel2.TabIndex = 4;
            this.darkLabel2.Text = "1.0.0.0";
            this.darkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // githubBox
            // 
            this.githubBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.githubBox.Image = ((System.Drawing.Image)(resources.GetObject("githubBox.Image")));
            this.githubBox.Location = new System.Drawing.Point(12, 106);
            this.githubBox.Name = "githubBox";
            this.githubBox.Size = new System.Drawing.Size(36, 36);
            this.githubBox.TabIndex = 5;
            this.githubBox.TabStop = false;
            this.githubBox.Click += new System.EventHandler(this.GithubBox_Click);
            // 
            // ProgramInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 154);
            this.ControlBox = false;
            this.Controls.Add(this.githubBox);
            this.Controls.Add(this.darkLabel2);
            this.Controls.Add(this.darkLabel1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgramInformation";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Information";
            this.Controls.SetChildIndex(this.darkLabel1, 0);
            this.Controls.SetChildIndex(this.darkLabel2, 0);
            this.Controls.SetChildIndex(this.githubBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.githubBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DarkUI.Controls.DarkLabel darkLabel1;
        private DarkUI.Controls.DarkLabel darkLabel2;
        private System.Windows.Forms.PictureBox githubBox;
    }
}