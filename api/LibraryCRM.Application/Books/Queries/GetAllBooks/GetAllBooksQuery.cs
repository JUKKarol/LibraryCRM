using LibraryCRM.Application.Books.DTOs;
using MediatR;

namespace LibraryCRM.Application.Books.Queries.GetAllBooks;

public class GetAllBooksQuery : IRequest<IEnumerable<BookDTO>>
{
}