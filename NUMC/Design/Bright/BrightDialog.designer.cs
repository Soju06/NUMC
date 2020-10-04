namespace NUMC.Design.Bright
{
    partial class BrightDialog
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
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.flowInner = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOk = new NUMC.Design.Bright.BrightButton();
            this.btnCancel = new NUMC.Design.Bright.BrightButton();
            this.btnClose = new NUMC.Design.Bright.BrightButton();
            this.btnYes = new NUMC.Design.Bright.BrightButton();
            this.btnNo = new NUMC.Design.Bright.BrightButton();
            this.btnAbort = new NUMC.Design.Bright.BrightButton();
            this.btnRetry = new NUMC.Design.Bright.BrightButton();
            this.btnIgnore = new NUMC.Design.Bright.BrightButton();
            this.pnlFooter.SuspendLayout();
            this.flowInner.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.CloseBox = true;
            this.titleBar.Form = this;
            this.titleBar.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.titleBar.MaximizeBox = true;
            this.titleBar.MaximumSize = new System.Drawing.Size(0, 54);
            this.titleBar.MinimizeBox = true;
            this.titleBar.MinimumSize = new System.Drawing.Size(205, 35);
            this.titleBar.Size = new System.Drawing.Size(1023, 35);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.flowInner);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 561);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1023, 57);
            this.pnlFooter.TabIndex = 1;
            // 
            // flowInner
            // 
            this.flowInner.Controls.Add(this.btnOk);
            this.flowInner.Controls.Add(this.btnCancel);
            this.flowInner.Controls.Add(this.btnClose);
            this.flowInner.Controls.Add(this.btnYes);
            this.flowInner.Controls.Add(this.btnNo);
            this.flowInner.Controls.Add(this.btnAbort);
            this.flowInner.Controls.Add(this.btnRetry);
            this.flowInner.Controls.Add(this.btnIgnore);
            this.flowInner.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowInner.Location = new System.Drawing.Point(139, 0);
            this.flowInner.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flowInner.Name = "flowInner";
            this.flowInner.Padding = new System.Windows.Forms.Padding(13, 12, 13, 15);
            this.flowInner.Size = new System.Drawing.Size(884, 57);
            this.flowInner.TabIndex = 10014;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(13, 12);
            this.btnOk.Margin = new System.Windows.Forms.Padding(0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Padding = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.btnOk.Size = new System.Drawing.Size(88, 34);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Ok";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(101, 12);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.btnCancel.Size = new System.Drawing.Size(88, 34);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(189, 12);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.btnClose.Size = new System.Drawing.Size(88, 34);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            // 
            // btnYes
            // 
            this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnYes.Location = new System.Drawing.Point(277, 12);
            this.btnYes.Margin = new System.Windows.Forms.Padding(0);
            this.btnYes.Name = "btnYes";
            this.btnYes.Padding = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.btnYes.Size = new System.Drawing.Size(88, 34);
            this.btnYes.TabIndex = 6;
            this.btnYes.Text = "Yes";
            // 
            // btnNo
            // 
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNo.Location = new System.Drawing.Point(365, 12);
            this.btnNo.Margin = new System.Windows.Forms.Padding(0);
            this.btnNo.Name = "btnNo";
            this.btnNo.Padding = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.btnNo.Size = new System.Drawing.Size(88, 34);
            this.btnNo.TabIndex = 7;
            this.btnNo.Text = "No";
            // 
            // btnAbort
            // 
            this.btnAbort.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnAbort.Location = new System.Drawing.Point(453, 12);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(0);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Padding = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.btnAbort.Size = new System.Drawing.Size(88, 34);
            this.btnAbort.TabIndex = 8;
            this.btnAbort.Text = "Abort";
            // 
            // btnRetry
            // 
            this.btnRetry.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnRetry.Location = new System.Drawing.Point(541, 12);
            this.btnRetry.Margin = new System.Windows.Forms.Padding(0);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Padding = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.btnRetry.Size = new System.Drawing.Size(88, 34);
            this.btnRetry.TabIndex = 9;
            this.btnRetry.Text = "Retry";
            // 
            // btnIgnore
            // 
            this.btnIgnore.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.btnIgnore.Location = new System.Drawing.Point(629, 12);
            this.btnIgnore.Margin = new System.Windows.Forms.Padding(0);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Padding = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.btnIgnore.Size = new System.Drawing.Size(88, 34);
            this.btnIgnore.TabIndex = 10;
            this.btnIgnore.Text = "Ignore";
            // 
            // BrightDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 618);
            this.Controls.Add(this.pnlFooter);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(252, 166);
            this.Name = "BrightDialog";
            this.Text = "BrightDialog";
            this.Controls.SetChildIndex(this.pnlFooter, 0);
            this.Controls.SetChildIndex(this.titleBar, 0);
            this.pnlFooter.ResumeLayout(false);
            this.flowInner.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.FlowLayoutPanel flowInner;
    }
}