namespace NUMC.Forms.Dialogs.Macro
{
    partial class DelayAddDialog
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
            this.DelayTextBox = new DarkUI.Controls.DarkTextBox();
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.SuspendLayout();
            // 
            // DelayTextBox
            // 
            this.DelayTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.DelayTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DelayTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DelayTextBox.Location = new System.Drawing.Point(12, 37);
            this.DelayTextBox.Name = "DelayTextBox";
            this.DelayTextBox.Size = new System.Drawing.Size(186, 25);
            this.DelayTextBox.TabIndex = 3;
            this.DelayTextBox.TextChanged += new System.EventHandler(this.DelayTextBox_TextChanged);
            this.DelayTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DelayTextBox_KeyPress);
            // 
            // darkLabel1
            // 
            this.darkLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(204, 37);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(33, 25);
            this.darkLabel1.TabIndex = 4;
            this.darkLabel1.Text = "ms";
            this.darkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DelayAddDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 113);
            this.Controls.Add(this.darkLabel1);
            this.Controls.Add(this.DelayTextBox);
            this.DialogButtons = DarkUI.Forms.DarkDialogButton.OkCancel;
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "DelayAddDialog";
            this.Text = "KeyAddDialog";
            this.Controls.SetChildIndex(this.DelayTextBox, 0);
            this.Controls.SetChildIndex(this.darkLabel1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DarkUI.Controls.DarkTextBox DelayTextBox;
        private DarkUI.Controls.DarkLabel darkLabel1;
    }
}