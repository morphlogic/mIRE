using System.Net.Sockets;

namespace mIRE.Server.Core
{
    public interface IClientHandler
    {
        uint ClientId { get; set; }

        void Initialize(TcpClient client, uint clientId);

        Task InitiateUserExchange();
    }
}