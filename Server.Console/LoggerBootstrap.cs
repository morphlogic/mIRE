using DryIoc;
using Microsoft.Extensions.Logging;
using mIRE.Server.Core;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace mIRE.Server.Console
{
    internal static class LoggerBootstrap
    {
        private static bool _isInitialized = false;

        private static readonly object _lock = new();

        internal static void Initialize()
        {
            lock (_lock)
            {
                if (!_isInitialized)
                {
                    var serilogLogger = new LoggerConfiguration()
                        .Enrich.FromLogContext()
                        .WriteTo.Console()
                        .WriteTo.File("log.txt")
                        .CreateLogger();

                    var loggerFactory = new LoggerFactory().AddSerilog(serilogLogger);

                    //  inject based on assembly? named scope?
                    Microsoft.Extensions.Logging.ILogger microsoftLogger = loggerFactory.CreateLogger("Server.Console");

                    var container = LiveIocRegistrar.Container;

                    container.RegisterInstance(microsoftLogger);

                    _isInitialized = true;
                }
            }
        }

    }
}
