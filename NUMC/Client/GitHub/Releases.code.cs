using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NUMC.Client.GitHub
{
    partial class Releases
    {
        public async static Task<Object<Releases>> GetReleasesAsync(string repo)
        {
            try {
                var client = APIClient.GetHttpClient();

                var response = await client.GetAsync($"{GitHub.Repositories}/{repo}/releases");

                response.EnsureSuccessStatusCode();

                var release = response.StatusCode == System.Net.HttpStatusCode.OK ?
                    ToReleases(await response.Content.ReadAsStringAsync()) : null;

                return new Object<Releases>() {
                    ResponseMessage = response,
                    ResponseObject = release
                };
            } catch (Exception ex) {
                Debug.WriteLine("github api get releases failed\trepo:\t{0}\tex:\t{1}", repo, ex);
            }

            return null;
        }

        public static Releases ToReleases(string json)
        {
            var v = new Releases();
            v.AddRange(Json.Json.Convert<List<Release>>(json));
            return v;
        }


        public VersionObject<Release> GetLatestRelease()
        {
            if (this == null || Count < 1)
                return null;

            Version lv = null;
            Release rs = null;

            for (int i = 0; i < Count; i++)
                if (Version.TryParse(this[i].TagName, out Version v) && v != null && (lv == null || v > lv)) {
                    lv = v;
                    rs = this[i];
                }

            return new VersionObject<Release>(rs, lv);
        }
    }
}
