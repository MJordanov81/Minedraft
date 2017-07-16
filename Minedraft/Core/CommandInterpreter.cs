using System;
using System.Linq;

public class CommandInterpreter
{
    private DraftManager manager;

    public CommandInterpreter(DraftManager manager)
    {
        this.manager = manager;
    }

    public void InterpreteCommand(string commandString)
    {
        var commandTokens = commandString.Split();
        var command = commandTokens[0];
        var commandArgs = commandTokens.Skip(1).ToList();

        var result = string.Empty;

        switch (command)
        {
            case "RegisterHarvester":
                result = manager.RegisterHarvester(commandArgs);
                break;

            case "RegisterProvider":
                result = manager.RegisterProvider(commandArgs);
                break;

            case "Mode":
                result = manager.Mode(commandArgs);
                break;

            case "Check":
                result = manager.Check(commandArgs);
                break;

            case "Day":
                result = manager.Day();
                break;

            case "Shutdown":
                result = manager.ShutDown();
                break;
        }

        Console.WriteLine(result);
    }
}

