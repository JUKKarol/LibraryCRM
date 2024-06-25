namespace LibraryCRM.Application.Books.DTOs;

public class CreateBookDTO
{
    public string Name { get; set; }
    public string Category { get; set; }
    public Guid AuthorId { get; set; }
    public Guid LibraryId { get; set; }
}