namespace NUMC.Forms.Dialogs.Macro
{
    partial class RunFileDialog
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
            this.ArgsTextBox = new NUMC.Design.Bright.BrightTextBox();
            this.darkLabel1 = new System.Windows.Forms.Label();
            this.fileDropControl = new NUMC.Forms.Controls.FileDropControl();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.CloseBox = true;
            this.titleBar.MaximumSize = new System.Drawing.Size(0, 35);
            this.titleBar.Size = new System.Drawing.Size(572, 30);
            // 
            // ArgsTextBox
            // 
            this.ArgsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ArgsTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ArgsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ArgsTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArgsTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ArgsTextBox.Location = new System.Drawing.Point(12, 154);
            this.ArgsTextBox.Name = "ArgsTextBox";
            this.ArgsTextBox.Size = new System.Drawing.Size(548, 29);
            this.ArgsTextBox.TabIndex = 12;
            this.ArgsTextBox.TextChanged += new System.EventHandler(this.ArgsTextBox_TextChanged);
            // 
            // darkLabel1
            // 
            this.darkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.Location = new System.Drawing.Point(12, 134);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(40, 19);
            this.darkLabel1.TabIndex = 13;
            this.darkLabel1.Text = "Args:";
            // 
            // fileDropControl
            // 
            this.fileDropControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileDropControl.File = null;
            this.fileDropControl.Filter = null;
            this.fileDropControl.Location = new System.Drawing.Point(16, 41);
            this.fileDropControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fileDropControl.Name = "fileDropControl";
            this.fileDropControl.Size = new System.Drawing.Size(544, 89);
            this.fileDropControl.TabIndex = 14;
            // 
            // RunFileDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 238);
            this.Controls.Add(this.fileDropControl);
            this.Controls.Add(this.darkLabel1);
            this.Controls.Add(this.ArgsTextBox);
            this.DialogButtons = NUMC.Design.Bright.MessageBoxButtons.Ok;
            this.Name = "RunFileDialog";
            this.Text = "RunFileDialog";
            this.Controls.SetChildIndex(this.titleBar, 0);
            this.Controls.SetChildIndex(this.ArgsTextBox, 0);
            this.Controls.SetChildIndex(this.darkLabel1, 0);
            this.Controls.SetChildIndex(this.fileDropControl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Design.Bright.BrightTextBox ArgsTextBox;
        private System.Windows.Forms.Label darkLabel1;
        private Controls.FileDropControl fileDropControl;
    }
}