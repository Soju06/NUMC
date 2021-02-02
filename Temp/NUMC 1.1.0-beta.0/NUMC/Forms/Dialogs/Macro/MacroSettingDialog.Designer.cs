namespace NUMC.Forms.Dialogs.Macro
{
    partial class MacroSettingDialog
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
            this.EventsView = new NUMC.Design.Bright.BrightListView();
            this.AddDelayButton = new NUMC.Design.Bright.BrightButton();
            this.RemoveButton = new NUMC.Design.Bright.BrightButton();
            this.AddKeystrokeButton = new NUMC.Design.Bright.BrightButton();
            this.TipBox = new System.Windows.Forms.ToolTip(this.components);
            this.MovedownButton = new NUMC.Design.Bright.BrightButton();
            this.MoveupButton = new NUMC.Design.Bright.BrightButton();
            this.AddFunctionButton = new NUMC.Design.Bright.BrightButton();
            this.GotoFunctionButton = new NUMC.Design.Bright.BrightButton();
            this.AddKeyUpAllButton = new NUMC.Design.Bright.BrightButton();
            this.AddExitButton = new NUMC.Design.Bright.BrightButton();
            this.AddTextInputButton = new NUMC.Design.Bright.BrightButton();
            this.RemoveAllButton = new NUMC.Design.Bright.BrightButton();
            this.ModuleButton = new NUMC.Design.Bright.BrightButton();
            this.ModuleContextMenu = new NUMC.Design.Bright.BrightContextMenu();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.CloseBox = true;
            this.titleBar.MaximumSize = new System.Drawing.Size(0, 35);
            this.titleBar.MinimumSize = new System.Drawing.Size(888, 32);
            this.titleBar.Size = new System.Drawing.Size(888, 35);
            // 
            // EventsView
            // 
            this.EventsView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EventsView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.EventsView.Location = new System.Drawing.Point(12, 45);
            this.EventsView.Name = "EventsView";
            this.EventsView.Size = new System.Drawing.Size(395, 487);
            this.EventsView.TabIndex = 10;
            this.EventsView.Text = "darkListView1";
            this.EventsView.MouseEnter += new System.EventHandler(this.EventsView_MouseEnter);
            this.EventsView.MouseLeave += new System.EventHandler(this.EventsView_MouseLeave);
            this.EventsView.MouseHover += new System.EventHandler(this.EventsView_MouseHover);
            // 
            // AddDelayButton
            // 
            this.AddDelayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddDelayButton.Location = new System.Drawing.Point(413, 111);
            this.AddDelayButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.AddDelayButton.Name = "AddDelayButton";
            this.AddDelayButton.Padding = new System.Windows.Forms.Padding(5);
            this.AddDelayButton.Size = new System.Drawing.Size(127, 24);
            this.AddDelayButton.TabIndex = 11;
            this.AddDelayButton.Text = "지연 추가";
            this.AddDelayButton.Click += new System.EventHandler(this.AddDelayButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveButton.Location = new System.Drawing.Point(413, 474);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Padding = new System.Windows.Forms.Padding(5);
            this.RemoveButton.Size = new System.Drawing.Size(127, 24);
            this.RemoveButton.TabIndex = 12;
            this.RemoveButton.Text = "이벤트 제거";
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // AddKeystrokeButton
            // 
            this.AddKeystrokeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddKeystrokeButton.Location = new System.Drawing.Point(413, 51);
            this.AddKeystrokeButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.AddKeystrokeButton.Name = "AddKeystrokeButton";
            this.AddKeystrokeButton.Padding = new System.Windows.Forms.Padding(5);
            this.AddKeystrokeButton.Size = new System.Drawing.Size(127, 24);
            this.AddKeystrokeButton.TabIndex = 11;
            this.AddKeystrokeButton.Text = "키 입력 추가";
            this.AddKeystrokeButton.Click += new System.EventHandler(this.AddKeystrokeButton_Click);
            // 
            // TipBox
            // 
            this.TipBox.AutoPopDelay = 100000;
            this.TipBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.TipBox.InitialDelay = 300;
            this.TipBox.IsBalloon = true;
            this.TipBox.ReshowDelay = 100;
            this.TipBox.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // MovedownButton
            // 
            this.MovedownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MovedownButton.Location = new System.Drawing.Point(413, 333);
            this.MovedownButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.MovedownButton.Name = "MovedownButton";
            this.MovedownButton.Padding = new System.Windows.Forms.Padding(5);
            this.MovedownButton.Size = new System.Drawing.Size(127, 24);
            this.MovedownButton.TabIndex = 12;
            this.MovedownButton.Text = "아래로 이동";
            this.MovedownButton.Click += new System.EventHandler(this.MovedownButton_Click);
            // 
            // MoveupButton
            // 
            this.MoveupButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MoveupButton.Location = new System.Drawing.Point(413, 303);
            this.MoveupButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.MoveupButton.Name = "MoveupButton";
            this.MoveupButton.Padding = new System.Windows.Forms.Padding(5);
            this.MoveupButton.Size = new System.Drawing.Size(127, 24);
            this.MoveupButton.TabIndex = 12;
            this.MoveupButton.Text = "위로 이동";
            this.MoveupButton.Click += new System.EventHandler(this.MoveupButton_Click);
            // 
            // AddFunctionButton
            // 
            this.AddFunctionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddFunctionButton.Location = new System.Drawing.Point(413, 155);
            this.AddFunctionButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.AddFunctionButton.Name = "AddFunctionButton";
            this.AddFunctionButton.Padding = new System.Windows.Forms.Padding(5);
            this.AddFunctionButton.Size = new System.Drawing.Size(127, 24);
            this.AddFunctionButton.TabIndex = 11;
            this.AddFunctionButton.Text = "함수 추가";
            this.AddFunctionButton.Click += new System.EventHandler(this.AddFunctionButton_Click);
            // 
            // GotoFunctionButton
            // 
            this.GotoFunctionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GotoFunctionButton.Location = new System.Drawing.Point(413, 185);
            this.GotoFunctionButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.GotoFunctionButton.Name = "GotoFunctionButton";
            this.GotoFunctionButton.Padding = new System.Windows.Forms.Padding(5);
            this.GotoFunctionButton.Size = new System.Drawing.Size(127, 24);
            this.GotoFunctionButton.TabIndex = 11;
            this.GotoFunctionButton.Text = "함수로 이동";
            this.GotoFunctionButton.Click += new System.EventHandler(this.GotoFunctionButton_Click);
            // 
            // AddKeyUpAllButton
            // 
            this.AddKeyUpAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddKeyUpAllButton.Location = new System.Drawing.Point(413, 229);
            this.AddKeyUpAllButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.AddKeyUpAllButton.Name = "AddKeyUpAllButton";
            this.AddKeyUpAllButton.Padding = new System.Windows.Forms.Padding(5);
            this.AddKeyUpAllButton.Size = new System.Drawing.Size(127, 24);
            this.AddKeyUpAllButton.TabIndex = 11;
            this.AddKeyUpAllButton.Text = "모든 키 떼기";
            this.AddKeyUpAllButton.Click += new System.EventHandler(this.AddKeyUpAllButton_Click);
            // 
            // AddExitButton
            // 
            this.AddExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddExitButton.Location = new System.Drawing.Point(413, 259);
            this.AddExitButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.AddExitButton.Name = "AddExitButton";
            this.AddExitButton.Padding = new System.Windows.Forms.Padding(5);
            this.AddExitButton.Size = new System.Drawing.Size(127, 24);
            this.AddExitButton.TabIndex = 11;
            this.AddExitButton.Text = "끝내기";
            this.AddExitButton.Click += new System.EventHandler(this.AddExitButton_Click);
            // 
            // AddTextInputButton
            // 
            this.AddTextInputButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddTextInputButton.Location = new System.Drawing.Point(413, 81);
            this.AddTextInputButton.Name = "AddTextInputButton";
            this.AddTextInputButton.Padding = new System.Windows.Forms.Padding(5);
            this.AddTextInputButton.Size = new System.Drawing.Size(127, 24);
            this.AddTextInputButton.TabIndex = 12;
            this.AddTextInputButton.Text = "텍스트 입력 추가";
            this.AddTextInputButton.Click += new System.EventHandler(this.AddTextInputButton_Click);
            // 
            // RemoveAllButton
            // 
            this.RemoveAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveAllButton.Location = new System.Drawing.Point(413, 504);
            this.RemoveAllButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.RemoveAllButton.Name = "RemoveAllButton";
            this.RemoveAllButton.Padding = new System.Windows.Forms.Padding(5);
            this.RemoveAllButton.Size = new System.Drawing.Size(127, 24);
            this.RemoveAllButton.TabIndex = 12;
            this.RemoveAllButton.Text = "이벤트 모두 제거";
            this.RemoveAllButton.Click += new System.EventHandler(this.RemoveAllButton_Click);
            // 
            // ModuleButton
            // 
            this.ModuleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ModuleButton.Location = new System.Drawing.Point(413, 377);
            this.ModuleButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.ModuleButton.Name = "ModuleButton";
            this.ModuleButton.Padding = new System.Windows.Forms.Padding(5);
            this.ModuleButton.Size = new System.Drawing.Size(127, 24);
            this.ModuleButton.TabIndex = 12;
            this.ModuleButton.Text = "모듈...";
            this.ModuleButton.Click += new System.EventHandler(this.ModuleButton_Click);
            // 
            // ModuleContextMenu
            // 
            this.ModuleContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ModuleContextMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ModuleContextMenu.Name = "ModuleContextMenu";
            this.ModuleContextMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // MacroSettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 587);
            this.Controls.Add(this.AddTextInputButton);
            this.Controls.Add(this.MoveupButton);
            this.Controls.Add(this.ModuleButton);
            this.Controls.Add(this.MovedownButton);
            this.Controls.Add(this.RemoveAllButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.AddKeystrokeButton);
            this.Controls.Add(this.AddExitButton);
            this.Controls.Add(this.AddKeyUpAllButton);
            this.Controls.Add(this.GotoFunctionButton);
            this.Controls.Add(this.AddFunctionButton);
            this.Controls.Add(this.AddDelayButton);
            this.Controls.Add(this.EventsView);
            this.Name = "MacroSettingDialog";
            this.Text = "";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MacroSettingDialog_FormClosing);
            this.Controls.SetChildIndex(this.titleBar, 0);
            this.Controls.SetChildIndex(this.EventsView, 0);
            this.Controls.SetChildIndex(this.AddDelayButton, 0);
            this.Controls.SetChildIndex(this.AddFunctionButton, 0);
            this.Controls.SetChildIndex(this.GotoFunctionButton, 0);
            this.Controls.SetChildIndex(this.AddKeyUpAllButton, 0);
            this.Controls.SetChildIndex(this.AddExitButton, 0);
            this.Controls.SetChildIndex(this.AddKeystrokeButton, 0);
            this.Controls.SetChildIndex(this.RemoveButton, 0);
            this.Controls.SetChildIndex(this.RemoveAllButton, 0);
            this.Controls.SetChildIndex(this.MovedownButton, 0);
            this.Controls.SetChildIndex(this.ModuleButton, 0);
            this.Controls.SetChildIndex(this.MoveupButton, 0);
            this.Controls.SetChildIndex(this.AddTextInputButton, 0);
            this.ResumeLayout(false);

        }

        #endregion
        private Design.Bright.BrightListView EventsView;
        private Design.Bright.BrightButton RemoveButton;
        private Design.Bright.BrightButton AddKeystrokeButton;
        private System.Windows.Forms.ToolTip TipBox;
        private Design.Bright.BrightButton MovedownButton;
        private Design.Bright.BrightButton MoveupButton;
        private Design.Bright.BrightButton AddFunctionButton;
        private Design.Bright.BrightButton GotoFunctionButton;
        private Design.Bright.BrightButton AddKeyUpAllButton;
        private Design.Bright.BrightButton AddExitButton;
        private Design.Bright.BrightButton AddTextInputButton;
        private Design.Bright.BrightButton RemoveAllButton;
        private Design.Bright.BrightButton AddDelayButton;
        private Design.Bright.BrightButton ModuleButton;
        private Design.Bright.BrightContextMenu ModuleContextMenu;
    }
}