using System.Drawing;

namespace NUMC.Design.Controls
{
    partial class TitleBar
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.CloseButton = new System.Windows.Forms.Button();
            this.MaximizeButton = new System.Windows.Forms.Button();
            this.MinimizeButton = new System.Windows.Forms.Button();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.IconButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Location = new System.Drawing.Point(121, 0);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(52, 32);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.TabStop = false;
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseClick);
            // 
            // MaximizeButton
            // 
            this.MaximizeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.MaximizeButton.FlatAppearance.BorderSize = 0;
            this.MaximizeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(53)))), ((int)(((byte)(56)))));
            this.MaximizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
            this.MaximizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MaximizeButton.Location = new System.Drawing.Point(69, 0);
            this.MaximizeButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeButton.Name = "MaximizeButton";
            this.MaximizeButton.Size = new System.Drawing.Size(52, 32);
            this.MaximizeButton.TabIndex = 1;
            this.MaximizeButton.TabStop = false;
            this.MaximizeButton.UseVisualStyleBackColor = true;
            this.MaximizeButton.Click += new System.EventHandler(this.MaximizeClick);
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.MinimizeButton.FlatAppearance.BorderSize = 0;
            this.MinimizeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(53)))), ((int)(((byte)(56)))));
            this.MinimizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
            this.MinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeButton.Location = new System.Drawing.Point(17, 0);
            this.MinimizeButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(52, 32);
            this.MinimizeButton.TabIndex = 2;
            this.MinimizeButton.TabStop = false;
            this.MinimizeButton.UseVisualStyleBackColor = true;
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeClick);
            // 
            // TitleLabel
            // 
            this.TitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleLabel.Location = new System.Drawing.Point(52, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(0, 32);
            this.TitleLabel.TabIndex = 3;
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TitleLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TitleBarMouseClick);
            this.TitleLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBarMouseDown);
            // 
            // IconButton
            // 
            this.IconButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.IconButton.FlatAppearance.BorderSize = 0;
            this.IconButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(53)))), ((int)(((byte)(56)))));
            this.IconButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
            this.IconButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IconButton.Location = new System.Drawing.Point(0, 0);
            this.IconButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.IconButton.Name = "IconButton";
            this.IconButton.Size = new System.Drawing.Size(52, 32);
            this.IconButton.TabIndex = 4;
            this.IconButton.TabStop = false;
            this.IconButton.UseVisualStyleBackColor = true;
            this.IconButton.Click += new System.EventHandler(this.IconButton_Click);
            // 
            // TitleBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.IconButton);
            this.Controls.Add(this.MinimizeButton);
            this.Controls.Add(this.MaximizeButton);
            this.Controls.Add(this.CloseButton);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximumSize = new System.Drawing.Size(0, 35);
            this.MinimumSize = new System.Drawing.Size(173, 32);
            this.Name = "TitleBar";
            this.Size = new System.Drawing.Size(173, 32);
            this.Load += new System.EventHandler(this.TitleBar_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TitleBarMouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBarMouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button MaximizeButton;
        private System.Windows.Forms.Button MinimizeButton;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Button IconButton;
    }
}
