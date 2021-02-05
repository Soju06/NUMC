using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUMC.Client
{
    public class Client
    {
        public void Initialize()
        {
            Task.Run(async () => { await InitializeAsync(); });
        }

        public async Task InitializeAsync()
        {
            #region Updates

//#if DEBUG
//            Debug.WriteLine("debug mode update check ignored");
//            await Task.Delay(20);
//#else
            await InitializeUpdates();
//#endif

            #endregion
        }

        internal static async Task InitializeUpdates()
        {
            var v = await Update.CheckUpdatesAsync();
            if (v != null)
                await Update.DownloadDialogShow(v?.Object);
        }
    }
}
