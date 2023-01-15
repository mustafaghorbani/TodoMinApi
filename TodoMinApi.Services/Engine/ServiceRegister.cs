using Microsoft.Extensions.DependencyInjection;
using TodoMinApi.Domain.Domain;
using TodoMinApi.Infrastructure.Engine;
using TodoMinApi.Infrastructure.Event;
using TodoMinApi.Services.Cqr.CommandHandler;
using TodoMinApi.Services.Cqr.Commands;
using TodoMinApi.Services.Cqr.Queries;
using TodoMinApi.Services.Cqr.QueryHandlers;

namespace TodoMinApi.Services.Engine
{
    public class ServiceRegister : IServiceRegister
    {
        public void Configure(IServiceCollection service)
        {
            //Query
            service.AddScoped(typeof(IQueryHandler<GetAllTodosQuery, List<Todo>>), typeof(GetAllTodosQueryHandler));
            service.AddScoped(typeof(IQueryHandler<GetOverdueTodosQuery, List<Todo>>), typeof(GetOverdueTodosQueryHandler));
            service.AddScoped(typeof(IQueryHandler<GetPendingTodosQuery, List<Todo>>), typeof(GetPendingTodosQueryHandler));
            service.AddScoped(typeof(IQueryHandler<GetTodoByIdQuery, Todo>), typeof(GetTodoByIdQueryHandler));


            //Command
            service.AddScoped(typeof(ICommandHandler<CreateTodoCommand>), typeof(CreateTodoCommandHandler));
            service.AddScoped(typeof(ICommandHandler<EditTodoCommand>), typeof(EditTodoCommandHandler));
            service.AddScoped(typeof(ICommandHandler<DeleteTodoCommand>), typeof(DeleteTodoCommandHandler));
        }
    }
}
