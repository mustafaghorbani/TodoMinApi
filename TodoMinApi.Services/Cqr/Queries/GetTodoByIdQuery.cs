using TodoMinApi.Infrastructure.Event;

namespace TodoMinApi.Services.Cqr.Queries
{
    public class GetTodoByIdQuery : IQuery
    {
        public int Id { get; set; }

    }
}
