using NUMC.Client.GitHub;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NUMC.Client
{
    public static class Update
    {
        public static async Task DownloadDialogShow(Release release)
        {
            if (release == null)
                return;

            await Task.Run(() => {
                var v = new Thread(delegate () {
                    using (var f = new NUMC.NUMCUpdateHandler(release))
                        Forms.Dialogs.ReleaseDownloader.ShowDownloader(release, f);
                });
                v.SetApartmentState(ApartmentState.STA);
                v.Start(); v.Join();
            });
        }

        public static async Task<VersionObject<Release>> CheckUpdatesAsync()
        {
            while (true)
            {
                if (NetworkInterface.GetIsNetworkAvailable())
                    break;

                await Task.Delay(1000);
            }

            var f = await GetLatestReleaseAsync();
            var r = Compare(f);

            Debug.WriteLine($"check for updates\tr:{(r == 127 ? "get releases failed" : r == 255 ? "numc failed" : r == 63 ? "release version parse failed" : r.ToString())}");

            return r == 1 ? f : null;
        }

        public static async Task<VersionObject<Release>> GetLatestReleaseAsync()
        {
            var obj = await Releases.GetReleasesAsync(GitHub.GitHub.NUMCRepositoriesName);

            if (obj == null || obj.ResponseObject == null || obj.ResponseObject == null || obj.ResponseObject.Count < 1)
                return null;

            return obj.ResponseObject.GetLatestRelease();
        }

        public static byte Compare(Release release)
        {
            if (release == null)
                return 127;

            if(!Version.TryParse(Constant.Verison, out Version currentVersion))
                return 255;

            if (!Version.TryParse(release.TagName, out Version releaseVersion))
                return 63;

            return (byte)(releaseVersion > currentVersion ? 1 : 0);
        }

        public static byte Compare(VersionObject<Release> release)
        {
            if (release == null || release.Version == null)
                return 127;

            if (!Version.TryParse(Constant.Verison, out Version currentVersion))
                return 255;

            return (byte)(release.Version > currentVersion ? 1 : 0);
        }
    }
}
