namespace NUMC.Plugins.ScriptEditor
{
    partial class ScriptEditorDialog
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
            this.scriptsView = new NUMC.Design.Controls.ListView();
            this.contextMenuStrip = new NUMC.Design.Controls.ContextMenuStrip();
            this.SuspendLayout();
            // 
            // scriptsView
            // 
            this.scriptsView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scriptsView.BackColor = System.Drawing.Color.Transparent;
            this.scriptsView.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.scriptsView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.scriptsView.ItemHeight = 25;
            this.scriptsView.Location = new System.Drawing.Point(10, 38);
            this.scriptsView.Margin = new System.Windows.Forms.Padding(8);
            this.scriptsView.Name = "scriptsView";
            this.scriptsView.Size = new System.Drawing.Size(643, 577);
            this.scriptsView.TabIndex = 0;
            this.scriptsView.Text = " ";
            this.scriptsView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ScriptsView_KeyDown);
            this.scriptsView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ScriptsView_MouseClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(41)))), ((int)(((byte)(47)))));
            this.contextMenuStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // ScriptEditorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 674);
            this.Controls.Add(this.scriptsView);
            this.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.MinimumSize = new System.Drawing.Size(220, 50);
            this.Name = "ScriptEditorDialog";
            this.Padding = new System.Windows.Forms.Padding(2, 64, 2, 3);
            this.Text = "ScriptsDialog";
            this.Controls.SetChildIndex(this.scriptsView, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Design.Controls.ListView scriptsView;
        private Design.Controls.ContextMenuStrip contextMenuStrip;
    }
}