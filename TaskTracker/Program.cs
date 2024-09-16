using TaskTracker.App;
using TaskTracker.Interaction;

var consoleInteraction = new ConsoleInteraction();
var app = new TaskManager();

try
{
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"Sorry! The application has experienced an unexpected error and will have to be closed.");
    Console.WriteLine($"Error: {ex.Message}");
}