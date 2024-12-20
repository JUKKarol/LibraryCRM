﻿using LibraryCRM.Domain.Entities;
using LibraryCRM.Domain.Repositories;
using LibraryCRM.Infrastructure.Persistence;
using LibraryCRM.Infrastructure.Repositories;
using LibraryCRM.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryCRM.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("LibraryCRMDb");
        services.AddDbContext<LibraryDbContext>(options => options.UseSqlServer(connectionString));

        services.AddIdentityApiEndpoints<LibraryUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<LibraryDbContext>();

        services.AddScoped<ILibrarySeeder, LibrarySeeder>();
        services.AddScoped<IBookRepository, BookRepository>();
    }
}