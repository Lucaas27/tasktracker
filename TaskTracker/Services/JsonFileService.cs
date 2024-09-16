using System.Text.Json;
using TaskTracker.App;
using TaskTracker.Models;
using TaskTracker.Services.Interfaces;

namespace TaskTracker.Services
{
    public class JsonFileService : IFileService
    {
        private readonly FileMetadata _filemetadata;

        public JsonFileService(FileMetadata filemetadata)
        {
            _filemetadata = filemetadata;
        }
        public void SaveToFile(List<AppTask> data)
        {
            var json = JsonSerializer.Serialize(data);
            File.WriteAllText(_filemetadata.FullPath(), json);
        }

        public List<AppTask> LoadFromFile()
        {
            if (!File.Exists(_filemetadata.FullPath()))
            {
                return new List<AppTask>();
            }

            var json = File.ReadAllText(_filemetadata.FullPath());
            return JsonSerializer.Deserialize<List<AppTask>>(json) ?? new List<AppTask>();
        }

    }
}