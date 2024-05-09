using LibraryCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCRM.Domain.Repositories;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllBooks();

    Task<Book?> GetBookById(Guid bookId);

    Task<Guid> CreateBook(Book book);
}