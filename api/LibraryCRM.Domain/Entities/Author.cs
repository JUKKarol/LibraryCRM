namespace LibraryCRM.Domain.Entities;

public class Author
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = default!;

    public List<Book>? Books { get; set; }
}