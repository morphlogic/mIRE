using DryIoc;
using Microsoft.Extensions.Logging;
using mIRE.Server.Core;
using Serilog;
using System.Net;
using System.Net.Sockets;


//  START:  Logging setup

var serilogLogger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("log.txt")
    .CreateLogger();

var loggerFactory = new LoggerFactory().AddSerilog(serilogLogger);

Microsoft.Extensions.Logging.ILogger microsoftLogger = loggerFactory.CreateLogger("Log");

//  END:    Logging setup

//var listener = new TcpListener(Configuration.Host, Configuration.Port);

//  TODO:   read from Configuration/mIREsettings.json
var host = IPAddress.IPv6Loopback;
var port = 1111;

var listener = new TcpListener(host, port);

listener.Start();

//  S:  Logging test

//Console.WriteLine($"mIRE is listening @ {host} on port {port}...");

microsoftLogger.LogInformation("mIRE is listening @ {host} on port {port}...", host, port);

//  E:  Logging test

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