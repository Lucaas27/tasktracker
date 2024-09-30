using TaskTracker.Enums;
using TaskTracker.Interaction;
using TaskTracker.Interaction.Interfaces;
using TaskTracker.Models;
using TaskTracker.Services.Interfaces;

namespace TaskTracker.App
{
    public class InteractiveModeManager : TaskManager
    {
        private readonly Dictionary<Command, Action> _commandActions;


        public InteractiveModeManager(IUserInteraction interaction, IFileService<AppTask> fileService) : base(interaction, fileService)
        {
            _commandActions = new()
            {
                { Command.AddTask, AddTask },
                { Command.EditTask, UpdateTask },
                { Command.DeleteTask, DeleteTask },
                { Command.ListTasksByStatus, ListTasksByStatus },
                { Command.ListAllTasks, ListAllTasks },
                { Command.MarkTaskStatus, MarkTaskStatus },
                { Command.Exit, () => _interaction.PrintMessage("Exiting... Goodbye!", ConsoleMessageType.Info)}
            };
        }

        protected override void MarkTaskStatus()
        {
            _interaction.PrintMessage("Enter the task ID of task to mark:", ConsoleMessageType.Info);
            bool isIdValid = false;
            int taskId = default;
            while (!isIdValid)
            {
                isIdValid = int.TryParse(_interaction.ReadInput(), out taskId);
                if (isIdValid) continue;
                _interaction.PrintMessage("Invalid task ID, it needs to be an integer. Please try again", ConsoleMessageType.Error);
            }
            _interaction.PrintMessage("You need to select a status to update the task", ConsoleMessageType.Info);
            var taskStatus = _interaction.SelectOption<AppTaskStatus>();

            UpdateTaskInFile(taskId, taskStatus);
            Run();
        }

        protected override void ListTasksByStatus()
        {
            var taskStatusToDisplay = _interaction.SelectOption<AppTaskStatus>();

            _tasks.ForEach(t =>
            {
                if (t.Status == taskStatusToDisplay.ToString().ToLower())
                    _interaction.PrintMessage(t.ToString(), ConsoleMessageType.Info);
            });


            Run();
        }
        protected override void ListAllTasks()
        {
            _tasks.ForEach(t =>
            {
                _interaction.PrintMessage(t.ToString(), ConsoleMessageType.Info);
            });


            Run();
        }

        protected override void DeleteTask()
        {
            _interaction.PrintMessage("Enter the task ID to delete:", ConsoleMessageType.Info);
            bool isIdValid = false;
            int taskId = default;
            while (!isIdValid)
            {
                isIdValid = int.TryParse(_interaction.ReadInput(), out taskId);
                if (isIdValid) continue;
                _interaction.PrintMessage("Invalid task ID, it needs to be an integer. Please try again", ConsoleMessageType.Error);
            }
            DeleteTaskInFile(taskId);
            Run();
        }

        protected override void UpdateTask()
        {
            _interaction.PrintMessage("Enter the task ID to edit:", ConsoleMessageType.Info);
            bool isIdValid = false;
            int taskId = default;

            while (!isIdValid)
            {
                isIdValid = int.TryParse(_interaction.ReadInput(), out taskId);
                if (isIdValid) continue;
                _interaction.PrintMessage("Invalid task ID, it needs to be an integer. Please try again", ConsoleMessageType.Error);
            }

            _interaction.PrintMessage("Enter the updated description:", ConsoleMessageType.Info);
            var taskDescription = _interaction.ReadInput();

            UpdateTaskInFile(taskId, taskDescription!);
            Run();
        }

        protected override void AddTask()
        {
            _interaction.PrintMessage("Enter the task description:", ConsoleMessageType.Info);
            var taskDescription = _interaction.ReadInput();
            var newTask = new AppTask
            {
                Id = GetNextId(),
                Description = taskDescription!,
                Status = AppTaskStatus.Todo.ToString().ToLower(),
            };

            SaveTaskToFile(newTask);
            Run();

        }

        public override void Run()
        {
            var optionSelected = _interaction.SelectOption<Command>();
            _commandActions[optionSelected]();
        }
    }
}