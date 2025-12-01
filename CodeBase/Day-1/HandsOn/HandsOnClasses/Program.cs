namespace HandsOnClasses
{
    class Product
    { /* private(default),public,protected,internal */
        /*
         1. variables
         2. methods
         3. constructors/destrutors
         4. properties
         5. indexers
         6. events
         */
        public int productId;
        public string productName;
        public double price;
        public int quantity;
        //constructor defination
       
        public Product() //default constructor
        {
            //initialize class data
            productId = 3093;
            productName = "Pen";
            price = 20;
            quantity = 100;
        }
        //Parameterized constructor
        public Product(int productId, string productName, double price, int quantity)
        {
            this.productId = productId;
            this.productName = productName;
            this.price = price;
            this.quantity = quantity;
        }

        //method
        public void Details()
        {
            Console.WriteLine($"Id:{productId} Name:{productName} Price:{price} Stock:{quantity}");
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
           //Instanticate product object
           Product product= new Product();
            //defind product data
            product.productId = 304298;
            product.productName = "Mouse";
            product.price = 900;
            product.quantity = 10;
            product.Details();
            Product p = new Product() 
            { productId = 322, productName = "ABC", price = 120, quantity = 100 };
            Product p1 = new Product(30834, "Keyboard", 500, 10);
            Product p2 = new Product(40443, "Mouse", 400, 12);
            p1.Details();
            //create array of products
            Product[] products = new Product[4];
            //assing objects to array
            products[0] = product;
            products[1]=p1;
            products[2]=p2;
            products[3] = new Product(40433,"Pencil",10,100);
            foreach(var item in products)
            {
                item.Details();
            }
        }
    }
}
