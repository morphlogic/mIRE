using DryIoc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using mIRE.Server.Core;
using System.Net;
using System.Net.Sockets;

namespace mIRE.Server.Console
{
    internal class LiveServerRunner : IServerRunner
    {
        private const int DefaultPort = 1111;

        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly IClientHandlerHypervisor _clientHandlerHypervisor;

        private IPAddress _host;
        private int _port;

        private TcpListener _tcpListener;

        public LiveServerRunner(ILogger logger, IConfiguration configuration, IClientHandlerHypervisor clientHandlerHypervisor)
        {
            _logger = logger;
            _configuration = configuration;
            _clientHandlerHypervisor = clientHandlerHypervisor;
        }

        public void Initialize()
        {
            var hostSetting = _configuration["Server:Host"];

            _host = string.IsNullOrEmpty(hostSetting)
                ? IPAddress.IPv6Loopback
                : IPAddress.Parse(hostSetting); //  TODO:   defensive coding for invalid hostSetting value

            var portSetting = _configuration["Server:Port"];            

            if (int.TryParse(portSetting, out var portSettingInt))
            {
                _port = portSettingInt;
            }
            else
            {
                _port = DefaultPort;
            }
        }

        public async Task Run()
        {
            _tcpListener = new TcpListener(_host, _port);

            _tcpListener.Start();

            _logger.LogInformation("mIRE is listening @ {_host} on port {_port}...", _host, _port);

            while (true)
            {
                var client = await _tcpListener.AcceptTcpClientAsync();

                _logger.LogInformation("Incoming connection...");

                //  TODO:   remove this service locator anti-pattern
                var handler = LiveIocRegistrar.Container.Resolve<IClientHandler>();

                await _clientHandlerHypervisor.Accept(handler, client);

                //  TODO:   remove below vestige; it's a reminder that we need to close the client in the Handler (or Hypervisor - and release the ClientId)
                //client.Close();
            }
        }
    }
}
