using Microsoft.EntityFrameworkCore;
using TodoMinApi.Domain.Domain;
using TodoMinApi.Infrastructure.Event;
using TodoMinApi.Repositories.DbContexts;
using TodoMinApi.Services.Cqr.Queries;

namespace TodoMinApi.Services.Cqr.QueryHandlers
{
    public class GetOverdueTodosQueryHandler : IQueryHandler<GetOverdueTodosQuery, List<Todo>>
    {
        private readonly IDbContextFactory<TodoDbConetxt> dbContextFactory;

        public GetOverdueTodosQueryHandler(IDbContextFactory<TodoDbConetxt> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public List<Todo> Execute(GetOverdueTodosQuery query)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Todo>> ExecuteAsync(GetOverdueTodosQuery query)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            var taskItemList = await dbContext.Todos.Where(x => !x.IsDeleted && !x.IsDone && x.DueDate > DateTime.UtcNow).ToListAsync();
            return taskItemList;
        }
    }
}
