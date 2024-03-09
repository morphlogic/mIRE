namespace mIRE.Server.Console
{    
    internal class ClientHandlerHypervisor
    {
        private List<ClientHandler> _clientHandlers { get; set; }

        internal ClientHandlerHypervisor()
        {
            _clientHandlers = new List<ClientHandler>();
        }

        internal async Task Accept(ClientHandler handler)
        {
            _clientHandlers.Add(handler);

            await handler.InitiateUserExchange();
        }
    }
}