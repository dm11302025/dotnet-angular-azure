using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnSOLIDPrinciples.SRP
{
    #region Violates SRP
    //public class Invoice
    //{
    //    public void CalculateTotal()
    //    {
    //        Console.WriteLine("Calculating total of invoice...");
    //    }

    //    public void PrintInvoice()
    //    {
    //        Console.WriteLine("Printing invoice...");
    //    }

    //    public void SaveToDatabase()
    //    {
    //        Console.WriteLine("Saving invoice to database...");
    //    }
    //}
    /*
     Invoice is doing three different things:

Business logic (CalculateTotal)

Presentation (PrintInvoice)

Data persistence (SaveToDatabase)

So this class has three reasons to change:

If business logic changes → modify the class

If print format changes → modify the class

If database structure changes → modify the class

➡️ Too much responsibility leads to tight coupling and maintenance headaches.
     */
    #endregion
    #region Following SRP
    // Handles calculation logic
    public class Invoice
    {
        public void CalculateTotal()
        {
            Console.WriteLine("Calculating total of invoice...");
        }
    }

    // Handles printing logic
    public class InvoicePrinter
    {
        public void Print(Invoice invoice)
        {
            Console.WriteLine("Printing invoice...");
        }
    }

    // Handles database logic
    public class InvoiceRepository
    {
        public void Save(Invoice invoice)
        {
            Console.WriteLine("Saving invoice to database...");
        }
    }
    /*
     Now:

Invoice → only calculates totals

InvoicePrinter → only prints

InvoiceRepository → only saves

Each class now has one reason to change, i.e., one responsibility.
     */
    #endregion
}
