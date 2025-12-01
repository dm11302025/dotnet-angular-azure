using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnInterfaces_Demo5
{
    public interface IPayment
    {
        void Pay(decimal amount, string orderId);
    }

    public interface IShipping
    {
        void Ship(string orderId, string address);
    }

    public interface IInvoice
    {
        void Print();
    }

    public interface IReport
    {
        void Print();
    }
    public class Order : IPayment, IShipping, IInvoice, IReport
    {
        private readonly string _orderId;
        private readonly decimal _amount;
        private readonly string _address;

        public Order(string orderId, decimal amount, string address)
        {
            _orderId = orderId;
            _amount = amount;
            _address = address;
        }

        // Implementing IPayment
        public void Pay(decimal amount, string orderId)
        {
            Console.WriteLine($"Order {orderId}: Paid {amount:C} successfully.");
        }

        // Implementing IShipping
        public void Ship(string orderId, string address)
        {
            Console.WriteLine($"Order {orderId}: Shipped to {address}.");
        }

        // Explicit Implementation for IInvoice.Print
        void IInvoice.Print()
        {
            Console.WriteLine($"Invoice -> Order: {_orderId}, Amount: {_amount:C}, Address: {_address}");
        }

        // Explicit Implementation for IReport.Print
        void IReport.Print()
        {
            Console.WriteLine($"Report -> Order: {_orderId}, Revenue: {_amount:C}, ShippedTo: {_address}");
        }
    }
    class Program
    {
        static void Main()
        {
            // Create an Order
            Order order = new Order("ORD3001", 4500, "Bangalore, India");

            // Payment
            order.Pay(4500, "ORD3001");

            // Shipping
            order.Ship("ORD3001", "Bangalore, India");

            // Customer Invoice (IInvoice.Print)
            IInvoice invoice = order;
            invoice.Print();

            // Admin Report (IReport.Print)
            IReport report = order;
            report.Print();
        }
        //This shows Loose Coupling, Multiple Inheritance via Interfaces,
        //and Method Conflict Resolution all in one example.
    }


}
