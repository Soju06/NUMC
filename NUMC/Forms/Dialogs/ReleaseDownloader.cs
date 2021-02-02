using NUMC.Client.GitHub;
using NUMC.Design;
using NUMC.Plugin.ReleaseDownloader;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUMC.Forms.Dialogs
{
    public partial class ReleaseDownloader : Dialog
    {
        private readonly Release _release;
        private readonly ReleaseDownloadHandler _handler;
        private string _releaseUrl = ".";

        public int TimeOut { get; set; } = 30;
        public int TryCount { get; private set; }

        public ReleaseDownloader(Release release, ReleaseDownloadHandler handler)
        {
            _release = release;
            _handler = handler;

            InitializeComponent();

            Text = Setting.Setting.GetTitleName($"Release Downloader ({release.Name})");
            titleLabel.Text = release.Name;
            subtitleLabel.Text = release.TagName;

            contentBox.DocumentCompleted += ContentBox_DocumentCompleted;
            btnOk.DialogResult = DialogResult.None;
            btnCancel.DialogResult = DialogResult.None;
            btnOk.Click += BtnOk_Click;
            btnCancel.Click += BtnCancel_Click;

            InvokeHandler(() => { _handler.Initialize(this); }, "Initialize()");
        }

        private void BtnCancel_Click(object sender, EventArgs e) =>
            InvokeHandler(() => { _handler.CancelButtonClick(); }, "CancelButtonClick()");

        private void BtnOk_Click(object sender, EventArgs e) =>
            InvokeHandler(() => { _handler.OkButtonClick(); }, "OkButtonClick()");

        private void ContentBox_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) => DocumentCompleted(e.Url.ToString());

        public void SetLoadingBarVisible(bool visible)
        {
            if(visible) {
                contentBox.Visible = false;
                contentBox.SuspendLayout();
                loadingPanel.Visible = true;
                loadingProgressBar.Visible = true;
            } else {
                loadingPanel.Visible = false;
                loadingProgressBar.Visible = false;
                contentBox.ResumeLayout();
                contentBox.Visible = true;
            }
        }

        public void SetBottomButtonVisible(bool visible)
        {
            btnOk.Visible = visible;
            btnCancel.Visible = visible;
        }

        private void Navigate()
        {
            if (_release?.HtmlUrl == null)
                Debug.WriteLine("rs is null");

            _releaseUrl = _release.HtmlUrl;

            SetLoadingBarVisible(true);
            documentTimer.Start();
            Debug.WriteLine($"navigate {_releaseUrl}");
            contentBox.Navigate(_releaseUrl);
        }

        private void DocumentCompleted(string url)
        {
            if (url != _releaseUrl)
                return;
            else
                _releaseUrl = "Completed";

            documentTimer.Stop();

            contentBox.DocumentText = ToMarkdownDocument(GetMarkdownBody(contentBox.Document), GetFrameworksColorModeStylesheet(contentBox.Document),
                _styles.Control.BackgroundColor, _styles.Control.Color);

            SetLoadingBarVisible(false);

            InvokeHandler(() => { _handler.NoteLoaded(); }, "NoteLoaded()");
        }

        private string GetMarkdownBody(HtmlDocument document)
        {
            if (document == null)
                return null;

            var es = document.GetElementsByTagName("div");
            var sb = new StringBuilder();

            for (int i = 0; i < es.Count; i++)
                if (es[i].GetAttribute("className").Trim() == "markdown-body")
                    sb.Append(es[i].OuterHtml);

            return sb.ToString();
        }

        private string GetFrameworksColorModeStylesheet(HtmlDocument document)
        {
            if (document == null)
                return null;

            var stylesheet = "https://github.githubassets.com/assets/frameworks-color-modes-669e418b5003d4ac3d2fd7ec0654ea55.css";
            var ls = document.GetElementsByTagName("link");

            for (int i = 0; i < ls.Count; i++) {
                var f = ls[i].GetAttribute("href");

                if (f.Contains("frameworks-color-modes")) {
                    stylesheet = f;
                    break;
                }
            }

            return stylesheet;
        }

        private string ToMarkdownDocument(string markdownHtml, string stylesheet, Color backgroundColor, Color color) =>
            "<html><head><meta charset=\"utf-8\"><link rel=\"stylesheet\" href=\"" + stylesheet?.ToString() + "\"><style>body" +
            "{overflow:auto;cursor:default;background-color:rgb(" + ToRGB(backgroundColor) + ");color:rgb(" + ToRGB(color) + ");margin:25px" +
            "}.markdown-body{margin-bottom:50px;}</style></head><body onselectstart=\"window.event.returnValue=false;\">" + markdownHtml + "</body></html>";

        private string ToRGB(Color color) => color == null ? null : $"{color.R}, {color.G}, {color.B}";

        private void ReleaseDownloader_Load(object sender, EventArgs e) => Navigate();

        private void ReleaseDownloader_Shown(object sender, EventArgs e) => 
            InvokeHandler(() => { _handler.Shown(); }, "Shown()");

        private void ReleaseDownloader_FormClosed(object sender, FormClosedEventArgs e)
        {
            _handler?.Dispose();

            if(contentBox != null && !contentBox.IsDisposed && !contentBox.Disposing) {
                contentBox.Dispose();
                GC.Collect();
            }
        }

        public static void ShowDownloader(Release release, ReleaseDownloadHandler handler)
        {
            if (release == null || handler == null)
                throw new ArgumentNullException("release || handler");

            using (ReleaseDownloader downloader = new ReleaseDownloader(release, handler))
                downloader?.ShowDialog();
        }

        private void DocumentTimer_Tick(object sender, EventArgs e)
        {
            if (TryCount >= TimeOut)
                SetTimeOut();
            else if (_releaseUrl == contentBox?.Url?.ToString() && contentBox?.ReadyState == WebBrowserReadyState.Complete)
                DocumentCompleted(contentBox?.Url?.ToString());
            else TryCount++;
        }

        private void InvokeHandler(Action action, string failName)
        {
            try {
                action?.Invoke();
            } catch (Exception ex) {
                Plugin.Plugin.PluginException(ex, _handler?.GetType()?.Name, $"handler {failName} failed");
            }
        }

        private void SetTimeOut()
        {
            Invoke(new MethodInvoker(() => {
                if (contentBox.Url.ToString() == _releaseUrl)
                    contentBox.Refresh();
                else contentBox.Navigate(_releaseUrl);
            }));
        }
    }
}