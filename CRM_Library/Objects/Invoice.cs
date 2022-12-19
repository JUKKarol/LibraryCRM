using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CRM_Library.Objects
{
    public class Invoice : Bill
    {
        private string nipnumber;

        public string NipNumber
        {
            get { return nipnumber; }
            set
            {
                if (value.Length != 10 || Regex.IsMatch(value, @"[a-zA-Z]"))
                {
                    throw new ArgumentException("NIP number must include only 10 numbers");
                }

                nipnumber = value;
            }
        }


        public string CompanyName { get; set; }

        public override void PrintBill(ref List<Book> books, ref List<Book> rentedBooks)
        {

            try
            {
                Console.WriteLine("NIP: ");
                NipNumber = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Company Name: ");
            CompanyName = Console.ReadLine();

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
