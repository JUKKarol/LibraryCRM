using LibraryCRM.Domain.Entities;

namespace LibraryCRM.Domain.Repositories;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllBooks();

    Task<Book?> GetBookById(Guid bookId);

    Task<Guid> CreateBook(Book book);
}