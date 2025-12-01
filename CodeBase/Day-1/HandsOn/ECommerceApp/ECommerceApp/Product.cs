using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp
{
    public class Product
    {
        //automatic properties
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get;  set; }

        public Product(int id, string name, double price, int stock)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
        }

        public void ReduceStock(int qty)
        {
            Stock -= qty;
        }
    }

}
