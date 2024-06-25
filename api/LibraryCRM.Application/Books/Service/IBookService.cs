using LibraryCRM.Application.Books.DTOs;

namespace LibraryCRM.Application.Books.Service.BookService;

public interface IBookService
{
    Task<IEnumerable<BookDTO>> GetBooks();

    Task<BookDTO> GetBookById(Guid bookId);

    Task<Guid> CreateBook(CreateBookDTO bookRequestDTO);
}