using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUMC.Client.NUMC
{
    public static class NUMC
    {
        public const string NUMCAPIPorxy = "numc-proxy.p-e.kr";

        public static readonly string NUMCStoreAPIPorxy = $"{Uri.UriSchemeHttp}{Uri.SchemeDelimiter}store-redirect.{NUMCAPIPorxy}";
    }
}
