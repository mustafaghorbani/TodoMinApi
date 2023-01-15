using TodoMinApi.Infrastructure.Event;

namespace TodoMinApi.Services.Cqr.Commands
{
    public class EditTodoCommand : ICommand
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsDone { get; set; }

    }
}
