using TaskTracker.Models;

namespace TaskTracker.Services.Interfaces
{
    public interface IFileService
    {
        void SaveToFile(List<AppTask> data);
        List<AppTask> LoadFromFile();
    }
}