using TaskTracker.Enums;
using TaskTracker.Interaction;
using TaskTracker.Interaction.Interfaces;
using TaskTracker.Models;
using TaskTracker.Services.Interfaces;

namespace TaskTracker.App
{
    public class NonInteractiveModeManager : TaskManager
    {

        public NonInteractiveModeManager(IUserInteraction interaction, IFileService<AppTask> fileService) : base(interaction, fileService)
        {
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
            throw new NotImplementedException();
        }

        protected override void AddTask()
        {
        }

        public override void Run()
        {
        }
    }
}