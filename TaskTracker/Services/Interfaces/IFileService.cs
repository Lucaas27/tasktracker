using TaskTracker.Models;

namespace TaskTracker.Services.Interfaces
{
    public interface IFileService<T>
    {
        void SaveToFile(List<T> data);
        List<T> LoadFromFile();
    }
}