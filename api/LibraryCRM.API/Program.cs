using LibraryCRM.Application.Extensions;
using LibraryCRM.Infrastructure.Extensions;
using LibraryCRM.Infrastructure.Seeders;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.GetConnectionString("LibraryCRMDb");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Host.UseSerilog((context, configuration) =>
    configuration
        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
        .ReadFrom.Configuration(context.Configuration)
        .Enrich.FromLogContext()
        .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] |{SourceContext}| {Message:lj}{NewLine}{Exception}")
        .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
);

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<ILibrarySeeder>();
await seeder.Seed();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();