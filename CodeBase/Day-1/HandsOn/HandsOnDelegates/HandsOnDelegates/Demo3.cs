using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnDelegates_Demo3
{
    #region Tightly Coupled System
    /*
     Tightly Coupled System (Bad Design)
    public class OrderService
    {
        public void PlaceOrder()
        {
            Console.WriteLine("Order placed successfully!");

            // Directly calling notification methods (tightly coupled)
            EmailService email = new EmailService();
            email.SendEmail();

            SmsService sms = new SmsService();
            sms.SendSms();
        }
    }

    public class EmailService
    {
        public void SendEmail() => Console.WriteLine("Email: Your order has been placed.");
    }

    public class SmsService
    {
        public void SendSms() => Console.WriteLine("SMS: Your order has been placed.");
    }
    Problems:

    OrderService knows about EmailService and SmsService — strong dependency.

    If you add a new method like WhatsApp notification, you must edit OrderService again.

    It violates the Open-Closed Principle (OCP) — your class isn’t open for extension but closed for modification.
     */
    #endregion
    #region Loosely Coupled Design Using Delegates
    public delegate void NotifyUser();
    public class EmailService
    {
        public void SendEmail() => Console.WriteLine("Email: Your order has been placed.");
    }

    public class SmsService
    {
        public void SendSms() => Console.WriteLine("SMS: Your order has been placed.");
    }

    public class WhatsAppService
    {
        public void SendWhatsApp() => Console.WriteLine("WhatsApp: Your order has been placed.");
    }
    public class OrderService
    {
        // Delegate variable to hold the notification method
        private readonly NotifyUser _notifyUser;

        // Constructor accepts the delegate
        public OrderService(NotifyUser notifyUser)
        {
            _notifyUser = notifyUser;
        }

        public void PlaceOrder()
        {
            Console.WriteLine("Order placed successfully!");
            _notifyUser(); // Calls whichever notification is assigned
        }
    }
    class Program
    {
        static void Main()
        {
            EmailService email = new EmailService();
            SmsService sms = new SmsService();
            WhatsAppService wa = new WhatsAppService();

            // Option 1: Notify via Email
            OrderService order1 = new OrderService(email.SendEmail);
            order1.PlaceOrder();

            // Option 2: Notify via SMS
            OrderService order2 = new OrderService(sms.SendSms);
            order2.PlaceOrder();

            // Option 3: Notify via WhatsApp
            OrderService order3 = new OrderService(wa.SendWhatsApp);
            order3.PlaceOrder();
            NotifyUser notify = email.SendEmail;
            notify += sms.SendSms;
            notify += wa.SendWhatsApp;
            OrderService order = new OrderService(notify);
            order.PlaceOrder();
        }
    }


}
#endregion
/*Before	After (Using Delegates)
OrderService depended directly on Email/SMS classes	OrderService depends only on a delegate (method reference)
Adding new notification types required changing code	You can add new types without touching OrderService
Tight coupling	Loose coupling*/