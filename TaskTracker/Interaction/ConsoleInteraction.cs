using TaskTracker.Interaction.Interfaces;

namespace TaskTracker.Interaction
{
    public class ConsoleInteraction : IUserInteraction
    {

        public T SelectOption<T>() where T : struct, Enum
        {
            bool isInputValid;
            T validatedInput;
            do
            {
                var options = Enum.GetValues(typeof(T));
                PrintMessage("Please select an option by entering a number: ", ConsoleMessageType.Info);
                foreach (var option in options)
                {
                    PrintMessage($"{(int)option} - {option}", ConsoleMessageType.Success);
                }

                isInputValid = IsEnumInputValid(ReadInput(), out validatedInput);

            } while (!isInputValid);

            return validatedInput;
        }

        public string? ReadInput()
        {
            string? input;
            do
            {
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    PrintMessage("Invalid input. It cannot be null/empty. Please try again.", ConsoleMessageType.Error);
                }
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        private bool IsEnumInputValid<T>(string? input, out T command) where T : struct, Enum
        {
            command = default;

            bool isNumber = Enum.TryParse(input, out T optionNumber);

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
                ConsoleMessageType.Info => ConsoleColor.Green,
                ConsoleMessageType.Success => ConsoleColor.Cyan,
                _ => ConsoleColor.White
            };
            Console.WriteLine(message);
            Console.ResetColor();
        }

    }
}