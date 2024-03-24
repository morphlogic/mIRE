using System.Net.Sockets;

namespace mIRE.Server.Core
{
    internal static class NetworkStreamExtensions
    {
        internal static void Send(this NetworkStream stream, string text)
        {
            var bytes = text.ToBytes();

            stream.Write(bytes, 0, bytes.Length);
        }
    }
}