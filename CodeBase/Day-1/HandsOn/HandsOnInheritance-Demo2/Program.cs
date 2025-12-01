namespace HandsOnInheritance_Demo2
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Products ===");
            Mobile mobile = new Mobile("iPhone 15", 120000, 10, "1 Year", "iOS");
            Clothes tshirt = new Clothes("T-Shirt", 499, 50, "L");

            mobile.DisplayInfo();       // Mobile.DisplayInfo()
            ((Electronics)mobile).DisplayInfo(); // Electronics.DisplayInfo()
            ((Product)mobile).DisplayInfo();     // Product.DisplayInfo()

            tshirt.DisplayInfo();       // Product.DisplayInfo()

            Console.WriteLine("\n=== Payment ===");
            CreditCardPayment payment = new CreditCardPayment("1234-5678-9999", 150000);
            payment.Pay(mobile.Price);   // Pay for mobile
            payment.Pay(tshirt.Price);   // Pay for T-shirt
        }
    }

}
