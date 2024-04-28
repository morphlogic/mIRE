namespace mIRE.World.Editor.Console
{
    internal class LoadCommand : Command
    {
        internal override string Key => "load";

        private LoadSource _source;

        internal LoadCommand(string[] arguments) : base(arguments)
        {
            if (arguments[0].ToLower() == "file")
            {
                if(arguments.Length < 2)
                {
                    throw new ArgumentException("arguments cannot have length less than 2", nameof(arguments));
                }
                _source = LoadSource.File;
            }
        }

        internal override void Execute()
        {
            var parser = new FileWorldParser();

            if (Arguments[1].ToLower() == "sandbox")
            {
                parser.LoadSandbox();
            }
        }
    }
}
