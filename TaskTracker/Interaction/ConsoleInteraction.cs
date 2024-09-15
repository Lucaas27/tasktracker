namespace TaskTracker.Interaction
{
    public class ConsoleInteraction : IUserInteraction
    {
        public void Exit()
        {
            PrintMessage("Press any key to exit...");
            Console.ReadKey();
        }

        public void PrintCommands()
        {
            PrintMessage("Choose an option:");
            foreach (var command in Enum.GetValues(typeof(Commands)))
            {
                PrintMessage($"{(int)command} - {command}");
            }
        }

        public void PrintErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void PrintMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public string? ReadInput()
        {
            return Console.ReadLine();
        }
    }
}