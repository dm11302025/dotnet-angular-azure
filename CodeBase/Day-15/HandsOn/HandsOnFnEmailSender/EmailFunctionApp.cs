using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Mail;  

namespace HandsOnFnEmailSender;

public class EmailFunctionApp
{
    private readonly ILogger<EmailFunctionApp> _logger;

    public EmailFunctionApp(ILogger<EmailFunctionApp> logger)
    {
        _logger = logger;
    }

    [Function("SendEmail")]
    public  async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
    {
        _logger.LogInformation("SendEmail function triggered.");
        // Read query parameters
        string toEmail = req.Query["to"];
        string subject = req.Query["subject"];
        string body = req.Query["body"];
        if (string.IsNullOrEmpty(toEmail))
        {
            return new BadRequestObjectResult("Recipient email is required.");
        }
        string gmailUser = Environment.GetEnvironmentVariable("GmailUser");
        string gmailPassword = Environment.GetEnvironmentVariable("GmailPassword");
        try
        {
            var smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(
                       gmailUser,
                       gmailPassword
                   ),
                EnableSsl = true
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress(gmailUser),
                Subject = subject ?? "Azure Function Email",
                Body = body ?? "Hello from Azure Function",
                IsBodyHtml = false
            };
            mailMessage.To.Add(toEmail);

            await smtpClient.SendMailAsync(mailMessage);

            return new OkObjectResult("Email sent successfully.");
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "Error sending email");
            return new StatusCodeResult(500);
        }
    }
}