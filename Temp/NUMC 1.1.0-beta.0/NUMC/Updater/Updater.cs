using System;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace NUMC.Updater
{
    public class Updater
    {
        public static readonly string CheckURI = @"https://raw.githubusercontent.com/SojuShoveling/NUMC/master/Updates.json";

        public static Updates Update { get; set; }

        public static void GetUpdates()
        {
            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                string updatesJson = client.DownloadString(CheckURI);

                if (!string.IsNullOrWhiteSpace(updatesJson))
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    Update = (Updates)serializer.Deserialize(updatesJson, typeof(Updates));
                }
            }
        }

        public static bool CheckUpdates()
        {
            try
            {
                if (Update == null)
                    GetUpdates();

                return Version.TryParse(Update.Last_Version, out Version last) && last > Assembly.GetExecutingAssembly().GetName().Version;
            }
            catch { }

            return false;
        }

        public static void StartUpdate()
        {
            try
            {
                if (Update == null)
                    GetUpdates();

                Version_History version = null;

                for (int i = 0; i < Update.Version_History.Length; i++)
                {
                    if (Update.Version_History[i].Version == Update.Last_Version)
                    {
                        version = Update.Version_History[i];
                        break;
                    }
                }

                if (version == null)
                    return;

                using (UpdateDialog dialog = new UpdateDialog(version))
                {
                    if (dialog.ShowDialog() != DialogResult.OK)
                        return;
                }

                using (Downloader dialog = new Downloader(version))
                {
                    dialog.ShowDialog();
                }
            }
            catch { }
        }
    }

    public class Updates
    {
        public string Last_Version { get; set; }
        public Version_History[] Version_History { get; set; }
    }

    public class Version_History
    {
        public string Version { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Release_Notes { get; set; }
        public string Portable_Download { get; set; }
    }
}