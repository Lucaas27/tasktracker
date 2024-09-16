namespace TaskTracker.Interaction.Interfaces
{
    public interface IUserInteraction
    {
        string? ReadInput();
        void PrintCommands();
        public void PrintMessage(string message, ConsoleMessageType messageType);
        public bool IsInputValid<T>(string? input, out T command) where T : struct, Enum;
        void Exit();
    }
}