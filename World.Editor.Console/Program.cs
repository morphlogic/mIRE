using mIRE.World.Editor.Console;

var assembly = System.Reflection.Assembly.GetExecutingAssembly();
var assemblyVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);

var commandProcessor = new CommandProcessor();

Console.WriteLine($@"
*** mIRE Console World Editor ***
Editor version:  {assemblyVersionInfo.FileVersion}
CLR version:  {Environment.Version}
{Environment.NewLine}");

var input = string.Empty;

var exitConfirmed = false;

while (!exitConfirmed)
{
    while (input != null && !input.StartsWith("exit"))
    {
        var command = commandProcessor.Parse(input);

        if (command != null)
        {
            command.Execute();
        }

        Console.Write($"> ");

        input = Console.ReadLine();

        input = input == null
            ? string.Empty
            : input.ToLower();

        Console.WriteLine();
    }

    if (input == "exit /y")
    {
        exitConfirmed = true;
    }
    else
    {
        Console.WriteLine("Exit editor?");

        var confirmKey = Console.ReadKey().KeyChar.ToString();

        exitConfirmed = confirmKey != null && confirmKey.ToLower() == "y";

        input = string.Empty;

        Console.WriteLine(Environment.NewLine);
    }    

    //if()

    //  parse command
}

Console.WriteLine("END OF LINE");