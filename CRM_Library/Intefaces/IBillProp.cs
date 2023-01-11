using CRM_Library.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Library.Intefaces
{
    internal interface IBillProp
    {
        void PrintBill(ref List<Book> books, ref List<Book> rentedBooks);
    }
}
