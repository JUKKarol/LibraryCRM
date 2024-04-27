using LibraryCRM.Domain.Entities;
using LibraryCRM.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCRM.Application.Services.BookService;
internal class BookService(IBookRepository bookRepository) : IBookService
{
    public async Task<IEnumerable<Book>> GetBooks()
    {
        var books = await bookRepository.GetAllBooks();

        return books;
    }
}
