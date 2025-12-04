namespace HandsOnAPIUsingInterfaceDrivenDevelopment.Models
{
    public class SmtpEmailSender : IEmailSender
    {
        public void SendEmail(string to, string subject, string body)
        {
            // SMTP code here
        }
    }

}
