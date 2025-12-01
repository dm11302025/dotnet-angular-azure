namespace HandsOnPolymorphism_Demo2
{
    using System;

    // Base Product class
    public class Product
    {
        private string name;
        private decimal price;
        private int stock;

        public string Name
        {
            get { return name; }
            set { if (!string.IsNullOrEmpty(value)) name = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { if (value > 0) price = value; }
        }

        public int Stock
        {
            get { return stock; }
            set { if (value >= 0) stock = value; }
        }

        public Product(string name, decimal price, int stock)
        {
            this.name = name;
            this.price = price;
            this.stock = stock;
            Console.WriteLine($"Product created: {name}, Price: {price:C}, Stock: {stock}");
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Product: {name}, Price: {price:C}, Stock: {stock}");
        }
    }

}
