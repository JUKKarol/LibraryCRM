using AutoMapper;
using LibraryCRM.Domain.Entities;
using LibraryCRM.Domain.Repositories;
using MediatR;

namespace LibraryCRM.Application.Books.Commands.CreateBook;

public class CreateBookCommandHandler(IMapper mapper,
    IBookRepository bookRepository) : IRequestHandler<CreateBookCommand, Guid>
{
    public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = mapper.Map<Book>(request);
        var createdBookId = await bookRepository.CreateBook(book);

        return createdBookId;
    }
}