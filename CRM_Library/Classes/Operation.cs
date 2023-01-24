using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM_Library.Objects;
using CRM_Library.Classes;
using CRM_Library.Enums;
using System.Reflection;

namespace CRM_Library.Classes
{
    public static class Operation
    {
        public static void AddBook(ref List<Book> books)
        {
            Console.WriteLine("Book name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Author name: ");
            string author = Console.ReadLine();

            try
            {
                Console.WriteLine("Category: ");
                PrintEnums(typeof(Category));
                int category = int.Parse(Console.ReadLine());

                if (category < 0 || category > (Enum.GetValues(typeof(Category)).Length) - 1)
                {
                    throw new Exception($"Category must be 0 - {(Enum.GetValues(typeof(Category)).Length) - 1}");
                }

                Console.WriteLine("Relase Year: ");
                int year = int.Parse(Console.ReadLine());
                if (year < -10000 || year > DateTime.Now.Year)
                {
                    throw new Exception("Wrong release year");
                }

                Book newBook = new Book(name, author, category, year);

                books.Add(newBook);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Book was summed to stock");
                Console.ResetColor();
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Year must be number");
                Console.ResetColor();
                return;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                return;
            }
        }

        public static void RemoveBooks(ref List<Book> books)
        {
            Console.WriteLine("Insert accurate book name: ");
            string bookName = Console.ReadLine();

            int removedCount = books.RemoveAll(b => b.Name == bookName);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{removedCount} books removed");
            Console.ResetColor();
        }

        public static void RemoveBook(ref List<Book> books)
        {
            Console.WriteLine("Insert accurate book name: ");
            string bookName = Console.ReadLine();

            int index = books.FindIndex(b => b.Name == bookName);

            if (index >= 0)
            {
                books.RemoveAt(index);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{bookName} removed");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"There is not book '{bookName}'");
                Console.ResetColor();
            }

        }

        public static void SearchBooks(List<Book> books)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("(1) Search by name");
                Console.WriteLine("(2) Search by author");
                Console.WriteLine("(3) Search by year");
                Console.WriteLine("(4) Search by category");
                Console.WriteLine("(x) Exit");
                string x = Console.ReadLine();

                if (x == "1")
                {
                    Console.WriteLine("Insert searching name: ");
                    string userInput = Console.ReadLine();

                    List<Book> searchedBooks = new List<Book>(books.Where(b => b.Name.Contains(userInput)));

                    Display(searchedBooks);
                }
                else if (x == "2")
                {
                    Console.WriteLine("Insert searching author: ");
                    string userInput = Console.ReadLine();

                    List<Book> searchedBooks = new List<Book>(books.Where(b => b.Author.Contains(userInput)));

                    Display(searchedBooks);
                }
                else if (x == "3")
                {
                    try
                    {
                        Console.WriteLine("Insert searching minimum year: ");
                        int userInputMin = int.Parse(Console.ReadLine());
                        Console.WriteLine("Insert searching maximum year: ");
                        int userInputMax = int.Parse(Console.ReadLine());

                        List<Book> searchedBooks = new List<Book>(books.Where(b => b.Year >= userInputMin && b.Year <= userInputMax));
                        Display(searchedBooks);
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("minimum and maximum years must be numbers");
                        Console.ResetColor();
                        return;
                    }
                }
                else if (x == "4")
                {
                    Console.WriteLine("Insert searching category: ");
                    PrintEnums(typeof(Category));
                    string userInput = Console.ReadLine();
                    Category category = (Category)Enum.Parse(typeof(Category), userInput);

                    List<Book> searchedBooks = new List<Book>(books.Where(b => b.Category == category));

                    Display(searchedBooks);
                }
                else if (x == "x")
                {
                    break;
                }

                Console.ReadKey();
            }
        }

        public static void Display(List<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }

            if (books.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No records to display");
                Console.ResetColor();
            }

        }

        public static void DisplayReceipts(List<Receipt> receipts)
        {
            for (int i = 0; i < receipts.Count; i++)
            {
                if (receipts[i].BookName != null)
                {
                    Console.WriteLine($"Receipt nr. {i+1}");
                    Console.WriteLine($"Hirer name: {receipts[i].HirerName}");
                    Console.WriteLine($"Price: {receipts[i].Price}");
                    Console.WriteLine($"Book Author: {receipts[i].BookAuthor}");
                    Console.WriteLine($"Book Name: {receipts[i].BookName}");
                    Console.WriteLine("-----------------------------------");
                }
                
            }

            if (receipts.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No records to display");
                Console.ResetColor();
            }
        }

        public static void DisplayInvoices(List<Invoice> invoices)
        {
            for (int i = 0; i < invoices.Count; i++)
            {
                if (invoices[i].BookName != null)
                {
                    Console.WriteLine($"Invoices nr. {i+1}");
                    Console.WriteLine($"Company name: {invoices[i].CompanyName}");
                    Console.WriteLine($"NIP number: {invoices[i].NipNumber}");
                    Console.WriteLine($"Hirer name: {invoices[i].HirerName}");
                    Console.WriteLine($"Price: {invoices[i].Price}");
                    Console.WriteLine($"Book Author: {invoices[i].BookAuthor}");
                    Console.WriteLine($"Book Name: {invoices[i].BookName}");
                    Console.WriteLine("-----------------------------------");
                }
            }

            if (invoices.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No records to display");
                Console.ResetColor();
            }
        }

        public static void Save(List<Book> stockBooks, List<Book> rentedBooks)
        {
            string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            currentDirectory = Path.GetDirectoryName(currentDirectory);
            currentDirectory = Path.GetDirectoryName(currentDirectory);
            string stockPath = Path.Combine(currentDirectory, @"Library_DataBase.csv");
            string rentedPath = Path.Combine(currentDirectory, @"Library_Rented.csv");
            string columns = "Name,Author,Category,Year";

            using (StreamWriter sw = new StreamWriter(rentedPath))
            {
                sw.WriteLine(columns);
                foreach (var book in rentedBooks)
                {
                    sw.WriteLine($"{book.Name},{book.Author},{book.Category},{book.Year}");
                }
            }

            using (StreamWriter sw = new StreamWriter(stockPath))
            {
                sw.WriteLine(columns);
                foreach (var book in stockBooks)
                {
                    sw.WriteLine($"{book.Name},{book.Author},{book.Category},{book.Year}");
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All changes saved");
            Console.ResetColor();
        }

        public static void PrintEnums(Type enumType)
        {
            int i = 0;

            foreach (object value in Enum.GetValues(enumType))
            {
                Console.WriteLine(i + " " + value);
                i++;
            }
        }

    }
}
