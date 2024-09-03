using MediatR;

namespace LibraryCRM.Application.Books.Commands.UpdateBook;

public class UpdateBookCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public Guid AuthorId { get; set; }
    public Guid LibraryId { get; set; }
}