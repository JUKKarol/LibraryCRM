using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace CRM_Library.Objects
{
    public abstract class Bill
    {
        public string HirerName { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        private string price;
        public string Price
        {
            get { return price; }
            set
            {
                if (!Regex.IsMatch(value, @"[0-9]") || Regex.IsMatch(value, @"[a-zA-Z]"))
                {
                    throw new ArgumentException("Price must be number");
                }

                price = value + "euro";
            }
        }

        public DateTime rentTime = DateTime.Now;
        public DateTime returnTime = DateTime.Now.AddDays(30);


        public virtual void PrintBill(ref List<Book> books, ref List<Book> rentedBooks)
        {
            Console.WriteLine("Hirer Name: ");
            HirerName = Console.ReadLine();

            Console.WriteLine("Insert accurate book name: ");
            string bookName = Console.ReadLine();
            int index = books.FindIndex(b => b.Name == bookName);

            string billBase = $"YourLibaryName\nYourStreet 23/8\n BILL\n{HirerName}, {Price}\nBook: {books[index].Author} - {books[index].Name}\n Rent Time: {rentTime}, Return Time: {returnTime}";

            File.WriteAllText($@"C:\Users\Admin\source\repos\CRM_Library\CRM_Library\bills\bill-{HirerName}-{rentTime.Year}-{rentTime.Month}-{rentTime.Day}-{rentTime.Hour}-{rentTime.Minute}-{rentTime.Second}.txt", billBase);

            rentedBooks.Add(books[index]);
            books.RemoveAt(index);
        }
    }
}
