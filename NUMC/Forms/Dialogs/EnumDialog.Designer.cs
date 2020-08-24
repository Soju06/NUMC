namespace NUMC.Forms.Dialogs
{
    partial class EnumDialog
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
            this.MainComboBox = new DarkUI.Controls.DarkComboBox();
            this.InfoButton = new DarkUI.Controls.DarkButton();
            this.SuspendLayout();
            // 
            // MainComboBox
            // 
            this.MainComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.MainComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.MainComboBox.FormattingEnabled = true;
            this.MainComboBox.Location = new System.Drawing.Point(12, 37);
            this.MainComboBox.Name = "MainComboBox";
            this.MainComboBox.Size = new System.Drawing.Size(289, 26);
            this.MainComboBox.TabIndex = 3;
            this.MainComboBox.SelectedIndexChanged += new System.EventHandler(this.MainComboBox_SelectedIndexChanged);
            // 
            // InfoButton
            // 
            this.InfoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.InfoButton.Location = new System.Drawing.Point(12, 85);
            this.InfoButton.Name = "InfoButton";
            this.InfoButton.Padding = new System.Windows.Forms.Padding(5);
            this.InfoButton.Size = new System.Drawing.Size(81, 23);
            this.InfoButton.TabIndex = 4;
            this.InfoButton.Text = "Info";
            this.InfoButton.Click += new System.EventHandler(this.InfoButton_Click);
            // 
            // EnumDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 118);
            this.Controls.Add(this.InfoButton);
            this.Controls.Add(this.MainComboBox);
            this.DialogButtons = DarkUI.Forms.DarkDialogButton.OkCancel;
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnumDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KeyAddDialog";
            this.Load += new System.EventHandler(this.KeyAddDialog_Load);
            this.Controls.SetChildIndex(this.MainComboBox, 0);
            this.Controls.SetChildIndex(this.InfoButton, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkComboBox MainComboBox;
        private DarkUI.Controls.DarkButton InfoButton;
    }
}