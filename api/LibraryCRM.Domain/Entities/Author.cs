using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCRM.Domain.Entities
{
    internal class Author
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = default!;

        public List<Book>? Books { get; set; }
    }
}
