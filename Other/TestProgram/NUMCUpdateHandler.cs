using NUMC;
using NUMC.Client.GitHub;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProgram
{
    public class NUMCUpdateHandler : NUMC.Plugin.ReleaseDownloader.ReleaseDownloadHandler
    {
        private readonly Release _release;

        private Thread _thread;
        private string _tempPath;
        private WebClient _client;

        public NUMCUpdateHandler(Release release) => _release = release;


        protected override void HandlerDispose()
        {
            if (_thread != null && _thread.IsAlive) {
                _thread.Abort();
                _thread.Join();
            }

            if(_client != null) {
                _client.CancelAsync();
                _client.Dispose();
            }
        }

        public override void NoteLoaded() { }

        public override void Shown() { }

        public override void CancelButtonClick() 
        {
            Debug.WriteLine("3"); 
            Downloader?.Close(); 
        }

        public override void OkButtonClick()
        {
            _thread = new Thread(() => 
                Download()) { IsBackground = true };
            _thread.Start();
        }

        private void Download()
        {
            if (DownloaderNotAvailable || Downloader.loadingLabel == null || 
                Downloader.loadingProgressBar == null || _release?.Assets?.Count < 1)
                    Dispose();

            LoadingLabel = "Preparing to download release..";
            SetBottomButtonVisible(false);
            SetLoadingBarVisible(true);

            Asset asset = null;

            for (int i = 0; i < _release.Assets.Count; i++) {
                var a = _release.Assets[i];

                if (a == null || a.Name == null || a.Content_type == null || !FileNameCheck(a.Name)
                    || !a.Content_type.Contains("application/x-zip-compressed"))
                    continue;

                asset = a;
                break;
            }

            var d = asset == null;

            LoadingLabel = d ? "Cannot get release" : $"Downloading... {asset.Name}";
            LoadingProgressBarStyle = ProgressBarStyle.Blocks;
            LoadingProgressBarValue = d ? 1 : 0;
            SetBottomButtonVisible(d);

            if (d) return;

            CreateWebClient();
            _tempPath = TempFileGenerator();
            _client.DownloadFileAsync(new Uri(asset.Browser_download_url), _tempPath);
        }

        private bool FileNameCheck(string name) => Constant.DEV_MODE ? name.Contains("NUMC.dev") : !name.Contains("NUMC.dev") && name.Contains("NUMC");

        private void CreateWebClient()
        {
            if (_client != null) {
                _client.CancelAsync();
                _client.Dispose();
            }

            _client = new WebClient();

            _client.DownloadFileCompleted += DownloadCompleted;
            _client.DownloadProgressChanged += DownloadProgressChanged;
        }

        private void DownloadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Cancelled || e.Error != null) {
                LoadingLabel = $"download failed, {(e.Cancelled ? "download Cancelled." : e.Error?.Message)}";
                SetBottomButtonVisible(true);
                return;
            }

            if(!File.Exists(_tempPath)) {
                LoadingLabel = $"download failed, file does not exist";
                SetBottomButtonVisible(true);
                return;
            }

            try {
                LoadingLabel = $"Extracting...";
                LoadingProgressBarStyle = ProgressBarStyle.Marquee;

                var f = ZipFile.OpenRead(_tempPath);
                var t = f.GetEntry("NUMC.exe");

                if (t == null) {
                    LoadingLabel = $"Unzip failed, specified file does not exist";
                    LoadingProgressBarStyle = ProgressBarStyle.Blocks;
                    LoadingProgressBarValue = 1;
                    SetBottomButtonVisible(true);
                    return;
                }

                var h = Path.Combine(Path.GetDirectoryName(_tempPath), 
                    Path.GetFileNameWithoutExtension(_tempPath) + ".exe");

                t.ExtractToFile(h);

                Process.Start(h, $"-CP \"{Application.ExecutablePath}\"");
                Environment.Exit(0);
            } catch (Exception ex) {
                LoadingLabel = $"Decompression failed, {ex.Message}";
                LoadingProgressBarStyle = ProgressBarStyle.Blocks;
                LoadingProgressBarValue = 1;
                SetBottomButtonVisible(true);
            }
        }

        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (Downloader == null || Downloader.loadingProgressBar == null)
                return;

            var p = e.ProgressPercentage * 0.01D;

            if (LoadingProgressBarValue != p)
                LoadingProgressBarValue = p;

            LoadingLabel = $"{e.BytesReceived} / {e.TotalBytesToReceive} bytes, {e.ProgressPercentage}%";
        }

        private string TempFileGenerator()
        {
            var rbts = new byte[6]; new Random().NextBytes(rbts);
            var r = Path.Combine(Path.GetTempPath(), $"temp_{BitConverter.ToString(rbts).Replace("-", "")}.tmp");
            if (File.Exists(r)) return TempFileGenerator();
            return r;
        }
    }
}
