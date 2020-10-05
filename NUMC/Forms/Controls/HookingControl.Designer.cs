namespace NUMC.Forms.Controls
{
    partial class HookingControl
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
            this.components = new System.ComponentModel.Container();
            this.label = new System.Windows.Forms.Label();
            this.TipBox = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label.Location = new System.Drawing.Point(0, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(313, 86);
            this.label.TabIndex = 0;
            this.label.Text = "사용할 키를 선택하거나\r\n여기에 마우스를 올리고, 키를 눌러주세요";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
            this.label.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            this.label.MouseHover += new System.EventHandler(this.Label_MouseHover);
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
            // HookingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "HookingControl";
            this.Size = new System.Drawing.Size(313, 86);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.ToolTip TipBox;
    }
}
