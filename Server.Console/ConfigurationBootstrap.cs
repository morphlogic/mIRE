using DryIoc;
using Microsoft.Extensions.Configuration;
using mIRE.Server.Core;

namespace mIRE.Server.Console
{
    internal class ConfigurationBootstrap
    {
        private static bool _isInitialized = false;

        private static readonly object _lock = new();

        internal static void Initialize()
        {
            lock (_lock)
            {
                if (!_isInitialized)
                {
                    var builder = new ConfigurationBuilder()
                        .AddJsonFile("mIREsettings.json", false, true);
                    
                    var configuration = builder.Build();

                    LiveIocRegistrar.Container.RegisterInstance<IConfiguration>(configuration);

                    _isInitialized = true;
                }
            }
        }
    }
}
