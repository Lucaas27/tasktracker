namespace TaskTracker.Interaction
{
    public interface IUserInteraction
    {
        string? ReadInput();
        void PrintCommands();
        void PrintMessage(string output);
        void PrintErrorMessage(string output);
        void Exit();
    }
}