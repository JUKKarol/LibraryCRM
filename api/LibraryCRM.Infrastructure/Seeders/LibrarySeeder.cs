using Bogus;
using LibraryCRM.Domain.Entities;
using LibraryCRM.Infrastructure.Persistence;

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
        }
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
