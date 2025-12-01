using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnInterfaces_Demo2
{
    public interface IPayment
    {
        void Pay(decimal amount, string orderId);
    }

    public interface IShipping
    {
        void Ship(string orderId, string address);
    }
    //A Class Implementing Both Interfaces (Multiple Inheritance)
    //OnlineOrder class inherits behavior from two interfaces → IPayment and IShipping.
    public class OnlineOrder : IPayment, IShipping
    {
        public void Pay(decimal amount, string orderId)
        {
            Console.WriteLine($"Order {orderId}: Paid {amount:C} successfully.");
        }

        public void Ship(string orderId, string address)
        {
            Console.WriteLine($"Order {orderId}: Shipped to {address}.");
        }
    }
    class Program
    {
        static void Main()
        {
            OnlineOrder order = new OnlineOrder();

            // Multiple inheritance in action
            order.Pay(2500, "ORD2001");
            order.Ship("ORD2001", "Hyderabad, India");
        }
    }
    /*
     Real-World Analogy

    Think of an Amazon Order:

    It must process payment.

    It must also arrange delivery.

    These are two different responsibilities, but a single Order class can 
    implement both contracts using interfaces.
     */
}
