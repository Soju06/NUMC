namespace NUMC.Forms.Dialogs
{
    partial class KeyDialog
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
            this.MainComboBox = new NUMC.Design.Bright.BrightComboBox();
            this.hookingControl = new NUMC.Forms.Controls.HookingControl();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.CloseBox = true;
            this.titleBar.MaximumSize = new System.Drawing.Size(0, 35);
            this.titleBar.Size = new System.Drawing.Size(313, 35);
            // 
            // MainComboBox
            // 
            this.MainComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.MainComboBox.FormattingEnabled = true;
            this.MainComboBox.Location = new System.Drawing.Point(12, 102);
            this.MainComboBox.Name = "MainComboBox";
            this.MainComboBox.Size = new System.Drawing.Size(289, 26);
            this.MainComboBox.TabIndex = 3;
            this.MainComboBox.SelectedIndexChanged += new System.EventHandler(this.MainComboBox_SelectedIndexChanged);
            // 
            // hookingControl
            // 
            this.hookingControl.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.hookingControl.Location = new System.Drawing.Point(12, 46);
            this.hookingControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hookingControl.Name = "hookingControl";
            this.hookingControl.Size = new System.Drawing.Size(289, 49);
            this.hookingControl.TabIndex = 4;
            // 
            // KeyDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 183);
            this.Controls.Add(this.hookingControl);
            this.Controls.Add(this.MainComboBox);
            this.DialogButtons = NUMC.Design.Bright.MessageBoxButtons.OkCancel;
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "KeyDialog";
            this.Resizing = false;
            this.Text = "KeyAddDialog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KeyDialog_FormClosing);
            this.Load += new System.EventHandler(this.KeyAddDialog_Load);
            this.Controls.SetChildIndex(this.titleBar, 0);
            this.Controls.SetChildIndex(this.MainComboBox, 0);
            this.Controls.SetChildIndex(this.hookingControl, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Design.Bright.BrightComboBox MainComboBox;
        private Controls.HookingControl hookingControl;
    }
}