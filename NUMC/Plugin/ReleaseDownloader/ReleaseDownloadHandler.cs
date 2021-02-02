using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUMC.Plugin.ReleaseDownloader
{
    public abstract class ReleaseDownloadHandler : IDisposable
    {
        public void Initialize(Forms.Dialogs.ReleaseDownloader downloader) => Downloader = downloader;

        public Forms.Dialogs.ReleaseDownloader Downloader { get; internal set; }

        public abstract void Shown();
        public abstract void OkButtonClick();
        public abstract void CancelButtonClick();
        public abstract void NoteLoaded();

        protected abstract void HandlerDispose();

        public void Dispose()
        {
            try {
                HandlerDispose();
            } catch (Exception ex) {
                Plugin.PluginException(ex, "ReleaseDownloadHandler", "ReleaseDownloadHandler dispose failed");
            }
        }


        protected string Title
        {
            get => Downloader?.titleLabel?.Text; set {
                if (Downloader?.titleLabel == null) return;
                DownloaderInvoke(delegate () { Downloader.titleLabel.Text = value; });
            }
        }

        protected string Subtitle
        {
            get => Downloader?.subtitleLabel?.Text; set {
                if (Downloader?.subtitleLabel == null) return;
                DownloaderInvoke(delegate () { Downloader.subtitleLabel.Text = value; });
            }
        }

        protected string LoadingLabel
        {
            get => Downloader?.loadingLabel?.Text; set {
                if (Downloader?.loadingLabel == null) return;
                DownloaderInvoke(delegate () { Downloader.loadingLabel.Text = value; });
            }
        }

        protected double LoadingProgressBarValue
        {
            get => Downloader?.loadingProgressBar == null ?
                -1 : Downloader.loadingProgressBar.Value; 
            set {
                if (Downloader?.loadingProgressBar == null) return;
                DownloaderInvoke(delegate () { Downloader.loadingProgressBar.Value = value; });
            }
        }

        protected ProgressBarStyle LoadingProgressBarStyle
        {
            get => Downloader?.loadingProgressBar == null ? 
                ProgressBarStyle.Blocks : Downloader.loadingProgressBar.Style; 
            set { 
                if (Downloader?.loadingProgressBar == null) return;
                DownloaderInvoke(delegate () { Downloader.loadingProgressBar.Style = value; });
            }
        }


        protected void SetBottomButtonVisible(bool value) {
            if (DownloaderNotAvailable) return;
            DownloaderInvoke(delegate() { Downloader.SetBottomButtonVisible(value); });
        }

        protected void SetLoadingBarVisible(bool value) {
            if (DownloaderNotAvailable) return;
            DownloaderInvoke(delegate () { Downloader.SetLoadingBarVisible(value); });
        }

        protected Design.Controls.ProgressBar GetProgressBar() => 
            Downloader?.loadingProgressBar;

        protected bool DownloaderNotAvailable { get => Downloader == null; }

        protected bool DownloaderInvoke(Action action)
        {
            try {
                if (action == null || DownloaderNotAvailable) return false;
                Downloader?.Invoke(new MethodInvoker(action)); return true;
            } catch {
                return false;
            }
        }
    }
}
