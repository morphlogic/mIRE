using System.Net.Sockets;
using mIRE.Server.Console;

var listener = new TcpListener(Configuration.Host, Configuration.Port);

listener.Start();

Console.WriteLine($"mIRE is listening @ {Configuration.Host} on port {Configuration.Port}...");

var hypervisor = new ClientHandlerHypervisor();

while (true)
{
    //  TODO:   implement multiple client simultaneous support
    var client = await listener.AcceptTcpClientAsync();

    Console.WriteLine("Incoming connection...");

    await hypervisor.Accept(new ClientHandler(client));

    //  TODO:   remove below vestige; it's a reminder that we need to close the client in the Handler (or Hypervisor)
    //client.Close();
}