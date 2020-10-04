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
            this.CodeTextBox = new NUMC.Design.Bright.BrightTextBox();
            this.ToolsMenuStrip = new NUMC.Design.Bright.BrightMenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditingModeCheckBox = new NUMC.Design.Bright.BrightCheckBox();
            this.CleanUpButton = new NUMC.Design.Bright.BrightButton();
            this.FindKeyButton = new NUMC.Design.Bright.BrightButton();
            this.TipBox = new System.Windows.Forms.ToolTip(this.components);
            this.ToolsMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.CloseBox = true;
            this.titleBar.MaximumSize = new System.Drawing.Size(0, 35);
            this.titleBar.Size = new System.Drawing.Size(1249, 30);
            // 
            // CodeTextBox
            // 
            this.CodeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CodeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.CodeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CodeTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodeTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.CodeTextBox.Location = new System.Drawing.Point(12, 62);
            this.CodeTextBox.Multiline = true;
            this.CodeTextBox.Name = "CodeTextBox";
            this.CodeTextBox.Size = new System.Drawing.Size(1225, 554);
            this.CodeTextBox.TabIndex = 4;
            this.CodeTextBox.TabStop = false;
            this.CodeTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CodeTextBox_KeyDown);
            // 
            // ToolsMenuStrip
            // 
            this.ToolsMenuStrip.AutoSize = false;
            this.ToolsMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ToolsMenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolsMenuStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ToolsMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.EditToolStripMenuItem});
            this.ToolsMenuStrip.Location = new System.Drawing.Point(0, 35);
            this.ToolsMenuStrip.Name = "ToolsMenuStrip";
            this.ToolsMenuStrip.Padding = new System.Windows.Forms.Padding(3, 2, 0, 2);
            this.ToolsMenuStrip.Size = new System.Drawing.Size(1249, 24);
            this.ToolsMenuStrip.TabIndex = 5;
            this.ToolsMenuStrip.Text = "darkMenuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.FileToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.FileToolStripMenuItem.Text = "File (&F)";
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.EditToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.EditToolStripMenuItem.Text = "Edit (&E)";
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
            this.CleanUpButton.Location = new System.Drawing.Point(127, 620);
            this.CleanUpButton.Name = "CleanUpButton";
            this.CleanUpButton.Padding = new System.Windows.Forms.Padding(5);
            this.CleanUpButton.Size = new System.Drawing.Size(117, 24);
            this.CleanUpButton.TabIndex = 7;
            this.CleanUpButton.Text = "Clean up Code";
            this.CleanUpButton.Click += new System.EventHandler(this.CleanUpButton_Click);
            // 
            // FindKeyButton
            // 
            this.FindKeyButton.Location = new System.Drawing.Point(265, 620);
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
            // JsonEditorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 691);
            this.Controls.Add(this.CleanUpButton);
            this.Controls.Add(this.FindKeyButton);
            this.Controls.Add(this.EditingModeCheckBox);
            this.Controls.Add(this.ToolsMenuStrip);
            this.Controls.Add(this.CodeTextBox);
            this.DialogButtons = NUMC.Design.Bright.MessageBoxButtons.OkCancel;
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "JsonEditorDialog";
            this.Text = "EditJsonDialog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditJsonDialog_FormClosing);
            this.Load += new System.EventHandler(this.EditJsonDialog_Load);
            this.Controls.SetChildIndex(this.CodeTextBox, 0);
            this.Controls.SetChildIndex(this.titleBar, 0);
            this.Controls.SetChildIndex(this.ToolsMenuStrip, 0);
            this.Controls.SetChildIndex(this.EditingModeCheckBox, 0);
            this.Controls.SetChildIndex(this.FindKeyButton, 0);
            this.Controls.SetChildIndex(this.CleanUpButton, 0);
            this.ToolsMenuStrip.ResumeLayout(false);
            this.ToolsMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Design.Bright.BrightTextBox CodeTextBox;
        private Design.Bright.BrightMenuStrip ToolsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private Design.Bright.BrightCheckBox EditingModeCheckBox;
        private Design.Bright.BrightButton CleanUpButton;
        private Design.Bright.BrightButton FindKeyButton;
        private System.Windows.Forms.ToolTip TipBox;
    }
}