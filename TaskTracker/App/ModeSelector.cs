using TaskTracker.Interaction;
using TaskTracker.Models;
using TaskTracker.Interaction.Interfaces;
using TaskTracker.Services.Interfaces;
using TaskTracker.Enums;
using TaskTracker.App.Interfaces;

namespace TaskTracker.App
{
    public class ModeSelector
    {
        private readonly IUserInteraction _interaction;
        private readonly IFileService<AppTask> _fileService;
        public ModeSelector(IUserInteraction interaction, IFileService<AppTask> fileService)
        {
            _interaction = interaction;
            _fileService = fileService;
        }


        private ITaskManager? SelectMode(AppMode modeSelected)
        {
            return modeSelected switch
            {
                AppMode.Interactive => new InteractiveModeManager(_interaction, _fileService),
                AppMode.NonInteractive => new NonInteractiveModeManager(_interaction, _fileService),
                AppMode.Exit => null,
                _ => throw new ArgumentException("Invalid mode selected"),
            };
        }

        public void Run()
        {
            _interaction.PrintMessage("Welcome to Task Tracker!", ConsoleMessageType.Info);
            var modeSelected = _interaction.SelectOption<AppMode>();
            var taskManager = SelectMode(modeSelected);

            if (taskManager == null)
            {
                _interaction.PrintMessage("Exiting Task Tracker. Goodbye!", ConsoleMessageType.Info);
                return;
            }

            taskManager.Run();
        }

    }
}