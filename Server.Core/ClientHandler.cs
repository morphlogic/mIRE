using System.Net.Sockets;

namespace mIRE.Server.Core
{
    internal class ClientHandler : IClientHandler
    {
        public uint ClientId { get; set; }

        private TcpClient _client;
        private NetworkStream _stream;

        private byte[] _bytes = new byte[256];
        private string _text = string.Empty;

        //  TODO:   internal ?
        public ClientHandler()
        {
            ClientId = 0;          
        }

        public void Initialize(TcpClient client, uint clientId)
        {
            ClientId = clientId;
         
            _client = client;
            _stream = _client.GetStream();
        }

        public async Task InitiateUserExchange()
        {
            _stream.Send($"Welcome to mIRE!{Environment.NewLine}");

            _ = Task.Run(async () =>
            {
                //  TODO:   login/(register+chargen)            

                int i;

                while ((i = await _stream.ReadAsync(_bytes)) != 0)
                {
                    _text = _bytes.ToString(i);

                    Console.WriteLine($"Received [{ClientId}]:  {_text}");

                    _text = _text.ToUpper();

                    _stream.Send(_text);

                    Console.WriteLine($"Sent:  {_text}");
                }

                _stream.Close();
            });
        }
    }
}