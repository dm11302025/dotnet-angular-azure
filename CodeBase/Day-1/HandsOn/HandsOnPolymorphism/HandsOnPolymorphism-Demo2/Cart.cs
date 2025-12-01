namespace HandsOnPolymorphism_Demo2
{
    using System;
    using System.Collections.Generic;
    #region Polymorphism: Cart (Method Overloading)
    public class Cart
    {
        private List<Product> products = new List<Product>();

        // Add single product
        public void AddProduct(Product product)
        {
            products.Add(product);
            Console.WriteLine($"Added 1 product: {product.Name}");
        }

        // Add multiple products
        public void AddProduct(Product product, int quantity)
        {
            for (int i = 0; i < quantity; i++)
                products.Add(product);
            Console.WriteLine($"Added {quantity} of {product.Name}");
        }

        // Add multiple products using array
        public void AddProduct(Product[] productArray)
        {
            products.AddRange(productArray);
            Console.WriteLine($"Added multiple products: {string.Join(", ", Array.ConvertAll(productArray, p => p.Name))}");
        }

        public void ShowCart()
        {
            Console.WriteLine("Cart Contents: " + string.Join(", ", products.ConvertAll(p => p.Name)));
        }

        public decimal TotalAmount()
        {
            decimal total = 0;
            foreach (var p in products)
                total += p.Price;
            return total;
        }
    }

}
