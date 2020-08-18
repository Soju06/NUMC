using DarkUI.Forms;
using NUMC.Forms.Dialogs.Macro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUMC.Updater
{
    public partial class Downloader : DarkDialog
    {
        private readonly WebClient client = new WebClient();
        private readonly FileInfo file;

        public Downloader(Version_History version)
        {
            InitializeComponent();

            titleBar.Form = this;
            titleBar.Title = Setting.Setting.GetTitleName("Downloader");

            if (version == null)
                return;

            if (string.IsNullOrWhiteSpace(version.Portable_Download))
                return;

            Random random = new Random();

            file = new FileInfo(Path.Combine(Path.GetTempPath(), $"tmp_{version.Version.Replace(".", "")}_{random.Next(000000, 999999)}.exe"));

            client.DownloadProgressChanged += Client_DownloadProgressChanged;
            client.DownloadFileCompleted += Client_DownloadFileCompleted;

            client.DownloadFileAsync(new Uri(version.Portable_Download), file.FullName);
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    progressBar1.Value = e.ProgressPercentage;
                    darkLabel2.Text = $"{e.ProgressPercentage} / 100%";
                    darkLabel1.Text = $"{e.BytesReceived}Bytes / {e.TotalBytesToReceive}Bytes";
                }));
            }
            catch { }
        }

        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    Process.Start(file.FullName, $"-CP {Application.ExecutablePath}");
                    Application.Exit();
                }));
            }
            catch { }
        }
    }
}