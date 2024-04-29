using LibraryCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCRM.Application.Services.BookService;
public interface IBookService
{
    Task<IEnumerable<Book>> GetBooks();
    Task<Book> GetBookById(Guid bookId);
}
