using Microsoft.EntityFrameworkCore;
using TodoMinApi.Infrastructure.Event;
using TodoMinApi.Repositories.DbContexts;
using TodoMinApi.Services.Cqr.Commands;

namespace TodoMinApi.Services.Cqr.CommandHandler
{
    public class EditTodoCommandHandler : ICommandHandler<EditTodoCommand>
    {
        private readonly IDbContextFactory<TodoDbConetxt> dbContextFactory;

        public EditTodoCommandHandler(IDbContextFactory<TodoDbConetxt> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public void Handle(EditTodoCommand domainEvent)
        {
            throw new NotImplementedException();
        }

        public async Task HandleAsync(EditTodoCommand command)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            var todoItem = dbContext.Todos.Where(x => x.Id == command.Id).FirstOrDefault();
            if (todoItem != null)
            {
                todoItem.UpdatedDate = DateTime.UtcNow!;
                todoItem.UpdatedBy = "mustafa";
                dbContext.Update(todoItem);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
