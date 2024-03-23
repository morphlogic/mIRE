using System.Net.Sockets;

namespace mIRE.Server.Console
{
    internal class ClientHandler
    {
        public uint ClientId { get; set; }

        private readonly TcpClient _client;
        private readonly NetworkStream _stream;

        private byte[] _bytes = new byte[256];
        private string _text = string.Empty;

        internal ClientHandler(TcpClient client)
        {
            ClientId = 0;

            _client = client;
            _stream = _client.GetStream();
        }

        internal void Initialize(uint clientId)
        {
            ClientId = clientId;
        }

        internal async Task InitiateUserExchange()
        {
            _stream.Send($"Welcome to mIRE!{Environment.NewLine}");

            _ = Task.Run(async () =>
            {
                //  TODO:   login/(register+chargen)            

                int i;

                while ((i = await _stream.ReadAsync(_bytes)) != 0)
                {
                    _text = _bytes.ToString(i);

                    System.Console.WriteLine($"Received [{ClientId}]:  {_text}");

                    _text = _text.ToUpper();

                    _stream.Send(_text);

                    System.Console.WriteLine($"Sent:  {_text}");
                }

                _stream.Close();
            });            
        }
    }
}