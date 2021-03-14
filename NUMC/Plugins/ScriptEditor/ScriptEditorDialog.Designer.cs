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
            this.contextMenuStrip = new NUMC.Design.Controls.ContextMenuStrip();
            this.scriptsView = new NUMC.Design.Controls.TreeView();
            this.bottomPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.moveup_button = new NUMC.Design.Controls.Button();
            this.movedown_button = new NUMC.Design.Controls.Button();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(41)))), ((int)(((byte)(47)))));
            this.contextMenuStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // scriptsView
            // 
            this.scriptsView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.scriptsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptsView.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.scriptsView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.scriptsView.ItemHeight = 25;
            this.scriptsView.Location = new System.Drawing.Point(2, 34);
            this.scriptsView.Margin = new System.Windows.Forms.Padding(0);
            this.scriptsView.MaxDragChange = 25;
            this.scriptsView.Name = "scriptsView";
            this.scriptsView.Size = new System.Drawing.Size(659, 545);
            this.scriptsView.TabIndex = 3;
            this.scriptsView.Text = "treeView1";
            this.scriptsView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ScriptsView_MouseClick);
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.moveup_button);
            this.bottomPanel.Controls.Add(this.movedown_button);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(2, 579);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Padding = new System.Windows.Forms.Padding(7);
            this.bottomPanel.Size = new System.Drawing.Size(659, 43);
            this.bottomPanel.TabIndex = 4;
            // 
            // moveup_button
            // 
            this.moveup_button.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.moveup_button.FontSize = 10F;
            this.moveup_button.Location = new System.Drawing.Point(14, 7);
            this.moveup_button.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.moveup_button.Name = "moveup_button";
            this.moveup_button.Padding = new System.Windows.Forms.Padding(5);
            this.moveup_button.Size = new System.Drawing.Size(87, 29);
            this.moveup_button.TabIndex = 0;
            this.moveup_button.Text = "Move up";
            this.moveup_button.Click += new System.EventHandler(this.Moveup_button_Click);
            // 
            // movedown_button
            // 
            this.movedown_button.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.movedown_button.FontSize = 10F;
            this.movedown_button.Location = new System.Drawing.Point(115, 7);
            this.movedown_button.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.movedown_button.Name = "movedown_button";
            this.movedown_button.Padding = new System.Windows.Forms.Padding(5);
            this.movedown_button.Size = new System.Drawing.Size(87, 29);
            this.movedown_button.TabIndex = 1;
            this.movedown_button.Text = "Move down";
            this.movedown_button.Click += new System.EventHandler(this.Movedown_button_Click);
            // 
            // ScriptEditorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 674);
            this.Controls.Add(this.scriptsView);
            this.Controls.Add(this.bottomPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.MinimumSize = new System.Drawing.Size(220, 50);
            this.Name = "ScriptEditorDialog";
            this.Padding = new System.Windows.Forms.Padding(2, 34, 2, 2);
            this.Text = "ScriptsDialog";
            this.Controls.SetChildIndex(this.bottomPanel, 0);
            this.Controls.SetChildIndex(this.scriptsView, 0);
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Design.Controls.ContextMenuStrip contextMenuStrip;
        private Design.Controls.TreeView scriptsView;
        private System.Windows.Forms.FlowLayoutPanel bottomPanel;
        private Design.Controls.Button moveup_button;
        private Design.Controls.Button movedown_button;
    }
}