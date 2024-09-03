using MediatR;

namespace LibraryCRM.Application.Books.Commands.DeleteBook;

public class DeleteBookCommand(Guid id) : IRequest
{
    public Guid Id { get; set; } = id;
}