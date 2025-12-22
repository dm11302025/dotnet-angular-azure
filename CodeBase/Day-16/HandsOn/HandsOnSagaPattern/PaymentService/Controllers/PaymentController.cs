using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Contracts;
namespace PaymentService.Controllers
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentController : ControllerBase
    {
        [HttpPost("charge")]
        public IActionResult Charge(PaymentRequest request)
        {
            // Simulate payment failure randomly
            if (request.Amount > 5000)
                return BadRequest("Payment failed");

            return Ok();
        }

        [HttpPost("refund")]
        public IActionResult Refund(PaymentRequest request)
        {
            return Ok();
        }
    }

}
