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
            this.ApplicationContextMenu = new DarkUI.Controls.DarkContextMenu();
            this.JsonEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NUMContextMenu = new DarkUI.Controls.DarkContextMenu();
            this.CustomKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MacroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyIconContextMenu = new DarkUI.Controls.DarkContextMenu();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartProgramMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.LanguageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.NExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GCTimer = new System.Windows.Forms.Timer(this.components);
            this.NumPadUI = new NUMC.Desion.NUMPadUI();
            this.TitleBar = new Design.TitleBar();
            this.InfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ApplicationContextMenu.SuspendLayout();
            this.NUMContextMenu.SuspendLayout();
            this.NotifyIconContextMenu.SuspendLayout();
            this.SuspendLayout();
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
            this.JsonEditToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.JsonEditToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.JsonEditToolStripMenuItem.Name = "JsonEditToolStripMenuItem";
            this.JsonEditToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.JsonEditToolStripMenuItem.Tag = "JsonEdit";
            this.JsonEditToolStripMenuItem.Text = "Json 편집기";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(134, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ExitToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.ExitToolStripMenuItem.Tag = "Exit";
            this.ExitToolStripMenuItem.Text = "종료";
            // 
            // NUMContextMenu
            // 
            this.NUMContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.NUMContextMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.NUMContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CustomKeyToolStripMenuItem,
            this.MacroToolStripMenuItem,
            this.toolStripSeparator1});
            this.NUMContextMenu.Name = "NUMContextMenu";
            this.NUMContextMenu.Size = new System.Drawing.Size(164, 55);
            // 
            // CustomKeyToolStripMenuItem
            // 
            this.CustomKeyToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.CustomKeyToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.CustomKeyToolStripMenuItem.Name = "CustomKeyToolStripMenuItem";
            this.CustomKeyToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.CustomKeyToolStripMenuItem.Text = "사용자 지정 키...";
            // 
            // MacroToolStripMenuItem
            // 
            this.MacroToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.MacroToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.MacroToolStripMenuItem.Name = "MacroToolStripMenuItem";
            this.MacroToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.MacroToolStripMenuItem.Text = "매크로...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.NotifyIconContextMenu;
            this.notifyIcon.Icon = global::NUMC.Desion.Images.NUMC_SMALL_ICON;
            this.notifyIcon.Text = "NUMC Service";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseClick);
            // 
            // NotifyIconContextMenu
            // 
            this.NotifyIconContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.NotifyIconContextMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.NotifyIconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.StartProgramMenuItem,
            this.InfoToolStripMenuItem,
            this.toolStripSeparator3,
            this.LanguageMenuItem,
            this.toolStripSeparator4,
            this.NExitToolStripMenuItem});
            this.NotifyIconContextMenu.Name = "NotifyIconContextMenu";
            this.NotifyIconContextMenu.Size = new System.Drawing.Size(151, 128);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.OpenToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.OpenToolStripMenuItem.Tag = "Open";
            this.OpenToolStripMenuItem.Text = "열기";
            // 
            // StartProgramMenuItem
            // 
            this.StartProgramMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.StartProgramMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.StartProgramMenuItem.Name = "StartProgramMenuItem";
            this.StartProgramMenuItem.Size = new System.Drawing.Size(150, 22);
            this.StartProgramMenuItem.Tag = "StartProgram";
            this.StartProgramMenuItem.Text = "시작 프로그램";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(147, 6);
            // 
            // LanguageMenuItem
            // 
            this.LanguageMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.LanguageMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.LanguageMenuItem.Name = "LanguageMenuItem";
            this.LanguageMenuItem.Size = new System.Drawing.Size(150, 22);
            this.LanguageMenuItem.Text = "Language";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator4.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(147, 6);
            // 
            // NExitToolStripMenuItem
            // 
            this.NExitToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.NExitToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.NExitToolStripMenuItem.Name = "NExitToolStripMenuItem";
            this.NExitToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.NExitToolStripMenuItem.Tag = "Exit";
            this.NExitToolStripMenuItem.Text = "종료";
            // 
            // GCTimer
            // 
            this.GCTimer.Interval = 100000;
            this.GCTimer.Tick += new System.EventHandler(this.GCTimer_Tick);
            // 
            // NumPadUI
            // 
            this.NumPadUI.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NumPadUI.BackColor = System.Drawing.Color.Transparent;
            this.NumPadUI.ContextMenuStrip = this.ApplicationContextMenu;
            this.NumPadUI.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.NumPadUI.Location = new System.Drawing.Point(7, 35);
            this.NumPadUI.Name = "NumPadUI";
            this.NumPadUI.Size = new System.Drawing.Size(388, 397);
            this.NumPadUI.TabIndex = 1;
            // 
            // TitleBar
            // 
            this.TitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.TitleBar.CloseBox = true;
            this.TitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleBar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleBar.ForeColor = System.Drawing.Color.White;
            this.TitleBar.Form = null;
            this.TitleBar.Location = new System.Drawing.Point(0, 0);
            this.TitleBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TitleBar.MaximizeBox = false;
            this.TitleBar.MinimizeBox = false;
            this.TitleBar.MinimumSize = new System.Drawing.Size(404, 27);
            this.TitleBar.Name = "TitleBar";
            this.TitleBar.Size = new System.Drawing.Size(404, 27);
            this.TitleBar.TabIndex = 0;
            this.TitleBar.Title = "";
            // 
            // InfoToolStripMenuItem
            // 
            this.InfoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.InfoToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem";
            this.InfoToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.InfoToolStripMenuItem.Tag = "Info";
            this.InfoToolStripMenuItem.Text = "정보";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(403, 440);
            this.ContextMenuStrip = this.ApplicationContextMenu;
            this.Controls.Add(this.NumPadUI);
            this.Controls.Add(this.TitleBar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = global::NUMC.Desion.Images.NUMC_ICON;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximumSize = new System.Drawing.Size(810, 710);
            this.MinimumSize = new System.Drawing.Size(403, 440);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.ApplicationContextMenu.ResumeLayout(false);
            this.NUMContextMenu.ResumeLayout(false);
            this.NotifyIconContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Design.TitleBar TitleBar;
        private Desion.NUMPadUI NumPadUI;
        private DarkUI.Controls.DarkContextMenu NUMContextMenu;
        private System.Windows.Forms.ToolStripMenuItem CustomKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private DarkUI.Controls.DarkContextMenu ApplicationContextMenu;
        private System.Windows.Forms.ToolStripMenuItem JsonEditToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private DarkUI.Controls.DarkContextMenu NotifyIconContextMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem NExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StartProgramMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LanguageMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem MacroToolStripMenuItem;
        private System.Windows.Forms.Timer GCTimer;
        private System.Windows.Forms.ToolStripMenuItem InfoToolStripMenuItem;
    }
}

