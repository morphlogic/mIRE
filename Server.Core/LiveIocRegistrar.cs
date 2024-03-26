using DryIoc;

namespace mIRE.Server.Core
{
    public static class LiveIocRegistrar
    {
        public static Container Container { get; private set; }

        static LiveIocRegistrar()
        {
            Container = new Container();

            Container.Register<IClientHandlerHypervisor, ClientHandlerHypervisor>(Reuse.Singleton);
            Container.Register<IClientHandler, ClientHandler>();
        }
    }
}