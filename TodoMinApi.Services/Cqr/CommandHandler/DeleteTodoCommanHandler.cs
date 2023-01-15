using Microsoft.EntityFrameworkCore;
using TodoMinApi.Infrastructure.Event;
using TodoMinApi.Repositories.DbContexts;
using TodoMinApi.Services.Cqr.Commands;

namespace TodoMinApi.Services.Cqr.CommandHandler
{
    public class DeleteTodoCommandHandler : ICommandHandler<DeleteTodoCommand>
    {

        private readonly IDbContextFactory<TodoDbConetxt> dbContextFactory;

        public DeleteTodoCommandHandler(IDbContextFactory<TodoDbConetxt> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public void Handle(DeleteTodoCommand domainEvent)
        {
            throw new NotImplementedException();
        }

        public async Task HandleAsync(DeleteTodoCommand command)
        {
            using var dbContext = dbContextFactory.CreateDbContext();

            var todoItem = dbContext.Todos.Where(x => x.Id == command.Id).FirstOrDefault();
            if (todoItem != null) { dbContext.Remove(todoItem); }
            await dbContext.SaveChangesAsync();
        }
    }
}
