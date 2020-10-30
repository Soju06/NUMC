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
            this.CodeTextBox = new Design.Controls.TextBox();
            this.ToolsMenuStrip = new NUMC.Design.Controls.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditingModeCheckBox = new NUMC.Design.Controls.CheckBox();
            this.CleanUpButton = new NUMC.Design.Controls.Button();
            this.FindKeyButton = new NUMC.Design.Controls.Button();
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
            this.CodeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CodeTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.ToolsMenuStrip.Dock = System.Windows.Forms.DockStyle.None;
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
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.FileToolStripMenuItem.Text = "File (&F)";
            // 
            // EditToolStripMenuItem
            // 
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
            this.DialogButtons = NUMC.Design.Controls.MessageBoxButtons.OkCancel;
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

        private Design.Controls.TextBox CodeTextBox;
        private Design.Controls.MenuStrip ToolsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private Design.Controls.CheckBox EditingModeCheckBox;
        private Design.Controls.Button CleanUpButton;
        private Design.Controls.Button FindKeyButton;
        private System.Windows.Forms.ToolTip TipBox;
    }
}