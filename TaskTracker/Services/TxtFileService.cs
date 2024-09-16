using TaskTracker.App;
using TaskTracker.Enums;
using TaskTracker.Models;
using TaskTracker.Services.Interfaces;

namespace TaskTracker.Services
{
    public class TxtFileService : IFileService
    {
        private readonly FileMetadata _filemetadata;

        public TxtFileService(FileMetadata filemetadata)
        {
            _filemetadata = filemetadata;
        }

        private DateTime? ParseDateTime(string dateTimeString)
        {
            return DateTime.TryParse(dateTimeString, out DateTime parsedDateTime) ? parsedDateTime : null;
        }

        public List<AppTask> LoadFromFile()
        {
            if (!File.Exists(_filemetadata.FullPath()))
            {
                return new List<AppTask>();
            }

            var tasks = new List<AppTask>();

            foreach (var line in File.ReadAllLines(_filemetadata.FullPath()))
            {

                var properties = line.Split('|');
                if (properties.Length == 5 && int.TryParse(properties[0], out int id) && Enum.TryParse(properties[2], out AppTaskStatus status))
                {
                    var createdTime = ParseDateTime(properties[3]);
                    var updatedTime = ParseDateTime(properties[4]);

                    var newTask = new AppTask
                    {
                        Id = id,
                        Description = properties[1],
                        Status = status,
                        CreatedAt = createdTime,
                        UpdatedAt = updatedTime,
                    };

                    tasks.Add(newTask);

                }


            }
            return tasks;
        }

        public void SaveToFile(List<AppTask> data)
        {
            var lines = data.Select(t => $"{t.Id}|{t.Description}|{t.Status}|{t.CreatedAt}|{t.UpdatedAt}");
            File.WriteAllLines(_filemetadata.FullPath(), lines);
        }
    }
}