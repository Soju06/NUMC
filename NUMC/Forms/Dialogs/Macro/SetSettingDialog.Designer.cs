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
            // titleBar
            // 
            this.titleBar.CloseBox = true;
            this.titleBar.MaximumSize = new System.Drawing.Size(0, 35);
            this.titleBar.Size = new System.Drawing.Size(508, 35);
            // 
            // DropButton
            // 
            this.DropButton.AllowDrop = true;
            this.DropButton.FlatAppearance.BorderSize = 0;
            this.DropButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DropButton.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.DropButton.Location = new System.Drawing.Point(13, 45);
            this.DropButton.Name = "DropButton";
            this.DropButton.Size = new System.Drawing.Size(484, 112);
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
            this.ClientSize = new System.Drawing.Size(508, 212);
            this.Controls.Add(this.DropButton);
            this.DialogButtons = NUMC.Design.Bright.MessageBoxButtons.OkCancel;
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SetSettingDialog";
            this.Resizing = false;
            this.Text = "IFDialog";
            this.Controls.SetChildIndex(this.titleBar, 0);
            this.Controls.SetChildIndex(this.DropButton, 0);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button DropButton;
    }
}