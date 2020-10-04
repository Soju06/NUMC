namespace NUMC
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ApplicationContextMenu = new NUMC.Design.Bright.BrightContextMenu();
            this.JsonEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyIconContextMenu = new NUMC.Design.Bright.BrightContextMenu();
            this.NumPadUI = new NUMC.Design.NUMPadUI();
            this.NUMContextMenu = new NUMC.Design.Bright.BrightContextMenu();
            this.ApplicationContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.CloseBox = true;
            this.titleBar.Form = this;
            this.titleBar.MaximizeBox = true;
            this.titleBar.MinimizeBox = true;
            this.titleBar.MinimumSize = new System.Drawing.Size(135, 35);
            this.titleBar.Size = new System.Drawing.Size(406, 35);
            // 
            // ApplicationContextMenu
            // 
            this.ApplicationContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ApplicationContextMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ApplicationContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.JsonEditToolStripMenuItem,
            this.toolStripSeparator2,
            this.ExitToolStripMenuItem});
            this.ApplicationContextMenu.Name = "ApplicationContextMenu";
            this.ApplicationContextMenu.Size = new System.Drawing.Size(138, 55);
            // 
            // JsonEditToolStripMenuItem
            // 
            this.JsonEditToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.JsonEditToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.JsonEditToolStripMenuItem.Name = "JsonEditToolStripMenuItem";
            this.JsonEditToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.JsonEditToolStripMenuItem.Tag = "JsonEdit";
            this.JsonEditToolStripMenuItem.Text = "Json 편집기";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.toolStripSeparator2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(134, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ExitToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.ExitToolStripMenuItem.Tag = "Exit";
            this.ExitToolStripMenuItem.Text = "종료";
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.NotifyIconContextMenu;
            this.notifyIcon.Icon = global::NUMC.Design.Images.NUMC_SMALL_ICON;
            this.notifyIcon.Text = "NUMC Service";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseClick);
            // 
            // NotifyIconContextMenu
            // 
            this.NotifyIconContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.NotifyIconContextMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.NotifyIconContextMenu.Name = "NotifyIconContextMenu";
            this.NotifyIconContextMenu.Size = new System.Drawing.Size(181, 26);
            // 
            // NumPadUI
            // 
            this.NumPadUI.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NumPadUI.BackColor = System.Drawing.Color.Transparent;
            this.NumPadUI.ContextMenuStrip = this.ApplicationContextMenu;
            this.NumPadUI.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.NumPadUI.Location = new System.Drawing.Point(12, 42);
            this.NumPadUI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NumPadUI.Name = "NumPadUI";
            this.NumPadUI.Size = new System.Drawing.Size(382, 392);
            this.NumPadUI.TabIndex = 1;
            // 
            // NUMContextMenu
            // 
            this.NUMContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.NUMContextMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.NUMContextMenu.Name = "NUMContextMenu";
            this.NUMContextMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(406, 445);
            this.ContextMenuStrip = this.ApplicationContextMenu;
            this.Controls.Add(this.NumPadUI);
            this.Icon = global::NUMC.Design.Images.NUMC_ICON;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximumSize = new System.Drawing.Size(709, 603);
            this.MinimumSize = new System.Drawing.Size(406, 445);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Controls.SetChildIndex(this.NumPadUI, 0);
            this.Controls.SetChildIndex(this.titleBar, 0);
            this.ApplicationContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Design.NUMPadUI NumPadUI;
        private Design.Bright.BrightContextMenu ApplicationContextMenu;
        private System.Windows.Forms.ToolStripMenuItem JsonEditToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private Design.Bright.BrightContextMenu NUMContextMenu;
        private Design.Bright.BrightContextMenu NotifyIconContextMenu;
    }
}

