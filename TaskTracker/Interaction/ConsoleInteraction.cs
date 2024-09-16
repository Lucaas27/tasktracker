using TaskTracker.Interaction.Interfaces;

namespace TaskTracker.Interaction
{
    public class ConsoleInteraction : IUserInteraction
    {


        public void PrintCommands()
        {
            PrintMessage("Choose an option:", ConsoleMessageType.Info);
            foreach (var command in Enum.GetValues(typeof(Command)))
            {
                PrintMessage($"{(int)command} - {command}", ConsoleMessageType.Success);
            }
        }

        public string? ReadInput()
        {
            return Console.ReadLine();
        }


        public bool IsInputValid<T>(string? input, out T command) where T : struct, Enum
        {
            command = default;

            bool isNumber = Enum.TryParse(input, out T optionNumber);

            if (string.IsNullOrWhiteSpace(input))
            {
                PrintMessage("Invalid input. It cannot be null/empty. Please try again.", ConsoleMessageType.Error);
                return false;
            }
            if (!isNumber)
            {
                PrintMessage("Invalid input. Please enter a number and try again.", ConsoleMessageType.Error);
                return false;
            }
            if (!Enum.IsDefined(typeof(T), optionNumber))
            {
                PrintMessage("Invalid input. That option is not defined. Please try again.", ConsoleMessageType.Error);
                return false;
            }

            command = optionNumber;
            return true;
        }

        public void PrintMessage(string message, ConsoleMessageType messageType)
        {
            Console.ForegroundColor = messageType switch
            {
                ConsoleMessageType.Error => ConsoleColor.Red,
                ConsoleMessageType.Info => ConsoleColor.Cyan,
                ConsoleMessageType.Success => ConsoleColor.Green,
                _ => ConsoleColor.White
            };
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void Exit()
        {
            PrintMessage("Press any key to exit...", ConsoleMessageType.Info);
            Console.ReadKey();
        }

    }
}