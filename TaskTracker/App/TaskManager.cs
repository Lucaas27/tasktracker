using TaskTracker.Interaction;
using TaskTracker.Models;
using TaskTracker.Interaction.Interfaces;
using TaskTracker.Services.Interfaces;

namespace TaskTracker.App
{
    public class TaskManager
    {
        private readonly List<AppTask> tasks;
        private readonly IUserInteraction _interaction;
        private readonly IFileService _fileService;

        public TaskManager(IUserInteraction interaction, IFileService fileService)
        {
            _interaction = interaction;
            _fileService = fileService;
            tasks = _fileService.LoadFromFile();
        }

        public void Run()
        {
            _interaction.PrintMessage("Welcome to Task Tracker!", ConsoleMessageType.Info);
        }

        private int GetNextId() => tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1;


    }
    // {
    //     private readonly IUserInteraction _interaction;
    //     private readonly ITaskManager _taskManager;

    //     public TaskTracker(IUserInteraction interaction, ITaskManager taskManager)
    //     {
    //         _taskManager = taskManager;
    //         _interaction = interaction;
    //     }
    //     public void Run()
    //     {
    //         var appMode = LoadMainScreen();

    //         switch (appMode)
    //         {
    //             case AppMode.Interactive:
    //                 InteractiveMode();
    //                 break;
    //             case AppMode.NonInteractive:
    //                 NonInteractiveMode();
    //                 break;
    //             case AppMode.Exit:
    //                 Exit();
    //                 break;
    //         }


    //     }


    //     private AppMode LoadMainScreen()
    //     {
    //         AppMode appModeValidated;
    //         bool isInputValid;
    //         do
    //         {
    //             _interaction.PrintMessage("Welcome to Task Tracker!", MessageType.Info);
    //             _interaction.PrintMessage("Select an option by choosing a number:", MessageType.Info);
    //             foreach (var mode in Enum.GetValues(typeof(AppMode)))
    //             {
    //                 _interaction.PrintMessage($"{(int)mode} - {mode}", MessageType.Success);
    //             }
    //             isInputValid = _interaction.IsInputValid(_interaction.ReadInput(), out appModeValidated);
    //         } while (!isInputValid);

    //         return appModeValidated;
    //     }

    //     public void Exit()
    //     {
    //         _interaction.PrintMessage("Press any key to exit...", MessageType.Info);
    //         Console.ReadKey();
    //     }

    //     private void NonInteractiveMode()
    //     {
    //         throw new NotImplementedException();
    //     }

    //     private void InteractiveMode()
    //     {
    //         Command validatedInput;
    //         do
    //         {
    //             // Print the commands
    //             _interaction.PrintCommands();
    //             // Read the user input
    //             string? input = _interaction.ReadInput();
    //             // Validate the user input
    //             _interaction.IsInputValid(input, out validatedInput);

    //         } while (validatedInput != Command.Exit);

    //         // Handle the user input
    //         switch (validatedInput)
    //         {
    //             case Command.ListTasks:
    //                 _taskManager.ListTasks();
    //                 break;
    //             case Command.AddTask:
    //                 // _taskManager.AddTask();
    //                 break;
    //             case Command.EditTask:
    //                 _taskManager.EditTask();
    //                 break;
    //             case Command.DeleteTask:
    //                 _taskManager.DeleteTask();
    //                 break;
    //             case Command.Exit:
    //                 LoadMainScreen();
    //                 break;
    //         }
    //     }



    // }
}