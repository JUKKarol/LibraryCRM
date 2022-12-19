using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM_Library.Objects;
using CRM_Library.Classes;
using CRM_Library.Enums;

namespace CRM_Library.Objects
{
    public class Book
    {
        public Book()
        {
            
        }

        public Book(string Name, string Author, int Category, int Year)
        {
            this.Name = Name;
            this.Author = Author;
            this.Category = (Category)Category;
            this.Year = Year;
        }

        public string Name  { get; set; }
        public string Author  { get; set; }
        public Category Category  { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"{(Name.Length > 25 ? Name.Substring(0, 25) + "..." : Name),-28} | " +
                   $"{Author,-25} | " +
                   $"{Category,-20} | " +
                   $"{Year,-10} ";
        }

    }
}
