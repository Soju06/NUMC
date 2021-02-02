namespace NUMC.Forms.Dialogs
{
    partial class ReleaseDownloader
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
            this.components = new System.ComponentModel.Container();
            this.titleLabel = new NUMC.Design.Controls.Label();
            this.subtitleLabel = new NUMC.Design.Controls.Label();
            this.contentBox = new System.Windows.Forms.WebBrowser();
            this.loadingPanel = new System.Windows.Forms.Panel();
            this.loadingProgressBar = new NUMC.Design.Controls.ProgressBar();
            this.loadingLabel = new NUMC.Design.Controls.Label();
            this.documentTimer = new System.Windows.Forms.Timer(this.components);
            this.loadingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.FontSize = 10F;
            this.titleLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.titleLabel.Location = new System.Drawing.Point(2, 40);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(778, 36);
            this.titleLabel.TabIndex = 7;
            this.titleLabel.Text = "Title";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.subtitleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.subtitleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitleLabel.FontSize = 10F;
            this.subtitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.subtitleLabel.Location = new System.Drawing.Point(2, 76);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(778, 35);
            this.subtitleLabel.TabIndex = 8;
            this.subtitleLabel.Text = "Subtitle";
            this.subtitleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // contentBox
            // 
            this.contentBox.AllowWebBrowserDrop = false;
            this.contentBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentBox.IsWebBrowserContextMenuEnabled = false;
            this.contentBox.Location = new System.Drawing.Point(2, 111);
            this.contentBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.contentBox.MinimumSize = new System.Drawing.Size(20, 14);
            this.contentBox.Name = "contentBox";
            this.contentBox.Size = new System.Drawing.Size(778, 442);
            this.contentBox.TabIndex = 9;
            this.contentBox.Visible = false;
            this.contentBox.WebBrowserShortcutsEnabled = false;
            // 
            // loadingPanel
            // 
            this.loadingPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.loadingPanel.BackColor = System.Drawing.Color.Transparent;
            this.loadingPanel.Controls.Add(this.loadingProgressBar);
            this.loadingPanel.Controls.Add(this.loadingLabel);
            this.loadingPanel.Location = new System.Drawing.Point(98, 259);
            this.loadingPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loadingPanel.Name = "loadingPanel";
            this.loadingPanel.Padding = new System.Windows.Forms.Padding(5);
            this.loadingPanel.Size = new System.Drawing.Size(586, 77);
            this.loadingPanel.TabIndex = 10;
            // 
            // loadingProgressBar
            // 
            this.loadingProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadingProgressBar.Animation = true;
            this.loadingProgressBar.AnimationMoveSpeed = 0.015D;
            this.loadingProgressBar.AnimationTickSpeed = 15;
            this.loadingProgressBar.Border = 1;
            this.loadingProgressBar.Location = new System.Drawing.Point(8, 7);
            this.loadingProgressBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loadingProgressBar.MarqueeValue = 1D;
            this.loadingProgressBar.Name = "loadingProgressBar";
            this.loadingProgressBar.Size = new System.Drawing.Size(570, 35);
            this.loadingProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.loadingProgressBar.TabIndex = 1;
            this.loadingProgressBar.Value = 0D;
            // 
            // loadingLabel
            // 
            this.loadingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadingLabel.BackColor = System.Drawing.Color.Transparent;
            this.loadingLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.loadingLabel.FontSize = 12F;
            this.loadingLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.loadingLabel.Location = new System.Drawing.Point(8, 44);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(570, 28);
            this.loadingLabel.TabIndex = 0;
            this.loadingLabel.Text = "Please wait...";
            // 
            // documentTimer
            // 
            this.documentTimer.Interval = 1000;
            this.documentTimer.Tick += new System.EventHandler(this.DocumentTimer_Tick);
            // 
            // ReleaseDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 605);
            this.Controls.Add(this.loadingPanel);
            this.Controls.Add(this.contentBox);
            this.Controls.Add(this.subtitleLabel);
            this.Controls.Add(this.titleLabel);
            this.DialogButtons = NUMC.Design.Controls.MessageBoxButtons.OkCancel;
            this.Name = "ReleaseDownloader";
            this.Padding = new System.Windows.Forms.Padding(2, 40, 2, 2);
            this.Text = "Downloader";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReleaseDownloader_FormClosed);
            this.Load += new System.EventHandler(this.ReleaseDownloader_Load);
            this.Shown += new System.EventHandler(this.ReleaseDownloader_Shown);
            this.Controls.SetChildIndex(this.titleLabel, 0);
            this.Controls.SetChildIndex(this.subtitleLabel, 0);
            this.Controls.SetChildIndex(this.contentBox, 0);
            this.Controls.SetChildIndex(this.loadingPanel, 0);
            this.loadingPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser contentBox;
        private System.Windows.Forms.Panel loadingPanel;
        public Design.Controls.Label titleLabel;
        public Design.Controls.Label subtitleLabel;
        public Design.Controls.Label loadingLabel;
        public Design.Controls.ProgressBar loadingProgressBar;
        private System.Windows.Forms.Timer documentTimer;
    }
}