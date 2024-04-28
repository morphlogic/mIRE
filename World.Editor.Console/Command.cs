namespace mIRE.World.Editor.Console
{
    internal abstract class Command
    {
        internal abstract string Key { get; }

        protected string[] Arguments { get; }

        internal Command(string[] arguments)
        {
            Arguments = arguments;
        }

        internal abstract void Execute();
    }
}
