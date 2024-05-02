using LibraryCRM.Application.Books.DTOs;
using LibraryCRM.Domain.Entities;
using LibraryCRM.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCRM.Application.Books.Service.BookService;
internal class BookService(IBookRepository bookRepository) : IBookService
{
    public async Task<IEnumerable<BookDTO>> GetBooks()
    {
        var books = await bookRepository.GetAllBooks();

        return books;
    }

    public async Task<BookDTO> GetBookById(Guid bookId)
    {
        var book = await bookRepository.GetBookById(bookId);

        return book;
    }
}
