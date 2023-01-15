using Microsoft.EntityFrameworkCore;
using TodoMinApi.Infrastructure.Helpers;
using TodoMinApi.Repositories.DbContexts;
//using TodoMinApi.Repository;

namespace TodoMinApi.MinApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                //options.SwaggerDoc("V1", new OpenApiInfo()
                //{
                //    Version = "v1",
                //    Title = "To-Do Minimal API ",
                //    Description = "ASP.NET Core 7.0 - Minimal API Example - Todo API implementation using ASP.NET Core Minimal API," +
                //                  "Entity Framework Core, Token authentication, Versioning, Unit Testing and Open API.\",",
                //    //TermsOfService = new Uri("http://www.example.com"),
                //    //Contact = contact,
                //    //License = license
                //});
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,//apiKey
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                });
                //options.OperationFilter<AuthorizationHeaderOperationHeader>();
                //options.OperationFilter<ApiVersionOperationFilter>();
            });

            return services;
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextFactory<TodoDbConetxt>(options =>
            {
                options.UseInMemoryDatabase(nameof(TodoDbConetxt));
            });
            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: AppConstants.CorsPolicy, builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            return services;
        }

        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, WebApplicationBuilder builder)
        {
            //services.AddAuthentication(o =>
            //{
            //    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(o =>
            //{
            //    o.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidIssuer = builder.Configuration["Jwt:Issuer"],
            //        ValidAudience = builder.Configuration["Jwt:Audience"],
            //        IssuerSigningKey = new SymmetricSecurityKey
            //            (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = false,
            //        ValidateIssuerSigningKey = true
            //    };
            //});
            return services;
        }
    }
}
