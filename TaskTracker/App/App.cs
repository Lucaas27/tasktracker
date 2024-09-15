using TaskTracker.Interaction;

namespace TaskTracker.App
{
    public class App
    {
        private readonly IUserInteraction _interaction;

        public App(IUserInteraction interaction)
        {
            _interaction = interaction;
        }
        public void Run()
        {
            // Print the commands
            _interaction.PrintCommands();
            // Read the user input
            var command = _interaction.ReadInput();
            // Handle the user input

            // Exit the application
            _interaction.Exit();
        }
    }
}