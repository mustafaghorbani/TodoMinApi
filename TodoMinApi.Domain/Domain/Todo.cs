using TodoMinApi.Infrastructure.Entity;

namespace TodoMinApi.Domain.Domain
{
    public class Todo : BaseEntity<int, string>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsDone { get; set; }
    }
}
