namespace NUMC.Plugins.PluginManager
{
    partial class PluginManagerDialog
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
            this._classView = new NUMC.Design.Controls.TreeView();
            this._pluginsView = new NUMC.Plugins.PluginManager.PluginManagerViewControl();
            this.loadingPanel = new System.Windows.Forms.Panel();
            this.loadingProgressBar = new NUMC.Design.Controls.ProgressBar();
            this.loadingLabel = new NUMC.Design.Controls.Label();
            this.loadingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _classView
            // 
            this._classView.BackColor = System.Drawing.Color.Transparent;
            this._classView.Dock = System.Windows.Forms.DockStyle.Left;
            this._classView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this._classView.ItemHeight = 25;
            this._classView.Location = new System.Drawing.Point(2, 38);
            this._classView.Margin = new System.Windows.Forms.Padding(5);
            this._classView.MaxDragChange = 20;
            this._classView.Name = "_classView";
            this._classView.Size = new System.Drawing.Size(240, 624);
            this._classView.TabIndex = 2;
            this._classView.Text = "treeView1";
            // 
            // _pluginsView
            // 
            this._pluginsView.AutoResize = true;
            this._pluginsView.BackColor = System.Drawing.Color.Transparent;
            this._pluginsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pluginsView.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._pluginsView.FontSize = 10F;
            this._pluginsView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this._pluginsView.ItemHeight = 130;
            this._pluginsView.ItemMargin = new System.Windows.Forms.Padding(2);
            this._pluginsView.Location = new System.Drawing.Point(242, 38);
            this._pluginsView.Name = "_pluginsView";
            this._pluginsView.ScrollIndex = 0;
            this._pluginsView.SelectedIndex = -1;
            this._pluginsView.ShownCount = 5;
            this._pluginsView.Size = new System.Drawing.Size(864, 624);
            this._pluginsView.TabIndex = 3;
            this._pluginsView.ItemDoubleClick += new NUMC.Plugins.PluginManager.PluginViewItemDoubleClickEventHandler(this.PluginsView_ItemDoubleClick);
            this._pluginsView.ItemButtonClick += new NUMC.Plugins.PluginManager.PluginViewItemButtonClickEventHandler(this.PluginsView_ItemButtonClick);
            // 
            // loadingPanel
            // 
            this.loadingPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.loadingPanel.BackColor = System.Drawing.Color.Transparent;
            this.loadingPanel.Controls.Add(this.loadingProgressBar);
            this.loadingPanel.Controls.Add(this.loadingLabel);
            this.loadingPanel.Location = new System.Drawing.Point(377, 281);
            this.loadingPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loadingPanel.Name = "loadingPanel";
            this.loadingPanel.Padding = new System.Windows.Forms.Padding(5);
            this.loadingPanel.Size = new System.Drawing.Size(595, 77);
            this.loadingPanel.TabIndex = 11;
            this.loadingPanel.Visible = false;
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
            this.loadingProgressBar.Size = new System.Drawing.Size(579, 35);
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
            this.loadingLabel.Size = new System.Drawing.Size(579, 28);
            this.loadingLabel.TabIndex = 0;
            this.loadingLabel.Text = "Please wait...";
            // 
            // PluginManagerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 665);
            this.Controls.Add(this.loadingPanel);
            this.Controls.Add(this._pluginsView);
            this.Controls.Add(this._classView);
            this.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(760, 462);
            this.Name = "PluginManagerDialog";
            this.Padding = new System.Windows.Forms.Padding(2, 38, 2, 3);
            this.Text = "PluginManagerDialog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PluginManagerDialog_FormClosing);
            this.loadingPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Design.Controls.TreeView _classView;
        private PluginManagerViewControl _pluginsView;
        private System.Windows.Forms.Panel loadingPanel;
        public Design.Controls.ProgressBar loadingProgressBar;
        public Design.Controls.Label loadingLabel;
    }
}