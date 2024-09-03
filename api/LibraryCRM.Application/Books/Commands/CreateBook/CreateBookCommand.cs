using MediatR;

namespace LibraryCRM.Application.Books.Commands.CreateBook;

public class CreateBookCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public string Category { get; set; }
    public Guid AuthorId { get; set; }
    public Guid LibraryId { get; set; }
}