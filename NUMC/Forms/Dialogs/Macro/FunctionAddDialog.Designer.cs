namespace NUMC.Forms.Dialogs.Macro
{
    partial class FunctionAddDialog
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
            this.textBox = new Design.Controls.TextBox();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.CloseBox = true;
            this.titleBar.MaximumSize = new System.Drawing.Size(0, 35);
            this.titleBar.MinimumSize = new System.Drawing.Size(888, 32);
            this.titleBar.Size = new System.Drawing.Size(888, 35);
            // 
            // textBox
            // 
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox.Location = new System.Drawing.Point(12, 45);
            this.textBox.MaxLength = 30;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(229, 25);
            this.textBox.TabIndex = 3;
            this.textBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // FunctionAddDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 141);
            this.Controls.Add(this.textBox);
            this.DialogButtons = NUMC.Design.Controls.MessageBoxButtons.OkCancel;
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "FunctionAddDialog";
            this.Text = "KeyAddDialog";
            this.Controls.SetChildIndex(this.titleBar, 0);
            this.Controls.SetChildIndex(this.textBox, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Design.Controls.TextBox textBox;
    }
}