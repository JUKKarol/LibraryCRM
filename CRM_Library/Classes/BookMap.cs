using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM_Library.Objects;
using CsvHelper;

namespace CRM_Library.Classes
{
    internal sealed class BookMap : ClassMap<Book>
    {
        public BookMap()
        {
            Map(b => b.Name).Name(nameof(Book.Name));
            Map(b => b.Author).Name(nameof(Book.Author));
            Map(b => b.Category).Name(nameof(Book.Category));
            Map(b => b.Year).Name(nameof(Book.Year));
        }
    }
}
