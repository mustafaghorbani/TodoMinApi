using Microsoft.EntityFrameworkCore;
using TodoMinApi.Domain.Domain;
using TodoMinApi.Infrastructure.Event;
using TodoMinApi.Repositories.DbContexts;
using TodoMinApi.Services.Cqr.Commands;

namespace TodoMinApi.Services.Cqr.CommandHandler
{
    public class CreateTodoCommandHandler : ICommandHandler<CreateTodoCommand>
    {
        private readonly IDbContextFactory<TodoDbConetxt> dbContextFactory;

        public CreateTodoCommandHandler(IDbContextFactory<TodoDbConetxt> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public void Handle(CreateTodoCommand command)
        {

        }

        public async Task HandleAsync(CreateTodoCommand command)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            var todoItem = new Todo() { Title = command.Title, Description = command.Description, DueDate = command.DueDate };

            //var currentUser = await dbContext.Users.FirstOrDefaultAsync(t => t.Username == user.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            todoItem.CreatedDate = DateTime.UtcNow!;
            todoItem.CreatedBy = "mustafa";

            dbContext.Add(todoItem);
            await dbContext.SaveChangesAsync();
        }
    }
}
