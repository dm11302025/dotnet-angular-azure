using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp
{
    // Class representing the payment service in the e-commerce application
    // Handles payment processing for orders
    internal class PaymentService
    {
        // Method to process payment asynchronously
        public async Task<bool> ProcessPaymentAsync(double amount)
        {
            Console.WriteLine("Processing payment...");
            await Task.Delay(2000);
            return true;
        }
    }
}
