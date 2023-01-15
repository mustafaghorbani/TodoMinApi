using Microsoft.AspNetCore.Http.HttpResults;
using TodoMinApi.Domain.Domain;
using TodoMinApi.Infrastructure.Event;
using TodoMinApi.Services.Cqr.Commands;
using TodoMinApi.Services.Cqr.Queries;

namespace TodoMinApi.MinApi.Endpoints
{
    public static class TodoApi
    {
        public static RouteGroupBuilder MapTodoApi(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/todos");

            group.WithTags("Todos");

            //1. Create a task - the user can create a new task and optionally set its due date
            routes.MapPost("/", CreateAsync).Accepts<CreateTodoCommand>("application/json");

            routes.MapGet("/", AllAsync);

            //2.Edit task - the user can edit the title and the due date of the task as well as marking it as completed
            routes.MapPut("/{id}", EditAsunc).Accepts<EditTodoCommand>("application/json");

            //3.List pending tasks – the user can see a list of tasks that are not past their due date and not marked as done.
            routes.MapGet("/pending", PendingListAsync);

            //4.List overdue tasks – the user can see a list of tasks that are past their due date and not marked as done.
            routes.MapGet("/overdue", OverdueListAsync);

            routes.MapGet("/{id}", GetByIdAsync);

            routes.MapDelete("/{id}", DeleteAsync);

            return group;
        }

        internal static async Task<IResult> CreateAsync(CreateTodoCommand command, ICommandDispatcher commandDispatcher)
        {
            await commandDispatcher.RaiseAsync(command);
            return TypedResults.Ok();
        }


        private static async Task<Results<Ok, NotFound, BadRequest>> EditAsunc(int id, EditTodoCommand command, ICommandDispatcher commandDispatcher)
        {
            if (id != command.Id)
            {
                return TypedResults.BadRequest();
            }

            await commandDispatcher.RaiseAsync(command);
            return TypedResults.Ok();
        }

        private static async Task<IResult> AllAsync(IQueryDispatcher queryDispatcher)
        {
            var result = await queryDispatcher.ExecuteAsync<GetAllTodosQuery, List<Todo>>(new GetAllTodosQuery { });
            return Results.Ok(result);
        }

        private static async Task<IResult> PendingListAsync(IQueryDispatcher queryDispatcher)
        {
            var result = await queryDispatcher.ExecuteAsync<GetPendingTodosQuery, List<Todo>>(new GetPendingTodosQuery { });
            return Results.Ok(result);
        }

        private static async Task<IResult> OverdueListAsync(IQueryDispatcher queryDispatcher)
        {
            var result = await queryDispatcher.ExecuteAsync<GetOverdueTodosQuery, List<Todo>>(new GetOverdueTodosQuery { });
            return Results.Ok(result);
        }

        private static async Task<Results<Ok<Todo>, NotFound>> GetByIdAsync(int id, IQueryDispatcher queryDispatcher)
        {
            var result = await queryDispatcher.ExecuteAsync<GetTodoByIdQuery, Todo>(new GetTodoByIdQuery { Id = id });
            return TypedResults.Ok(result);
        }
        private static async Task<Results<NotFound, Ok>> DeleteAsync(int id, ICommandDispatcher commandDispatcher)
        {
            await commandDispatcher.RaiseAsync(new DeleteTodoCommand() { Id = id });
            return 0 == 0 ? TypedResults.NotFound() : TypedResults.Ok();
        }
    }


}


//2.review jwt and all Ok
//4.unit test in both 2 projects
//5.About TSL
//