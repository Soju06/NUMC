using NUMC.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUMC.Forms.Dialogs
{
    public partial class ProgramInformation : NDialog
    {
        public ProgramInformation()
        {
            InitializeComponent();

            titleBar.Form = this;

            darkLabel1.Text = Assembly.GetExecutingAssembly().GetName().Name;
            darkLabel2.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            githubBox.Image = Design.Resources.Render.ColorChange((Bitmap)githubBox.Image, Color.FromArgb(70, 70, 70));
        }

        private void GithubBox_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(@"https://github.com/SojuShoveling/NUMC"));
        }
    }
}