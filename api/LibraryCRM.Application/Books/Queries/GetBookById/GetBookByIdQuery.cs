using LibraryCRM.Application.Books.DTOs;
using MediatR;

namespace LibraryCRM.Application.Books.Queries.GetBookById;

public class GetBookByIdQuery(Guid id) : IRequest<BookDTO>
{
    public Guid Id { get; } = id;
}