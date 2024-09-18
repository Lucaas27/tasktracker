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
                { Command.EditTask, EditTask },
                { Command.DeleteTask, DeleteTask },
                { Command.ListAllTasks, ListAllTasks },
                { Command.ListDoneTasks, ListDoneTasks },
                { Command.ListTodoTasks, ListTodoTasks },
                { Command.MarkTaskStatus, MarkTaskStatus },
                { Command.Exit, () => _interaction.PrintMessage("Exiting... Goodbye!", ConsoleMessageType.Info)}
            };
        }

        protected override void MarkTaskStatus()
        {
            throw new NotImplementedException();
        }

        protected override void ListTodoTasks()
        {
            throw new NotImplementedException();
        }

        protected override void ListDoneTasks()
        {
            throw new NotImplementedException();
        }

        protected override void ListAllTasks()
        {
            throw new NotImplementedException();
        }
        protected override void DeleteTask()
        {
            throw new NotImplementedException();
        }

        protected override void EditTask()
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

            UpdateTask(taskId, taskDescription!);
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
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            SaveTask(newTask);
            Run();

        }

        public override void Run()
        {
            var optionSelected = _interaction.SelectOption<Command>();
            _commandActions[optionSelected]();
        }
    }
}