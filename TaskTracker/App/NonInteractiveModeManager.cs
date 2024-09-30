using TaskTracker.Enums;
using TaskTracker.Interaction;
using TaskTracker.Interaction.Interfaces;
using TaskTracker.Models;
using TaskTracker.Services.Interfaces;

namespace TaskTracker.App
{
    public class NonInteractiveModeManager : TaskManager
    {
        private readonly Dictionary<string, Action> _commandActions;
        private string[] _args = [];

        public NonInteractiveModeManager(IUserInteraction interaction, IFileService<AppTask> fileService) : base(interaction, fileService)
        {
            _commandActions = new()
            {
                { "add", AddTask },
                { "update", UpdateTask },
                { "delete", DeleteTask },
                { "list", ListAllTasks },
                { "status", ListTasksByStatus },
                { "mark", MarkTaskStatus },
                { "help", DisplayHelp },
                { "exit", () => _interaction.PrintMessage("Exiting... Goodbye!", ConsoleMessageType.Info) }
            };
        }

        protected override void MarkTaskStatus()
        {
            ValidateTaskId();
            ValidateTaskStatus(_args[2]);
            var taskId = int.Parse(_args[1]);
            var taskStatus = _args[2];
            var status = Enum.Parse<AppTaskStatus>(taskStatus, true);
            UpdateTaskInFile(taskId, status);
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
        protected override void ListTasksByStatus()
        {
            ValidateTaskStatus(_args[1]);
            _tasks.ForEach(t =>
            {
                if (t.Status == _args[1])
                {
                    _interaction.PrintMessage(t.ToString(), ConsoleMessageType.Info);
                }
            });

            Run();
        }
        protected override void DeleteTask()
        {
            ValidateTaskId();
            var taskId = int.Parse(_args[1]);
            DeleteTaskInFile(taskId);
            Run();
        }

        protected override void UpdateTask()
        {
            ValidateTaskId();
            var taskId = int.Parse(_args[1]);
            var taskDescription = string.Join(" ", _args.Skip(2));
            UpdateTaskInFile(taskId, taskDescription);
            Run();
        }

        protected override void AddTask()
        {
            var taskDescription = string.Join(" ", _args.Skip(1));
            var newTask = new AppTask
            {
                Id = GetNextId(),
                Description = taskDescription,
                Status = AppTaskStatus.Todo.ToString().ToLower(),
            };

            SaveTaskToFile(newTask);

            Run();
        }

        private void ValidateTaskId()
        {
            if (!int.TryParse(_args[1], out _))
            {
                _interaction.PrintMessage("Invalid task ID. Please try again", ConsoleMessageType.Error);
                Run();
                return;
            }

        }


        private void ValidateTaskStatus(string arg)
        {
            if (!Enum.TryParse<AppTaskStatus>(arg, true, out _))
            {
                _interaction.PrintMessage("Invalid task status. Please try again", ConsoleMessageType.Error);
                Run();
                return;
            }

        }

        private void ValidateCommandArguments(string command)
        {
            if (_args[0] == "help" || _args[0] == "exit" || _args[0] == "list")
            {
                return;
            }

            if (_args.Length < 2 || !_commandActions.ContainsKey(command) || string.IsNullOrWhiteSpace(_args[1]))
            {
                _interaction.PrintMessage("Invalid command arguments. Please try again", ConsoleMessageType.Error);
                Run();
                return;
            }
        }

        private void DisplayHelp()
        {
            _interaction.PrintMessage("Available commands:", ConsoleMessageType.Info);
            _interaction.PrintMessage("add <description> - Add a new task", ConsoleMessageType.Info);
            _interaction.PrintMessage("update <id> <description> - Update an existing task", ConsoleMessageType.Info);
            _interaction.PrintMessage("delete <id> - Delete a task", ConsoleMessageType.Info);
            _interaction.PrintMessage("list - List all tasks", ConsoleMessageType.Info);
            _interaction.PrintMessage("status <status> - List tasks by status (todo, inprogress, done)", ConsoleMessageType.Info);
            _interaction.PrintMessage("mark <id> <status> - Mark a task with a new status", ConsoleMessageType.Info);
            _interaction.PrintMessage("exit - Exits application", ConsoleMessageType.Info);
            Run();
        }

        public override void Run()
        {
            _interaction.PrintMessage("Enter a command or  use 'help' to display available commands:", ConsoleMessageType.Info);
            var input = _interaction.ReadInput();

            // Split the input into arguments
            _args = input!.ToLower().Split(' ');
            var command = _args[0];
            ValidateCommandArguments(command);

            _commandActions[command]();
        }
    }
}