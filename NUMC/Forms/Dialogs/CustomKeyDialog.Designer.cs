namespace NUMC.Forms.Dialogs
{
    partial class CustomKeyDialog
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
            this.KeyboardTypeComboBox = new NUMC.Design.Controls.ComboBox();
            this.ScriptTextBox = new NUMC.Design.Controls.TextBox();
            this.ClearButton = new NUMC.Design.Controls.Button();
            this.AddButton = new NUMC.Design.Controls.Button();
            this.RemoveButton = new NUMC.Design.Controls.Button();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.CloseBox = true;
            this.titleBar.MaximumSize = new System.Drawing.Size(0, 35);
            this.titleBar.MinimumSize = new System.Drawing.Size(205, 35);
            this.titleBar.Size = new System.Drawing.Size(663, 35);
            // 
            // KeyboardTypeComboBox
            // 
            this.KeyboardTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KeyboardTypeComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.KeyboardTypeComboBox.FormattingEnabled = true;
            this.KeyboardTypeComboBox.Location = new System.Drawing.Point(12, 45);
            this.KeyboardTypeComboBox.Name = "KeyboardTypeComboBox";
            this.KeyboardTypeComboBox.Size = new System.Drawing.Size(639, 26);
            this.KeyboardTypeComboBox.TabIndex = 9;
            this.KeyboardTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.KeyboardTypeComboBox_SelectedIndexChanged);
            // 
            // ScriptTextBox
            // 
            this.ScriptTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScriptTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ScriptTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ScriptTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ScriptTextBox.Location = new System.Drawing.Point(12, 77);
            this.ScriptTextBox.MaxLength = 2000;
            this.ScriptTextBox.Multiline = true;
            this.ScriptTextBox.Name = "ScriptTextBox";
            this.ScriptTextBox.Size = new System.Drawing.Size(639, 254);
            this.ScriptTextBox.TabIndex = 10;
            this.ScriptTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyTextBox_KeyDown);
            this.ScriptTextBox.MouseEnter += new System.EventHandler(this.KeyTextBox_Enter);
            this.ScriptTextBox.MouseLeave += new System.EventHandler(this.KeyTextBox_Leave);
            // 
            // ClearButton
            // 
            this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearButton.Location = new System.Drawing.Point(552, 337);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Padding = new System.Windows.Forms.Padding(5);
            this.ClearButton.Size = new System.Drawing.Size(99, 27);
            this.ClearButton.TabIndex = 11;
            this.ClearButton.Text = "초기화";
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddButton.Location = new System.Drawing.Point(12, 337);
            this.AddButton.Name = "AddButton";
            this.AddButton.Padding = new System.Windows.Forms.Padding(5);
            this.AddButton.Size = new System.Drawing.Size(99, 27);
            this.AddButton.TabIndex = 12;
            this.AddButton.Text = "추가";
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveButton.Location = new System.Drawing.Point(117, 337);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Padding = new System.Windows.Forms.Padding(5);
            this.RemoveButton.Size = new System.Drawing.Size(99, 27);
            this.RemoveButton.TabIndex = 12;
            this.RemoveButton.Text = "제거";
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // CustomKeyDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 419);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.ScriptTextBox);
            this.Controls.Add(this.KeyboardTypeComboBox);
            this.Name = "CustomKeyDialog";
            this.Resizing = false;
            this.Text = "dd";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CustomKey_FormClosing);
            this.Load += new System.EventHandler(this.CustomKey_Load);
            this.Controls.SetChildIndex(this.titleBar, 0);
            this.Controls.SetChildIndex(this.KeyboardTypeComboBox, 0);
            this.Controls.SetChildIndex(this.ScriptTextBox, 0);
            this.Controls.SetChildIndex(this.ClearButton, 0);
            this.Controls.SetChildIndex(this.AddButton, 0);
            this.Controls.SetChildIndex(this.RemoveButton, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Design.Controls.ComboBox KeyboardTypeComboBox;
        private Design.Controls.TextBox ScriptTextBox;
        private Design.Controls.Button ClearButton;
        private Design.Controls.Button AddButton;
        private Design.Controls.Button RemoveButton;
    }
}