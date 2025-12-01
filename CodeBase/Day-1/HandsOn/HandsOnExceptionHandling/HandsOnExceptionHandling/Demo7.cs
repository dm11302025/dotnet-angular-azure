using HandsOnExceptionHandling.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnExceptionHandling_Demo7
{
    public class InventoryService
    {
        public void Reserve(int productId, int requested, int available)
        {
            if (requested > available)
                throw new InsufficientInventoryException(productId,
                    $"Requested {requested}, but only {available} left.");
        }
    }

    class Program
    {
        static void Main()
        {
            var inventory = new InventoryService();
            try
            {
                inventory.Reserve(101, 5, 2);
            }
            catch (InsufficientInventoryException ex)
            {
                Console.WriteLine($"Product {ex.ProductId} failed: {ex.Message}");
            }
        }
    }

}
