namespace TaskTracker.Interaction.Interfaces
{
    public interface IUserInteraction
    {
        string? ReadInput();
        T SelectOption<T>() where T : struct, Enum;
        public void PrintMessage(string message, ConsoleMessageType messageType);
    }
}