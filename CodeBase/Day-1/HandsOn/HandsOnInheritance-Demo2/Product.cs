namespace HandsOnInheritance_Demo2
{
    // Base Product class
    public class Product
    {
        // Encapsulation: private fields
        private string name;
        private decimal price;
        private int stock;

        // Public properties for controlled access
        public string Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrEmpty(value)) name = value;
            }
        }

        public decimal Price
        {
            get { return price; }
            set
            {
                if (value > 0) price = value;
            }
        }

        public int Stock
        {
            get { return stock; }
            set
            {
                if (value >= 0) stock = value;
            }
        }

        // Parameterized constructor
        public Product(string name, decimal price, int stock)
        {
            this.name = name;
            this.price = price;
            this.stock = stock;
            Console.WriteLine($"Product created: {name}, Price: {price:C}, Stock: {stock}");
        }

        // Normal method
        public void DisplayInfo()
        {
            Console.WriteLine($"Product: {name}, Price: {price:C}, Stock: {stock}");
        }
    }

}
