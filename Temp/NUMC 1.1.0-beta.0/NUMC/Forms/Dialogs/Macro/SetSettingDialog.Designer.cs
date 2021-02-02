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
            this.fileDropControl = new NUMC.Forms.Controls.FileDropControl();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.CloseBox = true;
            this.titleBar.MaximumSize = new System.Drawing.Size(0, 35);
            this.titleBar.MinimumSize = new System.Drawing.Size(888, 32);
            this.titleBar.Size = new System.Drawing.Size(888, 35);
            // 
            // fileDropControl
            // 
            this.fileDropControl.AllowExtensions = null;
            this.fileDropControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileDropControl.File = null;
            this.fileDropControl.Filter = null;
            this.fileDropControl.Location = new System.Drawing.Point(12, 46);
            this.fileDropControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fileDropControl.Name = "fileDropControl";
            this.fileDropControl.Size = new System.Drawing.Size(412, 113);
            this.fileDropControl.TabIndex = 2;
            // 
            // SetSettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 215);
            this.Controls.Add(this.fileDropControl);
            this.DialogButtons = NUMC.Design.Bright.MessageBoxButtons.OkCancel;
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SetSettingDialog";
            this.Resizing = false;
            this.Text = "IFDialog";
            this.Controls.SetChildIndex(this.titleBar, 0);
            this.Controls.SetChildIndex(this.fileDropControl, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.FileDropControl fileDropControl;
    }
}