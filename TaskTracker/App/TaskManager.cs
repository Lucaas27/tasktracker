using TaskTracker.App.Interfaces;
using TaskTracker.Interaction;
using TaskTracker.Interaction.Interfaces;
using TaskTracker.Models;
using TaskTracker.Services.Interfaces;

namespace TaskTracker.App
{
    public abstract class TaskManager : ITaskManager
    {
        protected readonly List<AppTask> _tasks;
        protected readonly IUserInteraction _interaction;
        private readonly IFileService<AppTask> _fileService;
        public TaskManager(IUserInteraction interaction, IFileService<AppTask> fileService)
        {
            _interaction = interaction;
            _fileService = fileService;
            _tasks = _fileService.LoadFromFile();
        }

        protected int GetNextId() => _tasks.Count > 0 ? _tasks.Max(t => t.Id) + 1 : 1;

        protected virtual void SaveTask(AppTask task)
        {
            _tasks.Add(task);
            _fileService.SaveToFile(_tasks);
            _interaction.PrintMessage($"Task added successfully! ID: {task.Id}", ConsoleMessageType.Info);
        }

        protected virtual void UpdateTask(int taskId, string description)
        {
            var existingTask = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (existingTask == null)
            {
                _interaction.PrintMessage($"Task with ID {taskId} not found!", ConsoleMessageType.Error);
                return;
            }

            existingTask.Description = description;
            existingTask.UpdatedAt = DateTime.Now;
            _fileService.SaveToFile(_tasks);
            _interaction.PrintMessage($"Task updated successfully! ID: {taskId}", ConsoleMessageType.Info);

        }

        protected abstract void MarkTaskStatus();

        protected abstract void ListTodoTasks();

        protected abstract void ListDoneTasks();

        protected abstract void ListAllTasks();
        protected abstract void DeleteTask();

        protected abstract void EditTask();

        protected abstract void AddTask();

        public abstract void Run();

    }
}