namespace mIRE.World.Editor.Console
{
    internal class CommandProcessor
    {
        private Dictionary<string, Type> _commands = new Dictionary<string, Type>();

        internal CommandProcessor()
        {
            _commands = new Dictionary<string, Type>
            {
                { "load", typeof(LoadCommand) }
            };
        }

        internal Command Parse(string text)
        {
            var arguments = text.Split(' ');

            if(arguments.Length < 1)
            {
                throw new ArgumentException("text cannot have length less than 1", nameof(text));
            }

            if (arguments[0].ToLower() == "load")
            {
                return new LoadCommand(arguments.Skip(1).ToArray());
            }

            return null;            
        }
    }
}
