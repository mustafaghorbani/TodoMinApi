using TodoApi;
using TodoMinApi.Infrastructure.Engine;
using TodoMinApi.Infrastructure.Engine.Register;
using TodoMinApi.Infrastructure.Helper;
using TodoMinApi.Infrastructure.Helpers;
using TodoMinApi.MinApi.Endpoints;
using TodoMinApi.MinApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCustomAuthentication(builder);
builder.Services.AddAuthorization();


builder.Services.RegisterCqrCommand();
builder.Services.RegisterCqrQuery();
builder.Services.RegisterCqrEvent();

CommonHelper.GetAllInstancesOf<IConfigurationRegister>()?
    .OrderBy(x => x.Order)
    .ToList()
    .ForEach(x => x.Configure(builder.Services, builder.Configuration));
CommonHelper.GetAllInstancesOf<IServiceRegister>()?
    .ForEach(x => x.Configure(builder.Services));

builder.Services.AddCustomCors();
builder.Services.AddSwagger();
builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapTodoApi();
app.MapUsersApi();

app.UseCors(AppConstants.CorsPolicy);

app.Run();
