namespace NUMC.Design.Controls
{
    partial class Dialog
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
            this.btnOk = new NUMC.Design.Controls.Button();
            this.btnCancel = new NUMC.Design.Controls.Button();
            this.btnClose = new NUMC.Design.Controls.Button();
            this.btnYes = new NUMC.Design.Controls.Button();
            this.btnNo = new NUMC.Design.Controls.Button();
            this.btnAbort = new NUMC.Design.Controls.Button();
            this.btnRetry = new NUMC.Design.Controls.Button();
            this.btnIgnore = new NUMC.Design.Controls.Button();
            this.pnlFooter.SuspendLayout();
            this.flowInner.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.flowInner);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(2, 421);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(811, 50);
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
            this.flowInner.Location = new System.Drawing.Point(37, 0);
            this.flowInner.Margin = new System.Windows.Forms.Padding(0);
            this.flowInner.Name = "flowInner";
            this.flowInner.Padding = new System.Windows.Forms.Padding(11, 7, 11, 9);
            this.flowInner.Size = new System.Drawing.Size(774, 50);
            this.flowInner.TabIndex = 10014;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FontSize = 11F;
            this.btnOk.Location = new System.Drawing.Point(11, 7);
            this.btnOk.Margin = new System.Windows.Forms.Padding(0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnOk.Size = new System.Drawing.Size(77, 35);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Ok";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FontSize = 11F;
            this.btnCancel.Location = new System.Drawing.Point(88, 7);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnCancel.Size = new System.Drawing.Size(77, 35);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FontSize = 11F;
            this.btnClose.Location = new System.Drawing.Point(165, 7);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnClose.Size = new System.Drawing.Size(77, 35);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            // 
            // btnYes
            // 
            this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnYes.FontSize = 11F;
            this.btnYes.Location = new System.Drawing.Point(242, 7);
            this.btnYes.Margin = new System.Windows.Forms.Padding(0);
            this.btnYes.Name = "btnYes";
            this.btnYes.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnYes.Size = new System.Drawing.Size(77, 35);
            this.btnYes.TabIndex = 6;
            this.btnYes.Text = "Yes";
            // 
            // btnNo
            // 
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNo.FontSize = 11F;
            this.btnNo.Location = new System.Drawing.Point(319, 7);
            this.btnNo.Margin = new System.Windows.Forms.Padding(0);
            this.btnNo.Name = "btnNo";
            this.btnNo.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnNo.Size = new System.Drawing.Size(77, 35);
            this.btnNo.TabIndex = 7;
            this.btnNo.Text = "No";
            // 
            // btnAbort
            // 
            this.btnAbort.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnAbort.FontSize = 11F;
            this.btnAbort.Location = new System.Drawing.Point(396, 7);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(0);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnAbort.Size = new System.Drawing.Size(77, 35);
            this.btnAbort.TabIndex = 8;
            this.btnAbort.Text = "Abort";
            // 
            // btnRetry
            // 
            this.btnRetry.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnRetry.FontSize = 11F;
            this.btnRetry.Location = new System.Drawing.Point(473, 7);
            this.btnRetry.Margin = new System.Windows.Forms.Padding(0);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnRetry.Size = new System.Drawing.Size(77, 35);
            this.btnRetry.TabIndex = 9;
            this.btnRetry.Text = "Retry";
            // 
            // btnIgnore
            // 
            this.btnIgnore.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.btnIgnore.FontSize = 11F;
            this.btnIgnore.Location = new System.Drawing.Point(550, 7);
            this.btnIgnore.Margin = new System.Windows.Forms.Padding(0);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnIgnore.Size = new System.Drawing.Size(77, 35);
            this.btnIgnore.TabIndex = 10;
            this.btnIgnore.Text = "Ignore";
            // 
            // Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 474);
            this.Controls.Add(this.pnlFooter);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(220, 100);
            this.Name = "Dialog";
            this.Padding = new System.Windows.Forms.Padding(2, 59, 2, 3);
            this.Text = "Design.Dialog";
            this.pnlFooter.ResumeLayout(false);
            this.flowInner.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.FlowLayoutPanel flowInner;
    }
}