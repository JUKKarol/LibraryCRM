using LibraryCRM.API.Extensions;
using LibraryCRM.API.Middlewares;
using LibraryCRM.Application.Extensions;
using LibraryCRM.Application.Services;
using LibraryCRM.Domain.Entities;
using LibraryCRM.Infrastructure.Extensions;
using LibraryCRM.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddPresentation();

builder.Configuration.GetConnectionString("LibraryCRMDb");

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);

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

app.MapGroup("/api/auth")
    .WithTags("Auth")
    .MapIdentityApi<LibraryUser>();

app.UseAuthorization();

app.MapControllers();

app.Run();