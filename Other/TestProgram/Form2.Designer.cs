namespace TestProgram
{
    partial class Form2
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cueTextBox1 = new NUMC.Design.Controls.TextBox();
            this.dsa = new NUMC.Forms.Controls.FileDropControl();
            this.ddsa = new NUMC.Forms.Controls.HookingControl();
            this.webBrowser1 = new TestProgram.WebBrowserD();
            this.hookingControl1 = new NUMC.Forms.Controls.HookingControl();
            this.fileDropControl1 = new NUMC.Forms.Controls.FileDropControl();
            this.customTextBox1 = new TestProgram.CustomTextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(340, 73);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(18, 8);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(472, 64);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 16);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // cueTextBox1
            // 
            this.cueTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(47)))));
            this.cueTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cueTextBox1.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cueTextBox1.FontSize = 10F;
            this.cueTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.cueTextBox1.Location = new System.Drawing.Point(109, 64);
            this.cueTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cueTextBox1.Name = "cueTextBox1";
            this.cueTextBox1.Size = new System.Drawing.Size(100, 25);
            this.cueTextBox1.TabIndex = 4;
            // 
            // dsa
            // 
            this.dsa.AllowDrop = true;
            this.dsa.AllowExtensions = null;
            this.dsa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(52)))), ((int)(((byte)(57)))), ((int)(((byte)(65)))));
            this.dsa.File = null;
            this.dsa.Filter = null;
            this.dsa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dsa.FontSize = 10F;
            this.dsa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dsa.Location = new System.Drawing.Point(30, 30);
            this.dsa.Name = "dsa";
            this.dsa.Size = new System.Drawing.Size(150, 150);
            this.dsa.TabIndex = 0;
            // 
            // ddsa
            // 
            this.ddsa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(52)))), ((int)(((byte)(57)))), ((int)(((byte)(65)))));
            this.ddsa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ddsa.FontSize = 10F;
            this.ddsa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ddsa.Location = new System.Drawing.Point(12, 46);
            this.ddsa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ddsa.Name = "ddsa";
            this.ddsa.Size = new System.Drawing.Size(289, 49);
            this.ddsa.TabIndex = 4;
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(258, 210);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 14);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(951, 335);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.WebBrowserShortcutsEnabled = false;
            // 
            // hookingControl1
            // 
            this.hookingControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(52)))), ((int)(((byte)(57)))), ((int)(((byte)(65)))));
            this.hookingControl1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.hookingControl1.FontSize = 10F;
            this.hookingControl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.hookingControl1.Location = new System.Drawing.Point(208, 126);
            this.hookingControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hookingControl1.Name = "hookingControl1";
            this.hookingControl1.Size = new System.Drawing.Size(400, 80);
            this.hookingControl1.TabIndex = 5;
            // 
            // fileDropControl1
            // 
            this.fileDropControl1.AllowDrop = true;
            this.fileDropControl1.AllowExtensions = null;
            this.fileDropControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(52)))), ((int)(((byte)(57)))), ((int)(((byte)(65)))));
            this.fileDropControl1.File = null;
            this.fileDropControl1.Filter = null;
            this.fileDropControl1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.fileDropControl1.FontSize = 10F;
            this.fileDropControl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.fileDropControl1.Location = new System.Drawing.Point(656, 57);
            this.fileDropControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fileDropControl1.Name = "fileDropControl1";
            this.fileDropControl1.Size = new System.Drawing.Size(384, 60);
            this.fileDropControl1.TabIndex = 6;
            // 
            // customTextBox1
            // 
            this.customTextBox1.Location = new System.Drawing.Point(207, 104);
            this.customTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.customTextBox1.Multiline = true;
            this.customTextBox1.Name = "customTextBox1";
            this.customTextBox1.Size = new System.Drawing.Size(986, 324);
            this.customTextBox1.TabIndex = 7;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 563);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.customTextBox1);
            this.Controls.Add(this.fileDropControl1);
            this.Controls.Add(this.hookingControl1);
            this.Controls.Add(this.cueTextBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.MinimumSize = new System.Drawing.Size(189, 108);
            this.Name = "Form2";
            this.Padding = new System.Windows.Forms.Padding(2, 25, 2, 1);
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WebBrowserD webBrowser1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private NUMC.Design.Controls.TextBox cueTextBox1;
        private NUMC.Forms.Controls.FileDropControl dsa;
        private NUMC.Forms.Controls.HookingControl ddsa;
        private NUMC.Forms.Controls.HookingControl hookingControl1;
        private NUMC.Forms.Controls.FileDropControl fileDropControl1;
        private CustomTextBox customTextBox1;
    }
}