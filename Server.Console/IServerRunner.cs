namespace mIRE.Server.Console
{
    internal interface IServerRunner
    {
        void Initialize();

        Task Run();
    }
}