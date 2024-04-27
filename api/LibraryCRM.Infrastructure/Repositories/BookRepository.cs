using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryCRM.Domain.Entities;
using LibraryCRM.Domain.Repositories;
using LibraryCRM.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LibraryCRM.Infrastructure.Repositories;
internal class BookRepository(LibraryDbContext libraryDbContext) : IBookRepository
{
    public async Task<IEnumerable<Book>> GetAllBooks()
    {
        var books = await libraryDbContext.Books.ToListAsync();

        return books;
    }
}
