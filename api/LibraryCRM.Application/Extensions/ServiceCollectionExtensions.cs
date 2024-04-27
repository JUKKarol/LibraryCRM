using Microsoft.Extensions.DependencyInjection;
using LibraryCRM.Domain.Repositories;
using LibraryCRM.Application.Services.BookService;

namespace LibraryCRM.Application.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
    }
}
