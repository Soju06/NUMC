namespace NUMC.Updater
{
    partial class UpdateDialog
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
            this.NoteBox = new System.Windows.Forms.RichTextBox();
            this.SubtitleLabel = new DarkUI.Controls.DarkLabel();
            this.TitleLabel = new DarkUI.Controls.DarkLabel();
            this.Label1 = new DarkUI.Controls.DarkLabel();
            this.SuspendLayout();
            // 
            // NoteBox
            // 
            this.NoteBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NoteBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(53)))), ((int)(((byte)(55)))));
            this.NoteBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NoteBox.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoteBox.ForeColor = System.Drawing.Color.White;
            this.NoteBox.Location = new System.Drawing.Point(12, 107);
            this.NoteBox.Name = "NoteBox";
            this.NoteBox.ReadOnly = true;
            this.NoteBox.Size = new System.Drawing.Size(776, 397);
            this.NoteBox.TabIndex = 5;
            this.NoteBox.Text = "Null";
            // 
            // SubtitleLabel
            // 
            this.SubtitleLabel.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.SubtitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.SubtitleLabel.Location = new System.Drawing.Point(12, 82);
            this.SubtitleLabel.Name = "SubtitleLabel";
            this.SubtitleLabel.Size = new System.Drawing.Size(776, 22);
            this.SubtitleLabel.TabIndex = 6;
            this.SubtitleLabel.Text = "Null";
            this.SubtitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TitleLabel
            // 
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.TitleLabel.Location = new System.Drawing.Point(12, 36);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(776, 46);
            this.TitleLabel.TabIndex = 7;
            this.TitleLabel.Text = "Null";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Label1.Location = new System.Drawing.Point(12, 519);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(574, 24);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "Do you want to continue?";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UpdateDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 552);
            this.ControlBox = false;
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.SubtitleLabel);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.NoteBox);
            this.DialogButtons = DarkUI.Forms.DarkDialogButton.OkCancel;
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Note";
            this.Controls.SetChildIndex(this.NoteBox, 0);
            this.Controls.SetChildIndex(this.TitleLabel, 0);
            this.Controls.SetChildIndex(this.SubtitleLabel, 0);
            this.Controls.SetChildIndex(this.Label1, 0);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox NoteBox;
        private DarkUI.Controls.DarkLabel SubtitleLabel;
        private DarkUI.Controls.DarkLabel TitleLabel;
        private DarkUI.Controls.DarkLabel Label1;
    }
}