using TaskTracker.Enums;

namespace TaskTracker.Models
{
    public class AppTask
    {
        public required int Id { get; set; }
        public required string Description { get; set; }
        public required string Status { get; set; }
        public DateTime? CreatedAt { get; set; } = null;
        public DateTime? UpdatedAt { get; set; } = null;

        public AppTask() { }

        public override string ToString()
        {
            return $"Id: {Id}, Description: {Description}, Status: {Status}, CreatedAt: {CreatedAt}, UpdatedAt: {UpdatedAt}";
        }
    }
}