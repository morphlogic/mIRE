using DryIoc;
using Microsoft.Extensions.Logging;
using mIRE.Server.Console;
using mIRE.Server.Core;
using System.Net;
using System.Net.Sockets;

LoggerBootstrap.Initialize();

var container = LiveIocRegistrar.Container;

var logger = container.Resolve<ILogger>();

var host = IPAddress.IPv6Loopback;
var port = 1111;

var listener = new TcpListener(host, port);

listener.Start();

logger.LogInformation("mIRE is listening @ {host} on port {port}...", host, port);

var hypervisor = container.Resolve<IClientHandlerHypervisor>();

while (true)
{
    var client = await listener.AcceptTcpClientAsync();

    logger.LogInformation("Incoming connection...");

    var handler = container.Resolve<IClientHandler>();

    await hypervisor.Accept(handler, client);

    //  TODO:   remove below vestige; it's a reminder that we need to close the client in the Handler (or Hypervisor - and release the ClientId)
    //client.Close();
}