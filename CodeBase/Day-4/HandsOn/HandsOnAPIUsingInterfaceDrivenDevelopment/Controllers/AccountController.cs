using HandsOnAPIUsingInterfaceDrivenDevelopment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnAPIUsingInterfaceDrivenDevelopment.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly IEmailSender _email;

        public AccountController(IEmailSender email)
        {
            _email = email;
        }

        [HttpPost("register")]
        public IActionResult Register(string userEmail)
        {
            _email.SendEmail(userEmail, "Welcome", "Thank you for registering!");
            return Ok("Email Sent");
        }
    }

}
