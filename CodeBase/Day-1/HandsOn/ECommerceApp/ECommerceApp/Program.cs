using System.Linq;
namespace ECommerceApp
{
    internal class Program
    {
        public delegate double DiscountDelegate(double amount);

        static async Task Main(string[] args)
        {
            Console.WriteLine("=== ECOMMERCE END-TO-END DEMO ===");
            // Products
            var products = new List<Product>()
        {
            new Product(1, "Laptop", 70000, 10),
            new Product(2, "Mouse", 599, 50),
            new Product(3, "Keyboard", 999, 30),
        };
            var customer = new Customer { UserId = 1, Name = "Ravi" };
            customer.DisplayRole();
            // Cart
            var cart = new Cart();

            try
            {
                cart.AddToCart(products[0], 1);
                cart.AddToCart(products[1], 2);
                // LINQ - Get total amount
                var total = cart.GetItems()
                 .Sum(i => i.Item1.Price * i.Item2);
                Console.WriteLine($"Total before discount: {total}");
                // Delegate-based Discount
                DiscountDelegate discount = amt => amt > 500 ? amt * 0.10 : 0;
                double discountAmount = discount(total);
                Console.WriteLine($"Discount: {discountAmount}");
                double finalAmount = total - discountAmount;
                Console.WriteLine($"Final Amount: {finalAmount}");
                // Order service
                var orderService = new OrderService();

                orderService.OrderPlaced += (s, e) =>
                {
                    Console.WriteLine("Notification: Order successfully placed!");
                };

                orderService.PlaceOrder();
                // Payment
                var paymentService = new PaymentService();
                await paymentService.ProcessPaymentAsync(finalAmount);

                Console.WriteLine("Payment Successful! Thank you.");

            }
            catch (OutOfStockException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Thank you for shopping!");
            }
        }

    }
}
