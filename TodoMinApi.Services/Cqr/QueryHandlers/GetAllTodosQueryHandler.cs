
using Microsoft.EntityFrameworkCore;
using TodoMinApi.Domain.Domain;
using TodoMinApi.Infrastructure.Event;
using TodoMinApi.Repositories.DbContexts;
using TodoMinApi.Services.Cqr.Queries;

namespace TodoMinApi.Services.Cqr.QueryHandlers
{
    public class GetAllTodosQueryHandler : IQueryHandler<GetAllTodosQuery, List<Todo>>
    {
        private readonly IDbContextFactory<TodoDbConetxt> dbContextFactory;

        public GetAllTodosQueryHandler(IDbContextFactory<TodoDbConetxt> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }
        public List<Todo> Execute(GetAllTodosQuery query)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Todo>> ExecuteAsync(GetAllTodosQuery query)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            var taskItemList = await dbContext.Todos.Where(x => !x.IsDeleted).AsNoTracking().ToListAsync();
            return new List<Todo>();
        }
    }
}
