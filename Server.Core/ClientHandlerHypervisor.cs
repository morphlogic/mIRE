using Microsoft.Extensions.Logging;
using System.Net.Sockets;

namespace mIRE.Server.Core
{
    internal class ClientHandlerHypervisor : IClientHandlerHypervisor
    {
        private readonly ILogger _logger;
        private List<IClientHandler> _clientHandlers = new();
        private HashSet<uint> _clientIds = new();
        private uint _nextClientId = 1;

        private SemaphoreSlim _clientIdsLock = new(1, 1);

        public ClientHandlerHypervisor(ILogger logger)
        {
            _logger = logger;
        }

        public async Task Accept(IClientHandler handler, TcpClient client)
        {
            //  TODO:   timeout ?
            //  lock start
            await _clientIdsLock.WaitAsync();

            while (_clientIds.Contains(_nextClientId))
            {
                _nextClientId++;

                if (_nextClientId == 0)  //  Default client id is 0; should not initialize any client with 0
                {
                    _nextClientId = 1;
                }
            }

            _clientIds.Add(_nextClientId);

            _logger.LogInformation("Initializing ClientHandler with ID:  {_nextClientId}", _nextClientId);

            handler.Initialize(client, _nextClientId);

            _clientIdsLock.Release();

            //  lock end

            _clientHandlers.Add(handler);

            await handler.InitiateUserExchange();
        }
    }
}