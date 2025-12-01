using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnSOLIDPrinciples.DIP
{
    //Without DIP (Violation)
    //public class EmailService
    //{
    //    public void SendEmail(string message)
    //    {
    //        Console.WriteLine($"Email sent: {message}");
    //    }
    //}

    //public class Notification
    //{
    //    private EmailService _emailService = new EmailService();

    //    public void Send(string message)
    //    {
    //        _emailService.SendEmail(message);
    //    }
    //}
    /*
     What’s wrong?

Notification (a high-level module) directly depends on EmailService (a low-level module).

If we later want to add SMS, WhatsApp, or Push notifications, we’ll have to modify Notification.

Code becomes tightly coupled → hard to extend, hard to test.
     */
    // With DIP
    // Abstraction
    public interface IMessageService
    {
        void SendMessage(string message);
    }

    // Low-level modules (implementations)
    public class EmailService : IMessageService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }
    }

    public class SMSService : IMessageService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"SMS sent: {message}");
        }
    }

    // High-level module
    public class Notification
    {
        private readonly IMessageService _messageService;

        // Constructor injection (Dependency Injection)
        public Notification(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public void Send(string message)
        {
            _messageService.SendMessage(message);
        }
    }
    class Program
    {
        static void Main()
        {
            IMessageService emailService = new EmailService();
            Notification emailNotification = new Notification(emailService);
            emailNotification.Send("Welcome via Email!");

            IMessageService smsService = new SMSService();
            Notification smsNotification = new Notification(smsService);
            smsNotification.Send("Welcome via SMS!");
        }
    }



}
