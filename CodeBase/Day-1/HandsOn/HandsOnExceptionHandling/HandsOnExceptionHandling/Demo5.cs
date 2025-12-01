using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnExceptionHandling_Demo5
{
    //nested exception
    public class OrderService
    {
       
        public void SaveOrder()
        {
            try
            {
                InsertIntoDatabase();
            }
            catch (Exception ex)
            {
                // Add business context while preserving original DB error
                throw new ApplicationException("Failed to save order to database.", ex);
            }
        }

        private void InsertIntoDatabase()
        {
            // Simulate DB failure
            throw new InvalidOperationException("SQL connection timeout.");
        }
    }

    class Program
    {
        static void Main()
        {
            var service = new OrderService();

            try
            {
                service.SaveOrder();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Outer: {ex.Message}");
                Console.WriteLine($"Inner: {ex.InnerException?.Message}");
            }
        }
    }

}
