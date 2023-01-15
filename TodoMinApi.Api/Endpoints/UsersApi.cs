namespace TodoApi;

public static class UsersApi
{
    public static RouteGroupBuilder MapUsersApi(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/users");

        group.WithTags("Users");


        return group;
    }
}
