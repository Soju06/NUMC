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
            this.components = new System.ComponentModel.Container();
            this.titleBar = new Design.TitleBar();
            this.MainComboBox = new DarkUI.Controls.DarkComboBox();
            this.TypeRadio_1 = new DarkUI.Controls.DarkRadioButton();
            this.TypeRadio_2 = new DarkUI.Controls.DarkRadioButton();
            this.TypeRadio_0 = new DarkUI.Controls.DarkRadioButton();
            this.TipBox = new System.Windows.Forms.ToolTip(this.components);
            this.TipLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.titleBar.CloseBox = true;
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.titleBar.ForeColor = System.Drawing.Color.White;
            this.titleBar.Form = null;
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.titleBar.MaximizeBox = false;
            this.titleBar.MinimizeBox = false;
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(330, 28);
            this.titleBar.TabIndex = 2;
            this.titleBar.Title = "";
            // 
            // MainComboBox
            // 
            this.MainComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.MainComboBox.FormattingEnabled = true;
            this.MainComboBox.Location = new System.Drawing.Point(12, 79);
            this.MainComboBox.Name = "MainComboBox";
            this.MainComboBox.Size = new System.Drawing.Size(306, 26);
            this.MainComboBox.TabIndex = 3;
            this.MainComboBox.SelectedIndexChanged += new System.EventHandler(this.MainComboBox_SelectedIndexChanged);
            // 
            // TypeRadio_1
            // 
            this.TypeRadio_1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TypeRadio_1.Location = new System.Drawing.Point(120, 146);
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
            this.TypeRadio_2.Location = new System.Drawing.Point(120, 173);
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
            this.TypeRadio_0.Location = new System.Drawing.Point(120, 119);
            this.TypeRadio_0.Name = "TypeRadio_0";
            this.TypeRadio_0.Size = new System.Drawing.Size(91, 21);
            this.TypeRadio_0.TabIndex = 6;
            this.TypeRadio_0.TabStop = true;
            this.TypeRadio_0.Text = "클릭";
            this.TypeRadio_0.Click += new System.EventHandler(this.TypeRadio_Changed);
            // 
            // TipBox
            // 
            this.TipBox.AutoPopDelay = 100000;
            this.TipBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.TipBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.TipBox.InitialDelay = 300;
            this.TipBox.IsBalloon = true;
            this.TipBox.ReshowDelay = 100;
            this.TipBox.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // TipLabel
            // 
            this.TipLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TipLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.TipLabel.Location = new System.Drawing.Point(12, 34);
            this.TipLabel.Name = "TipLabel";
            this.TipLabel.Size = new System.Drawing.Size(306, 40);
            this.TipLabel.TabIndex = 4;
            this.TipLabel.Text = "사용할 키를 선택하거나\r\n여기에 마우스를 올리고, 키를 눌러주세요";
            this.TipLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TipLabel.MouseEnter += new System.EventHandler(this.TipLabel_Enter);
            this.TipLabel.MouseLeave += new System.EventHandler(this.TipLabel_Leave);
            this.TipLabel.MouseHover += new System.EventHandler(this.TipLabel_MouseHover);
            // 
            // KeyAddDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 252);
            this.Controls.Add(this.TypeRadio_2);
            this.Controls.Add(this.TypeRadio_0);
            this.Controls.Add(this.TypeRadio_1);
            this.Controls.Add(this.TipLabel);
            this.Controls.Add(this.MainComboBox);
            this.Controls.Add(this.titleBar);
            this.DialogButtons = DarkUI.Forms.DarkDialogButton.OkCancel;
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KeyAddDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KeyAddDialog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KeyAddDialog_FormClosing);
            this.Load += new System.EventHandler(this.KeyAddDialog_Load);
            this.Controls.SetChildIndex(this.titleBar, 0);
            this.Controls.SetChildIndex(this.MainComboBox, 0);
            this.Controls.SetChildIndex(this.TipLabel, 0);
            this.Controls.SetChildIndex(this.TypeRadio_1, 0);
            this.Controls.SetChildIndex(this.TypeRadio_0, 0);
            this.Controls.SetChildIndex(this.TypeRadio_2, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Design.TitleBar titleBar;
        private DarkUI.Controls.DarkComboBox MainComboBox;
        private DarkUI.Controls.DarkRadioButton TypeRadio_1;
        private DarkUI.Controls.DarkRadioButton TypeRadio_2;
        private DarkUI.Controls.DarkRadioButton TypeRadio_0;
        private System.Windows.Forms.ToolTip TipBox;
        private System.Windows.Forms.Label TipLabel;
    }
}