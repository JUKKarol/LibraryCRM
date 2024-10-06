using LibraryCRM.API.Middlewares;
using LibraryCRM.Application.Extensions;
using LibraryCRM.Domain.Entities;
using LibraryCRM.Infrastructure.Extensions;
using LibraryCRM.Infrastructure.Seeders;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.GetConnectionString("LibraryCRMDb");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<RequestTimeLoggingMiddleware>();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration)
);

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<ILibrarySeeder>();
await seeder.Seed();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RequestTimeLoggingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapIdentityApi<LibraryUser>();

app.UseAuthorization();

app.MapControllers();

app.Run();