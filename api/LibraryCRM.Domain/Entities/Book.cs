using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCRM.Domain.Entities;

public class Book
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = default!;
    public string Category { get; set; } = default!;
    public Guid AuthorId { get; set; }
    public Guid LibraryId { get; set; }

    public Author Author { get; set; } = default!;
    public Library Library { get; set; } = default!;
    public List<RentHistory> RentHistories { get; set; } = default!;
}
