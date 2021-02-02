namespace NUMC.Forms.Dialogs
{
    partial class KeysDialog
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
            this.MainComboBox = new NUMC.Design.Controls.ComboBox();
            this.hookingControl = new NUMC.Forms.Controls.HookingControl();
            this.SuspendLayout();
            // 
            // MainComboBox
            // 
            this.MainComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.MainComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MainComboBox.FormattingEnabled = true;
            this.MainComboBox.Location = new System.Drawing.Point(7, 108);
            this.MainComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainComboBox.Name = "MainComboBox";
            this.MainComboBox.Size = new System.Drawing.Size(318, 26);
            this.MainComboBox.TabIndex = 3;
            this.MainComboBox.SelectedIndexChanged += new System.EventHandler(this.MainComboBox_SelectedIndexChanged);
            // 
            // hookingControl
            // 
            this.hookingControl.BackColor = System.Drawing.Color.Transparent;
            this.hookingControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.hookingControl.FontSize = 10F;
            this.hookingControl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.hookingControl.Location = new System.Drawing.Point(7, 43);
            this.hookingControl.Margin = new System.Windows.Forms.Padding(5);
            this.hookingControl.Name = "hookingControl";
            this.hookingControl.Size = new System.Drawing.Size(318, 58);
            this.hookingControl.TabIndex = 4;
            // 
            // KeysDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 189);
            this.Controls.Add(this.hookingControl);
            this.Controls.Add(this.MainComboBox);
            this.DialogButtons = NUMC.Design.Controls.MessageBoxButtons.OkCancel;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(220, 50);
            this.Name = "KeysDialog";
            this.Padding = new System.Windows.Forms.Padding(2, 38, 2, 3);
            this.Resizing = false;
            this.Text = "KeyAddDialog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KeyDialog_FormClosing);
            this.Load += new System.EventHandler(this.KeyAddDialog_Load);
            this.Controls.SetChildIndex(this.MainComboBox, 0);
            this.Controls.SetChildIndex(this.hookingControl, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Design.Controls.ComboBox MainComboBox;
        private Controls.HookingControl hookingControl;
    }
}