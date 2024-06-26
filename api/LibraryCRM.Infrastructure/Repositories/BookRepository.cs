﻿using LibraryCRM.Domain.Entities;
using LibraryCRM.Domain.Repositories;
using LibraryCRM.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LibraryCRM.Infrastructure.Repositories;

internal class BookRepository(LibraryDbContext libraryDbContext) : IBookRepository
{
    public async Task<IEnumerable<Book>> GetAllBooks()
    {
        var books = await libraryDbContext.Books
            .Include(b => b.Author)
            .Include(b => b.Library)
            .ToListAsync();

        return books;
    }

    public async Task<Book?> GetBookById(Guid bookId)
    {
        var book = await libraryDbContext.Books
            .Include(b => b.Author)
            .Include(b => b.Library)
            .FirstOrDefaultAsync(b => b.Id == bookId);

        return book;
    }

    public async Task<Guid> CreateBook(Book book)
    {
        await libraryDbContext.Books.AddAsync(book);
        await libraryDbContext.SaveChangesAsync();

        return book.Id;
    }
}