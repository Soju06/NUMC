using DarkUI.Forms;
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
    public partial class ProgramInformation : DarkDialog
    {
        public ProgramInformation()
        {
            InitializeComponent();

            titleBar.Form = this;

            darkLabel1.Text = Assembly.GetExecutingAssembly().GetName().Name;
            darkLabel2.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void GithubBox_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(@"https://github.com/SojuShoveling/NUMC"));
        }
    }
}