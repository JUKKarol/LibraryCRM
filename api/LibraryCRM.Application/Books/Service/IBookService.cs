using LibraryCRM.Application.Books.DTOs;
using LibraryCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCRM.Application.Books.Service.BookService;

public interface IBookService
{
    Task<IEnumerable<BookDTO>> GetBooks();

    Task<BookDTO> GetBookById(Guid bookId);

    Task<Guid> CreateBook(CreateBookDTO bookRequestDTO);
}