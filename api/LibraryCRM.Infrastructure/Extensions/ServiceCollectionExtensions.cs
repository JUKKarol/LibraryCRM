using LibraryCRM.Infrastructure.Persistence;
using LibraryCRM.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCRM.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("LibraryCRMDb");
        services.AddDbContext<LibraryDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<ILibrarySeeder, LibrarySeeder>();
    }
}
