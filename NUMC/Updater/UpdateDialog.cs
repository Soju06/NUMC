using NUMC.Desion;

namespace NUMC.Updater
{
    public partial class UpdateDialog : NDialog
    {
        public UpdateDialog(Version_History version)
        {
            InitializeComponent();

            titleBar.Form = this;
            titleBar.Title = Setting.Setting.GetTitleName("New Version Notes");

            if (version != null)
            {
                NoteBox.Rtf = version.Release_Notes;
                TitleLabel.Text = version.Title;
                SubtitleLabel.Text = version.SubTitle;
            }
        }
    }
}