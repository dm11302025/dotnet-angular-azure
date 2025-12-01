using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp
{
    // Class representing the order service in the e-commerce application
    // Manages order placement and notifies subscribers when an order is placed
    public class OrderService
    {
        public event EventHandler? OrderPlaced; // Event triggered when an order is placed

        public void PlaceOrder()
        {
            Console.WriteLine("Placing order...");
            OrderPlaced?.Invoke(this, EventArgs.Empty);// Notify subscribers that the order has been placed
        }
    }
}
