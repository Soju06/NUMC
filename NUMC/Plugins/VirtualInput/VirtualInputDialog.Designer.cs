namespace NUMC.Plugins.VirtualInput
{
    partial class VirtualInputDialog
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
            this.KeyboardTypeComboBox = new NUMC.Design.Controls.ComboBox();
            this.ScriptTextBox = new NUMC.Design.Controls.TextBox();
            this.ClearButton = new NUMC.Design.Controls.Button();
            this.AddButton = new NUMC.Design.Controls.Button();
            this.RemoveButton = new NUMC.Design.Controls.Button();
            this.contextMenuStrip1 = new NUMC.Design.Controls.ContextMenuStrip();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // KeyboardTypeComboBox
            // 
            this.KeyboardTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KeyboardTypeComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.KeyboardTypeComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.KeyboardTypeComboBox.FormattingEnabled = true;
            this.KeyboardTypeComboBox.Location = new System.Drawing.Point(10, 38);
            this.KeyboardTypeComboBox.Margin = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.KeyboardTypeComboBox.Name = "KeyboardTypeComboBox";
            this.KeyboardTypeComboBox.Size = new System.Drawing.Size(740, 26);
            this.KeyboardTypeComboBox.TabIndex = 9;
            this.KeyboardTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.KeyboardTypeComboBox_SelectedIndexChanged);
            // 
            // ScriptTextBox
            // 
            this.ScriptTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScriptTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(47)))));
            this.ScriptTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ScriptTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ScriptTextBox.FontSize = 10F;
            this.ScriptTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ScriptTextBox.Location = new System.Drawing.Point(10, 70);
            this.ScriptTextBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ScriptTextBox.MaxLength = 2000;
            this.ScriptTextBox.Multiline = true;
            this.ScriptTextBox.Name = "ScriptTextBox";
            this.ScriptTextBox.Size = new System.Drawing.Size(740, 386);
            this.ScriptTextBox.TabIndex = 1;
            this.ScriptTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyTextBox_KeyDown);
            this.ScriptTextBox.MouseEnter += new System.EventHandler(this.KeyTextBox_Enter);
            this.ScriptTextBox.MouseLeave += new System.EventHandler(this.KeyTextBox_Leave);
            // 
            // ClearButton
            // 
            this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ClearButton.FontSize = 10F;
            this.ClearButton.Location = new System.Drawing.Point(642, 2);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(0, 2, 15, 2);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ClearButton.Size = new System.Drawing.Size(99, 26);
            this.ClearButton.TabIndex = 4;
            this.ClearButton.Text = "초기화";
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.AddButton.FontSize = 10F;
            this.AddButton.Location = new System.Drawing.Point(5, 2);
            this.AddButton.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.AddButton.Name = "AddButton";
            this.AddButton.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.AddButton.Size = new System.Drawing.Size(99, 26);
            this.AddButton.TabIndex = 2;
            this.AddButton.Text = "추가";
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.RemoveButton.FontSize = 10F;
            this.RemoveButton.Location = new System.Drawing.Point(114, 2);
            this.RemoveButton.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.RemoveButton.Size = new System.Drawing.Size(99, 26);
            this.RemoveButton.TabIndex = 3;
            this.RemoveButton.Text = "제거";
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(41)))), ((int)(((byte)(47)))));
            this.contextMenuStrip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ClearButton, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 460);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(756, 30);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.AddButton);
            this.flowLayoutPanel1.Controls.Add(this.RemoveButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(368, 30);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // VirtualInputDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 543);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ScriptTextBox);
            this.Controls.Add(this.KeyboardTypeComboBox);
            this.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.MinimumSize = new System.Drawing.Size(220, 50);
            this.Name = "VirtualInputDialog";
            this.Padding = new System.Windows.Forms.Padding(2, 40, 2, 3);
            this.Resizing = false;
            this.Text = "dd";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VirtualInput_Closing);
            this.Load += new System.EventHandler(this.VirtualInput_Load);
            this.Controls.SetChildIndex(this.KeyboardTypeComboBox, 0);
            this.Controls.SetChildIndex(this.ScriptTextBox, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Design.Controls.ComboBox KeyboardTypeComboBox;
        private Design.Controls.TextBox ScriptTextBox;
        private Design.Controls.Button ClearButton;
        private Design.Controls.Button AddButton;
        private Design.Controls.Button RemoveButton;
        private Design.Controls.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}