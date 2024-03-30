using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCRM.Domain.Entities
{
    public class Client
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; } = default!;

        public List<Book>? BooksInUse { get; set; }
        public List<RentHistory>? RentHistory { get; set; }
    }
}
