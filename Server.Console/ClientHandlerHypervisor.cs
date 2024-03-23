namespace mIRE.Server.Console
{
    internal class ClientHandlerHypervisor
    {
        private List<ClientHandler> _clientHandlers = new();
        private HashSet<uint> _clientIds = new();
        private uint _nextClientId = 1;

        private SemaphoreSlim _clientIdsLock = new(1, 1);

        internal ClientHandlerHypervisor()
        {
        }

        internal async Task Accept(ClientHandler handler)
        {
            //  TODO:   timeout ?
            //  lock start
            await _clientIdsLock.WaitAsync();

            while (_clientIds.Contains(_nextClientId))
            {
                _nextClientId++;

                if(_nextClientId == 0)  //  Default client id is 0; should not initialize any client with 0
                {
                    _nextClientId = 1;
                }
            }

            _clientIds.Add(_nextClientId);

            handler.Initialize(_nextClientId);

            _clientIdsLock.Release();

            //  lock end

            _clientHandlers.Add(handler);

            await handler.InitiateUserExchange();
        }
    }
}