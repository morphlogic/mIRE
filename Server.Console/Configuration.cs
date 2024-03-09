using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace mIRE.Server.Console
{
    //  TODO:   Read these from configuration
    //  TODO:   Change naming convention rule for internal members in "FxCop" / R#
    internal static class Configuration
    {
        internal static readonly IPAddress Host = IPAddress.IPv6Loopback;

        internal static readonly int Port = 1111;
    }
}
