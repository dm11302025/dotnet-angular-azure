using HandsOnInterfaces_Demo1;

namespace HandsOnInterfaces
{
    //Practical Example 1 – Payment System (Domain: E-Commerce)
    //we are building an E-Commerce Application where a customer
    //can pay using CreditCard, PayPal, or UPI.
    public interface IPayment
    {
        void Pay(decimal amount); //abstract method
    }
    //implementations
    public class CreditCardPayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount:C} using Credit Card");
        }
    }

    public class PayPalPayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount:C} using PayPal");
        }
    }

    public class UpiPayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount:C} using UPI");
        }
    }

    internal class Program
    {
        private readonly IProductRepository productRepository;
        public Program(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        static void Main(string[] args)
        {
            //Usage
            IPayment payment;

            // Customer chooses PayPal
            payment = new PayPalPayment();
            payment.Pay(500);

            // Customer chooses Credit Card
            payment = new CreditCardPayment();
            payment.Pay(1200);
            /*
             Benefit: You can add a new CryptoPayment class without 
            changing existing code → Open/Closed Principle (OOP SOLID).
             */
        }
    }
}
