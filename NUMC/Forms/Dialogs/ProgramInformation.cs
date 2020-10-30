using NUMC.Design;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;

namespace NUMC.Forms.Dialogs
{
    public partial class ProgramInformation : Dialog
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