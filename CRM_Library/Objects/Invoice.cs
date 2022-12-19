using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Library.Objects
{
    public class Invoice : Bill
    {
        public string NipNumber { get; set; }
        public string CompanyName { get; set; }

        public override void PrintBill(ref List<Book> books, ref List<Book> rentedBooks)
        {
            Console.WriteLine("NIP: ");
            NipNumber = Console.ReadLine();

            Console.WriteLine("Company Name: ");
            CompanyName = Console.ReadLine();

            Console.WriteLine("Hirer Name: ");
            HirerName = Console.ReadLine();

            Console.WriteLine("Insert accurate book name: ");
            string bookName = Console.ReadLine();


            int index = books.FindIndex(b => b.Name == bookName);

            if (index >= 0)
            {
                string billBase = $"YourLibaryName\nYourStreet 23/8\n---INVOICE---\n{CompanyName} NIP: {NipNumber}\n{HirerName}, {Price}\nBook: {books[index].Author} - {books[index].Name}\nRent Time: {rentTime}, Return Time: {returnTime}";

                File.WriteAllText($@"C:\Users\Admin\source\repos\CRM_Library\CRM_Library\bills\invoices\invoice-{HirerName}-{rentTime.Year}-{rentTime.Month}-{rentTime.Day}-{rentTime.Hour}-{rentTime.Minute}-{rentTime.Second}.txt", billBase);

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
