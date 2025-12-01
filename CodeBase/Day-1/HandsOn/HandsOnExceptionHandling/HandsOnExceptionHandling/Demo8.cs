using HandsOnExceptionHandling.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnExceptionHandling_Demo8
{
    //Custom `
    public class OrderService
    {
        public void ReserveItem(int stock, int qty)
        {
            if (qty > stock)
                throw new InventoryException("Not enough stock available.");
        }

        public void ProcessPayment(bool cardValid)
        {
            if (!cardValid)
                throw new PaymentException("Payment failed due to invalid card.");
        }
    }
    class Program
    {
        static void Main()
        {
            var service = new OrderService();

            try
            {
                //service.ReserveItem(2, 5); // triggers InventoryException
                service.ProcessPayment(false);
            }
            catch (ECommerceException ex) // catch all custom exceptions
            {
                Console.WriteLine($"E-commerce error: {ex.Message}");
            }
            catch (Exception ex) // fallback
            {
                Console.WriteLine($"System error: {ex.Message}");
            }
        }
    }



}
