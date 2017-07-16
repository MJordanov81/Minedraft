using System;

public class Engine
{
    public void Run()
    {
        DraftManager manager = new DraftManager();
        CommandInterpreter interpreter = new CommandInterpreter(manager);

        var input = Console.ReadLine();

        while (input != "Shutdown")
        {
            interpreter.InterpreteCommand(input);

            input = Console.ReadLine();
        }

        interpreter.InterpreteCommand(input);
    }
}

