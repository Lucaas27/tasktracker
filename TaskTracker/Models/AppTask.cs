using TaskTracker.Enums;

namespace TaskTracker.Models
{
    public class AppTask
    {
        public required int Id { get; set; }
        public required string Description { get; set; }
        public required AppTaskStatus Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public AppTask() { }
        public AppTask(string description, AppTaskStatus status, DateTime? createdAt = null, DateTime? updatedAt = null)
        {
            Description = description;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Description: {Description}, Status: {Status}, CreatedAt: {CreatedAt}, UpdatedAt: {UpdatedAt}";
        }
    }
}