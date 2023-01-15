using TodoMinApi.Infrastructure.Event;

namespace TodoMinApi.Services.Cqr.Commands
{
    public class CreateTodoCommand : ICommand
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
