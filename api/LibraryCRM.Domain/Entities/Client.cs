namespace LibraryCRM.Domain.Entities;

public class Client
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = default!;

    public List<RentHistory>? RentHistories { get; set; }
}