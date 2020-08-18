using DarkUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUMC.Updater
{
    public partial class UpdateDialog : DarkDialog
    {
        public UpdateDialog(Version_History version)
        {
            InitializeComponent();

            titleBar.Form = this;
            titleBar.Title = Setting.Setting.GetTitleName("Update Notes");

            if (version != null)
            {
                NoteBox.Rtf = version.Release_Notes;
                TitleLabel.Text = version.Title;
                SubtitleLabel.Text = version.SubTitle;
            }
        }
    }
}