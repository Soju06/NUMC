namespace NUMC.Forms.Controls
{
    partial class FileDropControl
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
            this.DropButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DropButton
            // 
            this.DropButton.AllowDrop = true;
            this.DropButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DropButton.FlatAppearance.BorderSize = 0;
            this.DropButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DropButton.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.DropButton.Location = new System.Drawing.Point(0, 0);
            this.DropButton.Name = "DropButton";
            this.DropButton.Size = new System.Drawing.Size(438, 138);
            this.DropButton.TabIndex = 11;
            this.DropButton.TabStop = false;
            this.DropButton.Text = "여기에 파일을 올려주세요";
            this.DropButton.UseVisualStyleBackColor = true;
            this.DropButton.Click += new System.EventHandler(this.DropButton_Click);
            this.DropButton.DragDrop += new System.Windows.Forms.DragEventHandler(this.DropButton_DragDrop);
            this.DropButton.DragEnter += new System.Windows.Forms.DragEventHandler(this.DropButton_DragEnter);
            // 
            // FileDropControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DropButton);
            this.Name = "FileDropControl";
            this.Size = new System.Drawing.Size(438, 138);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DropButton;
    }
}
