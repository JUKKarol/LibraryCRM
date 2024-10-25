using Bogus;
using LibraryCRM.Domain.Constants;
using LibraryCRM.Domain.Entities;
using LibraryCRM.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;

namespace LibraryCRM.Infrastructure.Seeders;

internal class LibrarySeeder(LibraryDbContext db) : ILibrarySeeder
{
    public async Task Seed()
    {
        if (await db.Database.CanConnectAsync())
        {
            if (!db.Libraries.Any())
            {
                var libraries = GetLibraries(3);
                await db.Libraries.AddRangeAsync(libraries);
                await db.SaveChangesAsync();
            }

            if (!db.Roles.Any())
            {
                var roles = GetRoles();
                await db.Roles.AddRangeAsync(roles);
                await db.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<IdentityRole> GetRoles()
    {
        List<IdentityRole> roles =
        [
            new (UserRoles.User),
            new (UserRoles.Owner),
            new (UserRoles.Admin),
        ];

        return roles;
    }

    private List<Library> GetLibraries(int objectsToGenerate)
    {
        List<Library> libraries = [];

        for (int i = 0; i < objectsToGenerate; i++)
        {
            var library = new Faker<Library>()
                    .RuleFor(l => l.Name, f => f.Lorem.Sentence(1));

            libraries.Add(library);
        }

        return libraries;
    }
}