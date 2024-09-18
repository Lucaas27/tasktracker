using System.Text.Json;
using TaskTracker.App;
using TaskTracker.Models;
using TaskTracker.Services.Interfaces;

namespace TaskTracker.Services
{
    public class JsonFileService<T> : IFileService<T>
    {
        private readonly FileMetadata _filemetadata;

        public JsonFileService(FileMetadata filemetadata)
        {
            _filemetadata = filemetadata;
        }
        public void SaveToFile(List<T> data)
        {
            var json = JsonSerializer.Serialize(data);
            File.WriteAllText(_filemetadata.FullPath(), json);
        }

        public List<T> LoadFromFile()
        {
            if (!File.Exists(_filemetadata.FullPath()))
            {
                return new List<T>();
            }

            var json = File.ReadAllText(_filemetadata.FullPath());
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

    }
}