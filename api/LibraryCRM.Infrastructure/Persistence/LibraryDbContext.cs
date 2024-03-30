using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryCRM.Domain.Entities;

namespace LibraryCRM.Infrastructure.Persistence
{
    internal class LibraryDbContext : DbContext
    {
        internal DbSet<Library> Libraries { get; set; }
        internal DbSet<Book> Books { get; set; }
        internal DbSet<Author> Authors { get; set; }
        internal DbSet<Client> Clients { get; set; }
        internal DbSet<RentHistory> RentHistories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LibraryCRMDb;Trusted_Connection=True;");
        }
    }
}
