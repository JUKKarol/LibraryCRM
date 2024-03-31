using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCRM.Domain.Entities
{
    public class RentHistory
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime RentStart { get; set; }
        public DateTime RentEnd { get; set; }
        public Guid BookId { get; set; }
        public Guid ClientId { get; set; }
        public Guid LibraryId { get; set; }

        public Book Book { get; set; } = default!;
        public Client Client { get; set; } = default!;
        public Library Library { get; set; } = default!;
    }
}
