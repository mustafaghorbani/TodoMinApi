using Microsoft.EntityFrameworkCore;
using TodoMinApi.Domain.Domain;
using TodoMinApi.Infrastructure.Event;
using TodoMinApi.Repositories.DbContexts;
using TodoMinApi.Services.Cqr.Queries;

namespace TodoMinApi.Services.Cqr.QueryHandlers
{
    public class GetTodoByIdQueryHandler : IQueryHandler<GetTodoByIdQuery, Todo>
    {
        private readonly IDbContextFactory<TodoDbConetxt> dbContextFactory;

        public GetTodoByIdQueryHandler(IDbContextFactory<TodoDbConetxt> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public Todo Execute(GetTodoByIdQuery query)
        {
            throw new NotImplementedException();
        }

        public async Task<Todo> ExecuteAsync(GetTodoByIdQuery query)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            return await dbContext.Todos.Where(x => x.Id == query.Id).FirstOrDefaultAsync();
        }
    }
}
