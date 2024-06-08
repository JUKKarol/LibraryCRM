using LibraryCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCRM.Application.Books.DTOs;

public class CreateBookDTO
{
    public string Name { get; set; }
    public string Category { get; set; }
    public Guid AuthorId { get; set; }
    public Guid LibraryId { get; set; }
}