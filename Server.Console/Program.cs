using DryIoc;
using mIRE.Server.Core;
using System.Net;
using System.Net.Sockets;

//var listener = new TcpListener(Configuration.Host, Configuration.Port);

//  TODO:   read from Configuration/mIREsettings.json
var host = IPAddress.IPv6Loopback;
var port = 1111;

var listener = new TcpListener(host, port);

listener.Start();

Console.WriteLine($"mIRE is listening @ {host} on port {port}...");

var container = LiveIocRegistrar.Container;

var hypervisor = container.Resolve<IClientHandlerHypervisor>();

while (true)
{
    var client = await listener.AcceptTcpClientAsync();

    Console.WriteLine("Incoming connection...");

    var handler = container.Resolve<IClientHandler>();
    
    await hypervisor.Accept(handler, client);

    //  TODO:   remove below vestige; it's a reminder that we need to close the client in the Handler (or Hypervisor - and release the ClientId)
    //client.Close();
}