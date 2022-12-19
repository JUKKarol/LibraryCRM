using CRM_Library.Objects;
using CRM_Library.Classes;
using CRM_Library.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;

namespace CRM_Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stockPath = @"C:\Users\Admin\source\repos\CRM_Library\CRM_Library\Library_DataBase.csv";
            List<Book> books = LoadBooks(stockPath);
            string rentedPath = @"C:\Users\Admin\source\repos\CRM_Library\CRM_Library\Library_Rented.csv";
            List<Book> rentedBooks = LoadBooks(rentedPath);

            List<Receipt> receipts = new List<Receipt>();
            List<Invoice> invoices = new List<Invoice>();

            string x;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("██╗░░░░░██╗██████╗░██████╗░░█████╗░██████╗░██╗░░░██╗  ░█████╗░██████╗░███╗░░░███╗");
                Console.WriteLine("██║░░░░░██║██╔══██╗██╔══██╗██╔══██╗██╔══██╗╚██╗░██╔╝  ██╔══██╗██╔══██╗████╗░████║");
                Console.WriteLine("██║░░░░░██║██████╦╝██████╔╝███████║██████╔╝░╚████╔╝░  ██║░░╚═╝██████╔╝██╔████╔██║");
                Console.WriteLine("██║░░░░░██║██╔══██╗██╔══██╗██╔══██║██╔══██╗░░╚██╔╝░░  ██║░░██╗██╔══██╗██║╚██╔╝██║");
                Console.WriteLine("███████╗██║██████╦╝██║░░██║██║░░██║██║░░██║░░░██║░░░  ╚█████╔╝██║░░██║██║░╚═╝░██║");
                Console.WriteLine("╚══════╝╚═╝╚═════╝░╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝░░░╚═╝░░░  ░╚════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝");
                Console.WriteLine("                     --------------------------------------");
                Console.WriteLine("                    |    (1) Rent/return a book            |");
                Console.WriteLine("                    |    (2) Modify Stock (remove/add)     |");
                Console.WriteLine("                    |    (3) Search                        |");
                Console.WriteLine("                    |    (4) Display                       |");
                Console.WriteLine("                    |    (5) Save                          |");
                Console.WriteLine("                    |    (x) Exit                          |");
                Console.WriteLine("                     -------------------------------------- ");
                x = Console.ReadLine();

                switch (x)
                {
                    case "1":
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("(1) Rent book");
                            Console.WriteLine("(2) Return book");
                            Console.WriteLine("(x) Exit");
                            x = Console.ReadLine();

                            if (x == "1")
                            {
                                Console.WriteLine("(1) Receipt");
                                Console.WriteLine("(2) Invoice");
                                Console.WriteLine("(else) Exit");
                                x = Console.ReadLine();

                                if (x == "1")
                                {
                                    Receipt receipt = new Receipt();
                                    receipt.PrintBill(ref books, ref rentedBooks);
                                    receipts.Add(receipt);
                                }
                                else if (x == "2")
                                {
                                    Invoice invoice = new Invoice();
                                    invoice.PrintBill(ref books, ref rentedBooks);
                                    invoices.Add(invoice);
                                }
                            }
                            else if (x == "2")
                            {
                                Console.WriteLine("Insert accurate book name to return: ");
                                string bookName = Console.ReadLine();
                                int index = rentedBooks.FindIndex(b => b.Name == bookName);

                                if (index >= 0)
                                {
                                    books.Add(rentedBooks[index]);
                                    rentedBooks.RemoveAt(index);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"{bookName} returned");
                                    Console.ResetColor();
                                    Console.ReadKey();

                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"there is not {bookName} in rented");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                }
                            }
                            else if (x == "x")
                            {
                                break;
                            }
                        }
                        break;

                    case "2":
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("(1) Add book");
                            Console.WriteLine("(2) Remove book");
                            Console.WriteLine("(3) Remove books");
                            Console.WriteLine("(x) Exit");
                            x = Console.ReadLine();

                            if (x == "1")
                            {
                                Operation.AddBook(ref books);
                                Console.ReadKey();

                            }
                            else if (x == "2")
                            {
                                Operation.RemoveBook(ref books);
                                Console.ReadKey();
                            }
                            else if (x == "3")
                            {
                                Operation.RemoveBooks(ref books);
                                Console.ReadKey();
                            }
                            else if (x == "x")
                            {
                                break;
                            }

                        }
                        break;

                    case "3":
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("(1) Search in stock");
                            Console.WriteLine("(2) Search in rented");
                            Console.WriteLine("(x) Exit");
                            x = Console.ReadLine();

                            if (x == "1")
                            {
                                Operation.SearchBooks(books);
                                Console.ReadKey();
                            }
                            else if (x == "2")
                            {
                                Operation.SearchBooks(rentedBooks);
                                Console.ReadKey();
                            }
                            else if (x == "x")
                            {
                                break;
                            }
                        }

                        break;

                    case "4":
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("(1) Display stock");
                            Console.WriteLine("(2) Display rented");
                            Console.WriteLine("(3) Display all");
                            Console.WriteLine("(4) Display receipts");
                            Console.WriteLine("(5) Display invoices");
                            Console.WriteLine("(x) Exit");
                            x = Console.ReadLine();

                            if (x == "1")
                            {
                                Operation.Display(books);
                                Console.ReadKey();
                            }
                            else if (x == "2")
                            {
                                Operation.Display(rentedBooks);
                                Console.ReadKey();
                            }
                            else if (x == "3")
                            {
                                List<Book> allBooks = new List<Book>(books.Union(rentedBooks));
                                Operation.Display(allBooks);
                                Console.ReadKey();
                            }
                            else if (x == "4")
                            {
                                Operation.DisplayReceipts(receipts);
                                Console.ReadKey();
                            }
                            else if (x == "5")
                            {
                                Operation.DisplayInvoices(invoices);
                                Console.ReadKey();
                            }
                            else if (x == "x")
                            {
                                break;
                            }
                        }

                        break;

                    case "5":
                        Console.Clear();
                        Operation.Save(books, rentedBooks);
                        Console.ReadKey();
                        break;

                    case "x":
                        Console.Clear();
                        Console.WriteLine("See you soon!");
                        Console.ReadKey();
                        return;

                    default:
                        Console.Clear();
                        Console.WriteLine("Incorrect input choose 1-4 number");
                        Console.ReadKey();
                        break;

                }
            }
        }

        static List<Book> LoadBooks(string csvPath)
        {
            using (var reader = new StreamReader(csvPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<BookMap>();
                var records = csv.GetRecords<Book>().ToList();
                return records;
            }

        }
    }
}
