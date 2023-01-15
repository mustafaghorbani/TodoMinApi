using TodoMinApi.Infrastructure.Event;

namespace TodoMinApi.Services.Cqr.Commands
{
    public class DeleteTodoCommand : ICommand
    {
        public int Id { get; set; }

    }
}
