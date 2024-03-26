using DryIoc;
using mIRE.Server.Console;
using mIRE.Server.Core;

ConfigurationBootstrap.Initialize();
LoggerBootstrap.Initialize();

var container = LiveIocRegistrar.Container;

container.Register<IServerRunner, LiveServerRunner>(Reuse.Singleton);

var serverRunner = container.Resolve<IServerRunner>();

serverRunner.Initialize();

await serverRunner.Run();