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
            this.titleBar = new Design.TitleBar();
            this.EventsView = new DarkUI.Controls.DarkListView();
            this.AddDelayButton = new DarkUI.Controls.DarkButton();
            this.RemoveButton = new DarkUI.Controls.DarkButton();
            this.AddKeystrokeButton = new DarkUI.Controls.DarkButton();
            this.TipBox = new System.Windows.Forms.ToolTip(this.components);
            this.MovedownButton = new DarkUI.Controls.DarkButton();
            this.MoveupButton = new DarkUI.Controls.DarkButton();
            this.AddFunctionButton = new DarkUI.Controls.DarkButton();
            this.GotoFunctionButton = new DarkUI.Controls.DarkButton();
            this.AddKeyUpAllButton = new DarkUI.Controls.DarkButton();
            this.AddExitButton = new DarkUI.Controls.DarkButton();
            this.AddTextInputButton = new DarkUI.Controls.DarkButton();
            this.RemoveAllButton = new DarkUI.Controls.DarkButton();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.titleBar.CloseBox = true;
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleBar.ForeColor = System.Drawing.Color.White;
            this.titleBar.Form = null;
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.titleBar.MaximizeBox = false;
            this.titleBar.MinimizeBox = false;
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(548, 28);
            this.titleBar.TabIndex = 9;
            this.titleBar.Title = "";
            // 
            // EventsView
            // 
            this.EventsView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EventsView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(53)))), ((int)(((byte)(55)))));
            this.EventsView.Location = new System.Drawing.Point(12, 36);
            this.EventsView.Name = "EventsView";
            this.EventsView.Size = new System.Drawing.Size(395, 503);
            this.EventsView.TabIndex = 10;
            this.EventsView.Text = "darkListView1";
            this.EventsView.MouseEnter += new System.EventHandler(this.EventsView_MouseEnter);
            this.EventsView.MouseLeave += new System.EventHandler(this.EventsView_MouseLeave);
            this.EventsView.MouseHover += new System.EventHandler(this.EventsView_MouseHover);
            // 
            // AddDelayButton
            // 
            this.AddDelayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddDelayButton.Location = new System.Drawing.Point(413, 98);
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
            this.RemoveButton.Location = new System.Drawing.Point(413, 352);
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
            this.AddKeystrokeButton.Location = new System.Drawing.Point(413, 36);
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
            this.TipBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.TipBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.TipBox.InitialDelay = 300;
            this.TipBox.IsBalloon = true;
            this.TipBox.ReshowDelay = 100;
            this.TipBox.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // MovedownButton
            // 
            this.MovedownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MovedownButton.Location = new System.Drawing.Point(413, 301);
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
            this.MoveupButton.Location = new System.Drawing.Point(413, 271);
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
            this.AddFunctionButton.Location = new System.Drawing.Point(413, 135);
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
            this.GotoFunctionButton.Location = new System.Drawing.Point(413, 165);
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
            this.AddKeyUpAllButton.Location = new System.Drawing.Point(413, 202);
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
            this.AddExitButton.Location = new System.Drawing.Point(413, 232);
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
            this.AddTextInputButton.Location = new System.Drawing.Point(413, 66);
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
            this.RemoveAllButton.Location = new System.Drawing.Point(413, 382);
            this.RemoveAllButton.Name = "RemoveAllButton";
            this.RemoveAllButton.Padding = new System.Windows.Forms.Padding(5);
            this.RemoveAllButton.Size = new System.Drawing.Size(127, 24);
            this.RemoveAllButton.TabIndex = 12;
            this.RemoveAllButton.Text = "이벤트 모두 제거";
            this.RemoveAllButton.Click += new System.EventHandler(this.RemoveAllButton_Click);
            // 
            // MacroSettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 587);
            this.ControlBox = false;
            this.Controls.Add(this.AddTextInputButton);
            this.Controls.Add(this.MoveupButton);
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
            this.Controls.Add(this.titleBar);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MacroSettingDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
            this.Controls.SetChildIndex(this.MoveupButton, 0);
            this.Controls.SetChildIndex(this.AddTextInputButton, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Design.TitleBar titleBar;
        private DarkUI.Controls.DarkListView EventsView;
        private DarkUI.Controls.DarkButton RemoveButton;
        private DarkUI.Controls.DarkButton AddKeystrokeButton;
        private System.Windows.Forms.ToolTip TipBox;
        private DarkUI.Controls.DarkButton MovedownButton;
        private DarkUI.Controls.DarkButton MoveupButton;
        private DarkUI.Controls.DarkButton AddFunctionButton;
        private DarkUI.Controls.DarkButton GotoFunctionButton;
        private DarkUI.Controls.DarkButton AddKeyUpAllButton;
        private DarkUI.Controls.DarkButton AddExitButton;
        private DarkUI.Controls.DarkButton AddTextInputButton;
        private DarkUI.Controls.DarkButton RemoveAllButton;
        private DarkUI.Controls.DarkButton AddDelayButton;
    }
}