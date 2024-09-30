using TaskTracker.App.Interfaces;
using TaskTracker.Enums;
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

        protected virtual void SaveTaskToFile(AppTask task)
        {
            _tasks.Add(task);
            _fileService.SaveToFile(_tasks);
            _interaction.PrintMessage($"Task added successfully! ID: {task.Id}", ConsoleMessageType.Info);
        }

        protected virtual void UpdateTaskInFile(int taskId, string description)
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
            _interaction.PrintMessage($"Task updated successfully! ID: {existingTask.Id}", ConsoleMessageType.Info);

        }
        protected virtual void UpdateTaskInFile(int taskId, AppTaskStatus status)
        {
            var existingTask = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (existingTask == null)
            {
                _interaction.PrintMessage($"Task with ID {taskId} not found!", ConsoleMessageType.Error);
                return;
            }

            existingTask.Status = status.ToString().ToLower();
            existingTask.UpdatedAt = DateTime.Now;
            _fileService.SaveToFile(_tasks);
            _interaction.PrintMessage($"Task marked as {status.ToString().ToLower()}! ID: {existingTask.Id}", ConsoleMessageType.Info);

        }


        protected virtual void DeleteTaskInFile(int taskId)
        {
            var taskToDelete = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (taskToDelete == null)
            {
                _interaction.PrintMessage($"Task with ID {taskId} not found!", ConsoleMessageType.Error);
                return;
            }

            _tasks.Remove(taskToDelete);
            _fileService.SaveToFile(_tasks);
            _interaction.PrintMessage($"Task deleted successfully! ID: {taskId}", ConsoleMessageType.Info);

        }


        protected abstract void MarkTaskStatus();

        protected abstract void ListAllTasks();
        protected abstract void ListTasksByStatus();

        protected abstract void DeleteTask();

        protected abstract void UpdateTask();

        protected abstract void AddTask();

        public abstract void Run();

    }
}