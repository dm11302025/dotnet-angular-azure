using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnInterfaces_Demo3
{
    //E-Commerce Example — Loose Coupling with Interface
    //Define Interface (Abstraction)
    public interface IPayment
    {
        void Pay(decimal amount, string orderId);
    }
    //Implement Different Payment Methods
    public class CreditCardPayment : IPayment
    {
        public void Pay(decimal amount, string orderId)
        {
            Console.WriteLine($"Order {orderId}: Paid {amount:C} via Credit Card");
        }
    }

    public class PayPalPayment : IPayment
    {
        public void Pay(decimal amount, string orderId)
        {
            Console.WriteLine($"Order {orderId}: Paid {amount:C} via PayPal");
        }
    }
    public class UPIPayment:IPayment
    {
        public void Pay(decimal amount, string orderId)
        {
            Console.WriteLine($"Order {orderId}: Paid {amount:C} via UPI");
        }
    }
    //Checkout Class (Depends on Interface, Not Implementation)
    public class Checkout
    {
        private readonly IPayment _payment;

        // Dependency Injection of IPayment
        public Checkout(IPayment payment)
        {
            _payment = payment;
        }

        public void ProcessOrder(string orderId, decimal amount)
        {
            Console.WriteLine($"Processing order {orderId}...");
            _payment.Pay(amount, orderId);   // Uses interface, not concrete class
            Console.WriteLine("Order completed!");
        }
    }

    class Program
    {
        //Usage
        static void Main()
        {
            // Loose coupling: pass any IPayment implementation
            IPayment paymentMethod = new CreditCardPayment();
            Checkout checkout1 = new Checkout(paymentMethod);
            checkout1.ProcessOrder("ORD1001", 2000);

            // Switch payment method without changing Checkout
            paymentMethod = new PayPalPayment();
            Checkout checkout2 = new Checkout(paymentMethod);
            checkout2.ProcessOrder("ORD1002", 3500);

            paymentMethod = new UPIPayment();
            Checkout checkout3=new Checkout(paymentMethod);
            checkout3.ProcessOrder("ORD1003", 4000);
        }
    }
    /*
     What is Loose Coupling?

Tight coupling = classes are directly dependent on each other.
👉 Example: Checkout class knows exactly which payment class to use (new CreditCardPayment()).

Loose coupling = classes depend on abstractions (interfaces) instead of concrete classes.
👉 Example: Checkout depends on IPayment, not on CreditCardPayment or PayPalPayment.

💡 This makes the system flexible:

You can swap implementations without changing core business logic.

Easy for unit testing (mocking interfaces).

Follows the Dependency Inversion Principle (DIP) in SOLID.
     */
}