using Microsoft.Extensions.DependencyInjection;
using LibraryCRM.Application.Books.Service.BookService;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace LibraryCRM.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;
        services.AddScoped<IBookService, BookService>();

        services.AddAutoMapper(applicationAssembly);

        services.AddValidatorsFromAssembly(applicationAssembly)
            .AddFluentValidationAutoValidation();
    }
}