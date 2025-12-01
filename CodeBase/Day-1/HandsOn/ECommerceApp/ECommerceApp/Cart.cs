using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp
{
    // Class representing a shopping cart in the e-commerce application
    // Manages the addition of products and their quantities
    public class Cart:IShopper
    {
        // Internal list to hold products and their quantities
        // Each item is represented as a tuple of Product and quantity
        private List<(Product product, int qty)> items = new();

        public void AddToCart(Product p, int qty)
        {
            if (p.Stock < qty)
            {
                throw new OutOfStockException($"Only {p.Stock} items left.");
            }
            items.Add((p, qty));
        }

        public IEnumerable<(Product, int)> GetItems() => items;
    }

}
