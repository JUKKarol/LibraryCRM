using LibraryCRM.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryCRM.Infrastructure.Persistence;

internal class LibraryDbContext(DbContextOptions<LibraryDbContext> options) : IdentityDbContext<LibraryUser>(options)
{
    internal DbSet<Library> Libraries { get; set; }
    internal DbSet<Book> Books { get; set; }
    internal DbSet<Author> Authors { get; set; }
    internal DbSet<Client> Clients { get; set; }
    internal DbSet<RentHistory> RentHistories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Library>(l =>
        {
            l.HasKey(l => l.Id);

            l.HasMany(l => l.Books);
            l.HasMany(l => l.RentHistories);
        });

        modelBuilder.Entity<Book>(b =>
        {
            b.HasKey(b => b.Id);

            b.HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);

            b.HasOne(b => b.Library)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.LibraryId)
                .OnDelete(DeleteBehavior.NoAction);

            b.HasMany(b => b.RentHistories)
                .WithOne(rh => rh.Book)
                .HasForeignKey(rh => rh.BookId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Author>(a =>
        {
            a.HasKey(a => a.Id);

            a.HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Client>(c =>
        {
            c.HasKey(c => c.Id);

            c.HasMany(c => c.RentHistories)
                .WithOne(rh => rh.Client)
                .HasForeignKey(rh => rh.ClientId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<RentHistory>(rh =>
        {
            rh.HasKey(rh => rh.Id);

            rh.HasOne(rh => rh.Book)
                .WithMany(b => b.RentHistories)
                .HasForeignKey(rh => rh.BookId)
                .OnDelete(DeleteBehavior.NoAction);

            rh.HasOne(rh => rh.Client)
               .WithMany(b => b.RentHistories)
               .HasForeignKey(rh => rh.ClientId)
               .OnDelete(DeleteBehavior.NoAction);

            rh.HasOne(rh => rh.Library)
               .WithMany(b => b.RentHistories)
               .HasForeignKey(rh => rh.LibraryId)
               .OnDelete(DeleteBehavior.NoAction);
        });
    }
}