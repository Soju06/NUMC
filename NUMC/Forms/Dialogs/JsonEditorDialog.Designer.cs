namespace NUMC.Forms.Dialogs
{
    partial class JsonEditorDialog
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
            this.CodeTextBox = new DarkUI.Controls.DarkTextBox();
            this.ToolsMenuStrip = new DarkUI.Controls.DarkMenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAndApplyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewCustomKeyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewWhiteListKeyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditingModeCheckBox = new DarkUI.Controls.DarkCheckBox();
            this.CleanUpButton = new DarkUI.Controls.DarkButton();
            this.FindKeyButton = new DarkUI.Controls.DarkButton();
            this.TipBox = new System.Windows.Forms.ToolTip(this.components);
            this.FindVirtualKeyButton = new DarkUI.Controls.DarkButton();
            this.ToolsMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // CodeTextBox
            // 
            this.CodeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CodeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.CodeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CodeTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodeTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.CodeTextBox.Location = new System.Drawing.Point(12, 56);
            this.CodeTextBox.Multiline = true;
            this.CodeTextBox.Name = "CodeTextBox";
            this.CodeTextBox.Size = new System.Drawing.Size(1225, 560);
            this.CodeTextBox.TabIndex = 4;
            this.CodeTextBox.TabStop = false;
            this.CodeTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CodeTextBox_KeyDown);
            // 
            // ToolsMenuStrip
            // 
            this.ToolsMenuStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ToolsMenuStrip.AutoSize = false;
            this.ToolsMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ToolsMenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolsMenuStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ToolsMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.EditToolStripMenuItem});
            this.ToolsMenuStrip.Location = new System.Drawing.Point(0, 29);
            this.ToolsMenuStrip.Name = "ToolsMenuStrip";
            this.ToolsMenuStrip.Padding = new System.Windows.Forms.Padding(3, 2, 0, 2);
            this.ToolsMenuStrip.Size = new System.Drawing.Size(1249, 24);
            this.ToolsMenuStrip.TabIndex = 5;
            this.ToolsMenuStrip.Text = "darkMenuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveMenuItem,
            this.SaveAndApplyMenuItem,
            this.toolStripSeparator1,
            this.ExitMenuItem});
            this.FileToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.FileToolStripMenuItem.Text = "File (&F)";
            // 
            // SaveMenuItem
            // 
            this.SaveMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.SaveMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.SaveMenuItem.Name = "SaveMenuItem";
            this.SaveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveMenuItem.Size = new System.Drawing.Size(222, 22);
            this.SaveMenuItem.Tag = "Save";
            this.SaveMenuItem.Text = "Save (&S)";
            // 
            // SaveAndApplyMenuItem
            // 
            this.SaveAndApplyMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.SaveAndApplyMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.SaveAndApplyMenuItem.Name = "SaveAndApplyMenuItem";
            this.SaveAndApplyMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.SaveAndApplyMenuItem.Size = new System.Drawing.Size(222, 22);
            this.SaveAndApplyMenuItem.Tag = "SaveAndApply";
            this.SaveAndApplyMenuItem.Text = "Save And Apply (&A)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(219, 6);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ExitMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.ExitMenuItem.Size = new System.Drawing.Size(222, 22);
            this.ExitMenuItem.Tag = "Exit";
            this.ExitMenuItem.Text = "Exit";
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewCustomKeyMenuItem,
            this.NewWhiteListKeyMenuItem});
            this.EditToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.EditToolStripMenuItem.Text = "Edit (&E)";
            // 
            // NewCustomKeyMenuItem
            // 
            this.NewCustomKeyMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.NewCustomKeyMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.NewCustomKeyMenuItem.Name = "NewCustomKeyMenuItem";
            this.NewCustomKeyMenuItem.Size = new System.Drawing.Size(184, 22);
            this.NewCustomKeyMenuItem.Tag = "NewCustomKey";
            this.NewCustomKeyMenuItem.Text = "New CustomKey (&N)";
            // 
            // NewWhiteListKeyMenuItem
            // 
            this.NewWhiteListKeyMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.NewWhiteListKeyMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.NewWhiteListKeyMenuItem.Name = "NewWhiteListKeyMenuItem";
            this.NewWhiteListKeyMenuItem.Size = new System.Drawing.Size(184, 22);
            this.NewWhiteListKeyMenuItem.Tag = "NewWhiteListKey";
            this.NewWhiteListKeyMenuItem.Text = "New WhiteList Key";
            // 
            // EditingModeCheckBox
            // 
            this.EditingModeCheckBox.AutoSize = true;
            this.EditingModeCheckBox.Location = new System.Drawing.Point(12, 622);
            this.EditingModeCheckBox.Name = "EditingModeCheckBox";
            this.EditingModeCheckBox.Size = new System.Drawing.Size(108, 21);
            this.EditingModeCheckBox.TabIndex = 6;
            this.EditingModeCheckBox.Text = "Editing Mode";
            this.EditingModeCheckBox.CheckedChanged += new System.EventHandler(this.EditingModeCheckBox_CheckedChanged);
            // 
            // CleanUpButton
            // 
            this.CleanUpButton.Enabled = false;
            this.CleanUpButton.Location = new System.Drawing.Point(126, 621);
            this.CleanUpButton.Name = "CleanUpButton";
            this.CleanUpButton.Padding = new System.Windows.Forms.Padding(5);
            this.CleanUpButton.Size = new System.Drawing.Size(117, 24);
            this.CleanUpButton.TabIndex = 7;
            this.CleanUpButton.Text = "Clean up Code";
            this.CleanUpButton.Click += new System.EventHandler(this.CleanUpButton_Click);
            // 
            // FindKeyButton
            // 
            this.FindKeyButton.Location = new System.Drawing.Point(249, 621);
            this.FindKeyButton.Name = "FindKeyButton";
            this.FindKeyButton.Padding = new System.Windows.Forms.Padding(5);
            this.FindKeyButton.Size = new System.Drawing.Size(127, 24);
            this.FindKeyButton.TabIndex = 7;
            this.FindKeyButton.Text = "Find Keys Name";
            this.FindKeyButton.Click += new System.EventHandler(this.FindKeyButton_Click);
            // 
            // TipBox
            // 
            this.TipBox.AutoPopDelay = 10000;
            this.TipBox.InitialDelay = 50;
            this.TipBox.IsBalloon = true;
            this.TipBox.ReshowDelay = 100;
            this.TipBox.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TipBox.ToolTipTitle = "Info...";
            // 
            // FindVirtualKeyButton
            // 
            this.FindVirtualKeyButton.Location = new System.Drawing.Point(382, 621);
            this.FindVirtualKeyButton.Name = "FindVirtualKeyButton";
            this.FindVirtualKeyButton.Padding = new System.Windows.Forms.Padding(5);
            this.FindVirtualKeyButton.Size = new System.Drawing.Size(168, 24);
            this.FindVirtualKeyButton.TabIndex = 7;
            this.FindVirtualKeyButton.Text = "Find Virtual Keys Name";
            this.FindVirtualKeyButton.Click += new System.EventHandler(this.FindVirtualKeyButton_Click);
            // 
            // JsonEditorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 691);
            this.ControlBox = false;
            this.Controls.Add(this.FindVirtualKeyButton);
            this.Controls.Add(this.FindKeyButton);
            this.Controls.Add(this.CleanUpButton);
            this.Controls.Add(this.EditingModeCheckBox);
            this.Controls.Add(this.CodeTextBox);
            this.Controls.Add(this.ToolsMenuStrip);
            this.DialogButtons = DarkUI.Forms.DarkDialogButton.OkCancel;
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JsonEditorDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditJsonDialog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditJsonDialog_FormClosing);
            this.Load += new System.EventHandler(this.EditJsonDialog_Load);
            this.Controls.SetChildIndex(this.ToolsMenuStrip, 0);
            this.Controls.SetChildIndex(this.CodeTextBox, 0);
            this.Controls.SetChildIndex(this.EditingModeCheckBox, 0);
            this.Controls.SetChildIndex(this.CleanUpButton, 0);
            this.Controls.SetChildIndex(this.FindKeyButton, 0);
            this.Controls.SetChildIndex(this.FindVirtualKeyButton, 0);
            this.ToolsMenuStrip.ResumeLayout(false);
            this.ToolsMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DarkUI.Controls.DarkTextBox CodeTextBox;
        private DarkUI.Controls.DarkMenuStrip ToolsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAndApplyMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewCustomKeyMenuItem;
        private DarkUI.Controls.DarkCheckBox EditingModeCheckBox;
        private DarkUI.Controls.DarkButton CleanUpButton;
        private System.Windows.Forms.ToolStripMenuItem NewWhiteListKeyMenuItem;
        private DarkUI.Controls.DarkButton FindKeyButton;
        private System.Windows.Forms.ToolTip TipBox;
        private DarkUI.Controls.DarkButton FindVirtualKeyButton;
    }
}