using System.Net.Sockets;

namespace mIRE.Server.Core
{
    public interface IClientHandlerHypervisor
    {
        Task Accept(IClientHandler handler, TcpClient client);
    }
}