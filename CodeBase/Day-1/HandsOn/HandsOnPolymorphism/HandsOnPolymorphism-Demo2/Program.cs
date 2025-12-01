namespace HandsOnPolymorphism_Demo2
{
 
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Products ===");
            Mobile mobile = new Mobile("iPhone 15", 120000, 10, "1 Year", "iOS");
            Clothes tshirt = new Clothes("T-Shirt", 499, 50, "L");

            mobile.DisplayInfo();
            ((Electronics)mobile).DisplayInfo();
            ((Product)mobile).DisplayInfo();
            tshirt.DisplayInfo();

            Console.WriteLine("\n=== Cart (Method Overloading) ===");
            Cart cart = new Cart();
            cart.AddProduct(mobile);                     // single
            cart.AddProduct(tshirt, 2);                  // quantity
            cart.AddProduct(new Product[] { mobile, tshirt }); // array
            cart.ShowCart();

            Console.WriteLine("\n=== Payment (Method Overriding / Polymorphism) ===");
            Payment payment1 = new CreditCardPayment("1234-5678-9999", 150000);
            Payment payment2 = new UpiPayment("adrija@upi", 5000);

            decimal total = cart.TotalAmount();
            payment1.Pay(total);   // pays total via credit card
            payment2.Pay(3000);    // pays partial via UPI
        }
    }

}
