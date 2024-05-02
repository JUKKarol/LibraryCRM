using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCRM.Application.Books.DTOs;
public class BookDTO
{
    public string Name { get; set; } 
    public string Category { get; set; }
    public string AuthorName { get; set; }
    public string LibraryName { get; set; }
}
