using TaskTracker.App;
using TaskTracker.Enums;
using TaskTracker.Interaction;
using TaskTracker.Models;
using TaskTracker.Services;
using TaskTracker.Services.Interfaces;

var consoleInteraction = new ConsoleInteraction();
var fileFormat = FileExtension.Json;
var fileMetadata = new FileMetadata("tasks", fileFormat);
IFileService<AppTask> fileservice = fileFormat == FileExtension.Txt ? new TxtFileService(fileMetadata) : new JsonFileService<AppTask>(fileMetadata);
var app = new ModeSelector(consoleInteraction, fileservice);

try
{
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"Sorry! The application has experienced an unexpected error and will have to be closed.");
    Console.WriteLine($"Error: {ex.Message}");
}