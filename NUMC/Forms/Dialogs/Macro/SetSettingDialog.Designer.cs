namespace NUMC.Forms.Dialogs.Macro
{
    partial class SetSettingDialog
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
            this.DropButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DropButton
            // 
            this.DropButton.AllowDrop = true;
            this.DropButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DropButton.FlatAppearance.BorderSize = 0;
            this.DropButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DropButton.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.DropButton.ForeColor = System.Drawing.Color.White;
            this.DropButton.Location = new System.Drawing.Point(12, 35);
            this.DropButton.Name = "DropButton";
            this.DropButton.Size = new System.Drawing.Size(484, 84);
            this.DropButton.TabIndex = 10;
            this.DropButton.TabStop = false;
            this.DropButton.Text = "여기에 파일을 올려주세요";
            this.DropButton.UseVisualStyleBackColor = true;
            this.DropButton.Click += new System.EventHandler(this.DropButton_Click);
            this.DropButton.DragDrop += new System.Windows.Forms.DragEventHandler(this.DropButton_DragDrop);
            this.DropButton.DragEnter += new System.Windows.Forms.DragEventHandler(this.DropButton_DragEnter);
            // 
            // SetSettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 168);
            this.ControlBox = false;
            this.Controls.Add(this.DropButton);
            this.DialogButtons = DarkUI.Forms.DarkDialogButton.OkCancel;
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetSettingDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IFDialog";
            this.Controls.SetChildIndex(this.DropButton, 0);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button DropButton;
    }
}