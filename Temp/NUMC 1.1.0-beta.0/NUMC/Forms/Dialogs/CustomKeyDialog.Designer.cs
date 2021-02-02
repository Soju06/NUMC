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
            this.components = new System.ComponentModel.Container();
            this.KeyboardTypeComboBox = new NUMC.Design.Bright.BrightComboBox();
            this.ScriptTextBox = new NUMC.Design.Bright.BrightTextBox();
            this.ClearButton = new NUMC.Design.Bright.BrightButton();
            this.AddButton = new NUMC.Design.Bright.BrightButton();
            this.RemoveButton = new NUMC.Design.Bright.BrightButton();
            this.TipBox = new System.Windows.Forms.ToolTip(this.components);
            this.TipLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.CloseBox = true;
            this.titleBar.MaximumSize = new System.Drawing.Size(0, 35);
            this.titleBar.MinimumSize = new System.Drawing.Size(205, 35);
            this.titleBar.Size = new System.Drawing.Size(817, 35);
            // 
            // KeyboardTypeComboBox
            // 
            this.KeyboardTypeComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.KeyboardTypeComboBox.FormattingEnabled = true;
            this.KeyboardTypeComboBox.Location = new System.Drawing.Point(12, 45);
            this.KeyboardTypeComboBox.Name = "KeyboardTypeComboBox";
            this.KeyboardTypeComboBox.Size = new System.Drawing.Size(388, 26);
            this.KeyboardTypeComboBox.TabIndex = 9;
            this.KeyboardTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.KeyboardTypeComboBox_SelectedIndexChanged);
            // 
            // ScriptTextBox
            // 
            this.ScriptTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScriptTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ScriptTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ScriptTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ScriptTextBox.Location = new System.Drawing.Point(12, 155);
            this.ScriptTextBox.MaxLength = 2000;
            this.ScriptTextBox.Multiline = true;
            this.ScriptTextBox.Name = "ScriptTextBox";
            this.ScriptTextBox.Size = new System.Drawing.Size(793, 273);
            this.ScriptTextBox.TabIndex = 10;
            this.ScriptTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyTextBox_KeyDown);
            this.ScriptTextBox.MouseEnter += new System.EventHandler(this.KeyTextBox_Enter);
            this.ScriptTextBox.MouseLeave += new System.EventHandler(this.KeyTextBox_Leave);
            this.ScriptTextBox.MouseHover += new System.EventHandler(this.KeyTextBox_MouseHover);
            // 
            // ClearButton
            // 
            this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearButton.Location = new System.Drawing.Point(12, 122);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Padding = new System.Windows.Forms.Padding(5);
            this.ClearButton.Size = new System.Drawing.Size(99, 27);
            this.ClearButton.TabIndex = 11;
            this.ClearButton.Text = "초기화";
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Location = new System.Drawing.Point(301, 122);
            this.AddButton.Name = "AddButton";
            this.AddButton.Padding = new System.Windows.Forms.Padding(5);
            this.AddButton.Size = new System.Drawing.Size(99, 27);
            this.AddButton.TabIndex = 12;
            this.AddButton.Text = "추가";
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveButton.Location = new System.Drawing.Point(157, 122);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Padding = new System.Windows.Forms.Padding(5);
            this.RemoveButton.Size = new System.Drawing.Size(99, 27);
            this.RemoveButton.TabIndex = 12;
            this.RemoveButton.Text = "제거";
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // TipBox
            // 
            this.TipBox.AutoPopDelay = 100000;
            this.TipBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.TipBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.TipBox.InitialDelay = 300;
            this.TipBox.IsBalloon = true;
            this.TipBox.ReshowDelay = 100;
            this.TipBox.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // TipLabel
            // 
            this.TipLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TipLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.TipLabel.Location = new System.Drawing.Point(406, 42);
            this.TipLabel.Name = "TipLabel";
            this.TipLabel.Size = new System.Drawing.Size(399, 110);
            this.TipLabel.TabIndex = 13;
            // 
            // CustomKeyDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 483);
            this.Controls.Add(this.TipLabel);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.ScriptTextBox);
            this.Controls.Add(this.KeyboardTypeComboBox);
            this.Name = "CustomKeyDialog";
            this.Resizing = false;
            this.Text = "CustomKey";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CustomKey_FormClosing);
            this.Load += new System.EventHandler(this.CustomKey_Load);
            this.Controls.SetChildIndex(this.titleBar, 0);
            this.Controls.SetChildIndex(this.KeyboardTypeComboBox, 0);
            this.Controls.SetChildIndex(this.ScriptTextBox, 0);
            this.Controls.SetChildIndex(this.ClearButton, 0);
            this.Controls.SetChildIndex(this.AddButton, 0);
            this.Controls.SetChildIndex(this.RemoveButton, 0);
            this.Controls.SetChildIndex(this.TipLabel, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Design.Bright.BrightComboBox KeyboardTypeComboBox;
        private Design.Bright.BrightTextBox ScriptTextBox;
        private Design.Bright.BrightButton ClearButton;
        private Design.Bright.BrightButton AddButton;
        private Design.Bright.BrightButton RemoveButton;
        private System.Windows.Forms.ToolTip TipBox;
        private System.Windows.Forms.Label TipLabel;
    }
}