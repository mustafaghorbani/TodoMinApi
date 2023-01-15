namespace TodoMinApi.MinApi.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication MapSwagger(this WebApplication app)
    {
        //app.UseOpenApi();
        //app.UseSwaggerUI(settings =>
        //{
        //    settings.Path = "/api";
        //});
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.RoutePrefix = "/api";
        });

        return app;
    }
}