using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;
        
        public ClientHandler(ILogger logger)
        {
            ClientId = 0;
            _logger = logger;
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

                    _logger.LogInformation("Received [{ClientId}]:  {_text}", ClientId, _text);

                    _text = _text.ToUpper();

                    _stream.Send(_text);

                    _logger.LogInformation("Sent:  {_text}", _text);
                }

                _stream.Close();
            });
        }
    }
}