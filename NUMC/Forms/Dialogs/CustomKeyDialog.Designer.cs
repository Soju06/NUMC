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
            this.KeyboardTypeComboBox = new DarkUI.Controls.DarkComboBox();
            this.ScriptTextBox = new DarkUI.Controls.DarkTextBox();
            this.ClearButton = new DarkUI.Controls.DarkButton();
            this.AddButton = new DarkUI.Controls.DarkButton();
            this.RemoveButton = new DarkUI.Controls.DarkButton();
            this.TipBox = new System.Windows.Forms.ToolTip(this.components);
            this.TipLabel = new DarkUI.Controls.DarkLabel();
            this.SuspendLayout();
            // 
            // KeyboardTypeComboBox
            // 
            this.KeyboardTypeComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.KeyboardTypeComboBox.FormattingEnabled = true;
            this.KeyboardTypeComboBox.Location = new System.Drawing.Point(12, 36);
            this.KeyboardTypeComboBox.Name = "KeyboardTypeComboBox";
            this.KeyboardTypeComboBox.Size = new System.Drawing.Size(185, 26);
            this.KeyboardTypeComboBox.TabIndex = 9;
            this.KeyboardTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.KeyboardTypeComboBox_SelectedIndexChanged);
            // 
            // ScriptTextBox
            // 
            this.ScriptTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.ScriptTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ScriptTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ScriptTextBox.Location = new System.Drawing.Point(12, 72);
            this.ScriptTextBox.MaxLength = 2000;
            this.ScriptTextBox.Multiline = true;
            this.ScriptTextBox.Name = "ScriptTextBox";
            this.ScriptTextBox.Size = new System.Drawing.Size(793, 237);
            this.ScriptTextBox.TabIndex = 10;
            this.ScriptTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyTextBox_KeyDown);
            this.ScriptTextBox.MouseEnter += new System.EventHandler(this.KeyTextBox_Enter);
            this.ScriptTextBox.MouseLeave += new System.EventHandler(this.KeyTextBox_Leave);
            this.ScriptTextBox.MouseHover += new System.EventHandler(this.KeyTextBox_MouseHover);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(496, 315);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Padding = new System.Windows.Forms.Padding(5);
            this.ClearButton.Size = new System.Drawing.Size(99, 23);
            this.ClearButton.TabIndex = 11;
            this.ClearButton.Text = "초기화";
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(706, 315);
            this.AddButton.Name = "AddButton";
            this.AddButton.Padding = new System.Windows.Forms.Padding(5);
            this.AddButton.Size = new System.Drawing.Size(99, 23);
            this.AddButton.TabIndex = 12;
            this.AddButton.Text = "추가";
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(601, 315);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Padding = new System.Windows.Forms.Padding(5);
            this.RemoveButton.Size = new System.Drawing.Size(99, 23);
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
            this.TipLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TipLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.TipLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.TipLabel.Location = new System.Drawing.Point(12, 315);
            this.TipLabel.Name = "TipLabel";
            this.TipLabel.Size = new System.Drawing.Size(478, 88);
            this.TipLabel.TabIndex = 13;
            // 
            // CustomKeyDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 410);
            this.ControlBox = false;
            this.Controls.Add(this.TipLabel);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.ScriptTextBox);
            this.Controls.Add(this.KeyboardTypeComboBox);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomKeyDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomKey";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CustomKey_FormClosing);
            this.Load += new System.EventHandler(this.CustomKey_Load);
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
        private DarkUI.Controls.DarkComboBox KeyboardTypeComboBox;
        private DarkUI.Controls.DarkTextBox ScriptTextBox;
        private DarkUI.Controls.DarkButton ClearButton;
        private DarkUI.Controls.DarkButton AddButton;
        private DarkUI.Controls.DarkButton RemoveButton;
        private System.Windows.Forms.ToolTip TipBox;
        private DarkUI.Controls.DarkLabel TipLabel;
    }
}