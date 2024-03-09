using System.Net.Sockets;

namespace mIRE.Server.Console
{
    internal class ClientHandler
    {
        private readonly TcpClient _client;
        private readonly NetworkStream _stream;

        private byte[] _bytes = new byte[256];
        private string _text = string.Empty;

        internal ClientHandler(TcpClient client)
        {
            _client = client;
            _stream = _client.GetStream();
        }

        internal async Task InitiateUserExchange()
        {
            _stream.Send($"Welcome to mIRE!{Environment.NewLine}");

            //  TODO:   login/(register+chargen)
            int i;

            while ((i = await _stream.ReadAsync(_bytes)) != 0)
            {
                _text = _bytes.ToString(i);

                System.Console.WriteLine($"Received:  {_text}");

                _text = _text.ToUpper();

                _stream.Send(_text);

                System.Console.WriteLine($"Sent:  {_text}");
            }
        }
    }
}