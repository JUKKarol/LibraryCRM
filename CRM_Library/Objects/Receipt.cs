using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace CRM_Library.Objects
{
    public class Receipt : Bill
    {
        public override void PrintBill(ref List<Book> books, ref List<Book> rentedBooks)
        {
            Console.WriteLine("Hirer Name: ");
            HirerName = Console.ReadLine();

            try
            {
                Console.WriteLine("Price (euro): ");
                Price = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Insert accurate book name: ");
            string bookName = Console.ReadLine();
            int index = books.FindIndex(b => b.Name == bookName);


            if (index >= 0)
            {
                BookName = books[index].Name;
                BookAuthor = books[index].Author;

                string billBase = $"YourLibaryName\nYourStreet 23/8\nRECEIPT\n{HirerName}, {Price}\nBook: {books[index].Author} - {books[index].Name}\nRent Time: {rentTime}, Return Time: {returnTime}";

                string currentPath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..", "..", ".."));
                string billPath = Path.Combine(currentPath, "bills", "receipts", $"receipt-{HirerName}-{rentTime.Year}-{rentTime.Month}-{rentTime.Day}-{rentTime.Hour}-{rentTime.Minute}-{rentTime.Second}.txt");
                string billDirectory = Path.GetDirectoryName(billPath);
                Directory.CreateDirectory(billDirectory);
                File.WriteAllText(billPath, billBase);

                rentedBooks.Add(books[index]);
                books.RemoveAt(index);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Succes! {bookName} has been rented");
                Console.ResetColor();
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"No {bookName} in stock");
                Console.ResetColor();
                Console.ReadKey();
            }

            
        }
    }
}
