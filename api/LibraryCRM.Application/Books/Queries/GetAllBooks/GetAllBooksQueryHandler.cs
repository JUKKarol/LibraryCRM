using AutoMapper;
using LibraryCRM.Application.Books.DTOs;
using LibraryCRM.Domain.Repositories;
using MediatR;

namespace LibraryCRM.Application.Books.Queries.GetAllBooks;

internal class GetAllBooksQueryHandler(IBookRepository bookRepository,
    IMapper mapper) : IRequestHandler<GetAllBooksQuery, IEnumerable<BookDTO>>
{
    public async Task<IEnumerable<BookDTO>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await bookRepository.GetAllBooks();
        var booksDTO = mapper.Map<IEnumerable<BookDTO>>(books);

        return booksDTO;
    }
}