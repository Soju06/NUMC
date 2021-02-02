namespace NUMC.Forms.Dialogs.Macro
{
    partial class KeyAddDialog
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
            this.TypeRadio_1 = new NUMC.Design.Bright.BrightRadioButton();
            this.TypeRadio_2 = new NUMC.Design.Bright.BrightRadioButton();
            this.TypeRadio_0 = new NUMC.Design.Bright.BrightRadioButton();
            this.hookingControl = new NUMC.Forms.Controls.HookingControl();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.CloseBox = true;
            this.titleBar.MaximumSize = new System.Drawing.Size(0, 35);
            this.titleBar.MinimumSize = new System.Drawing.Size(888, 32);
            this.titleBar.Size = new System.Drawing.Size(888, 35);
            // 
            // MainComboBox
            // 
            this.MainComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.MainComboBox.FormattingEnabled = true;
            this.MainComboBox.Location = new System.Drawing.Point(12, 99);
            this.MainComboBox.Name = "MainComboBox";
            this.MainComboBox.Size = new System.Drawing.Size(306, 26);
            this.MainComboBox.TabIndex = 3;
            this.MainComboBox.SelectedIndexChanged += new System.EventHandler(this.MainComboBox_SelectedIndexChanged);
            // 
            // TypeRadio_1
            // 
            this.TypeRadio_1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TypeRadio_1.Location = new System.Drawing.Point(120, 158);
            this.TypeRadio_1.Name = "TypeRadio_1";
            this.TypeRadio_1.Size = new System.Drawing.Size(91, 21);
            this.TypeRadio_1.TabIndex = 6;
            this.TypeRadio_1.TabStop = true;
            this.TypeRadio_1.Text = "누르기";
            this.TypeRadio_1.Click += new System.EventHandler(this.TypeRadio_Changed);
            // 
            // TypeRadio_2
            // 
            this.TypeRadio_2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TypeRadio_2.Location = new System.Drawing.Point(120, 185);
            this.TypeRadio_2.Name = "TypeRadio_2";
            this.TypeRadio_2.Size = new System.Drawing.Size(91, 21);
            this.TypeRadio_2.TabIndex = 6;
            this.TypeRadio_2.TabStop = true;
            this.TypeRadio_2.Text = "떼기";
            this.TypeRadio_2.Click += new System.EventHandler(this.TypeRadio_Changed);
            // 
            // TypeRadio_0
            // 
            this.TypeRadio_0.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TypeRadio_0.Checked = true;
            this.TypeRadio_0.Location = new System.Drawing.Point(120, 131);
            this.TypeRadio_0.Name = "TypeRadio_0";
            this.TypeRadio_0.Size = new System.Drawing.Size(91, 21);
            this.TypeRadio_0.TabIndex = 6;
            this.TypeRadio_0.TabStop = true;
            this.TypeRadio_0.Text = "클릭";
            this.TypeRadio_0.Click += new System.EventHandler(this.TypeRadio_Changed);
            // 
            // hookingControl
            // 
            this.hookingControl.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.hookingControl.Location = new System.Drawing.Point(12, 46);
            this.hookingControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hookingControl.Name = "hookingControl";
            this.hookingControl.Size = new System.Drawing.Size(306, 46);
            this.hookingControl.TabIndex = 7;
            // 
            // KeyAddDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 260);
            this.Controls.Add(this.hookingControl);
            this.Controls.Add(this.TypeRadio_2);
            this.Controls.Add(this.TypeRadio_0);
            this.Controls.Add(this.TypeRadio_1);
            this.Controls.Add(this.MainComboBox);
            this.DialogButtons = NUMC.Design.Bright.MessageBoxButtons.OkCancel;
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "KeyAddDialog";
            this.Text = "KeyAddDialog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KeyAddDialog_FormClosing);
            this.Load += new System.EventHandler(this.KeyAddDialog_Load);
            this.Controls.SetChildIndex(this.titleBar, 0);
            this.Controls.SetChildIndex(this.MainComboBox, 0);
            this.Controls.SetChildIndex(this.TypeRadio_1, 0);
            this.Controls.SetChildIndex(this.TypeRadio_0, 0);
            this.Controls.SetChildIndex(this.TypeRadio_2, 0);
            this.Controls.SetChildIndex(this.hookingControl, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Design.Bright.BrightComboBox MainComboBox;
        private Design.Bright.BrightRadioButton TypeRadio_1;
        private Design.Bright.BrightRadioButton TypeRadio_2;
        private Design.Bright.BrightRadioButton TypeRadio_0;
        private Controls.HookingControl hookingControl;
    }
}