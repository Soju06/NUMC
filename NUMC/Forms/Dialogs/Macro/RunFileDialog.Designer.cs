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
            this.DropButton = new System.Windows.Forms.Button();
            this.ArgsTextBox = new NUMC.Design.Bright.BrightTextBox();
            this.darkLabel1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.CloseBox = true;
            this.titleBar.MaximumSize = new System.Drawing.Size(0, 35);
            this.titleBar.Size = new System.Drawing.Size(591, 30);
            // 
            // DropButton
            // 
            this.DropButton.AllowDrop = true;
            this.DropButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DropButton.FlatAppearance.BorderSize = 0;
            this.DropButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DropButton.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.DropButton.Location = new System.Drawing.Point(12, 40);
            this.DropButton.Name = "DropButton";
            this.DropButton.Size = new System.Drawing.Size(567, 49);
            this.DropButton.TabIndex = 11;
            this.DropButton.TabStop = false;
            this.DropButton.Text = "여기에 파일을 올려주세요";
            this.DropButton.UseVisualStyleBackColor = true;
            this.DropButton.Click += new System.EventHandler(this.DropButton_Click);
            this.DropButton.DragDrop += new System.Windows.Forms.DragEventHandler(this.DropButton_DragDrop);
            this.DropButton.DragEnter += new System.Windows.Forms.DragEventHandler(this.DropButton_DragEnter);
            // 
            // ArgsTextBox
            // 
            this.ArgsTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ArgsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ArgsTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArgsTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ArgsTextBox.Location = new System.Drawing.Point(12, 112);
            this.ArgsTextBox.Name = "ArgsTextBox";
            this.ArgsTextBox.Size = new System.Drawing.Size(567, 29);
            this.ArgsTextBox.TabIndex = 12;
            this.ArgsTextBox.TextChanged += new System.EventHandler(this.ArgsTextBox_TextChanged);
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.Location = new System.Drawing.Point(12, 92);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(40, 19);
            this.darkLabel1.TabIndex = 13;
            this.darkLabel1.Text = "Args:";
            // 
            // RunFileDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 204);
            this.Controls.Add(this.darkLabel1);
            this.Controls.Add(this.ArgsTextBox);
            this.Controls.Add(this.DropButton);
            this.Name = "RunFileDialog";
            this.Text = "RunFileDialog";
            this.Controls.SetChildIndex(this.titleBar, 0);
            this.Controls.SetChildIndex(this.DropButton, 0);
            this.Controls.SetChildIndex(this.ArgsTextBox, 0);
            this.Controls.SetChildIndex(this.darkLabel1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DropButton;
        private Design.Bright.BrightTextBox ArgsTextBox;
        private System.Windows.Forms.Label darkLabel1;
    }
}