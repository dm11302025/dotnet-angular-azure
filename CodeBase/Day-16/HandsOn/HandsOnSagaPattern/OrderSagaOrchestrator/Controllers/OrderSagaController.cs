using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Contracts;
namespace OrderSagaOrchestrator.Controllers
{
    [ApiController]
    [Route("api/saga")]
    public class OrderSagaController : ControllerBase
    {
        private readonly HttpClient _http;

        public OrderSagaController(HttpClient http)
        {
            _http = http;
        }

        [HttpPost("place-order")]
        public async Task<IActionResult> PlaceOrder(CreateOrderRequest request)
        {
            // STEP 1: Create Order
            var orderResponse = await _http.PostAsJsonAsync(
                "http://localhost:5290/api/orders", new { });

            var order = await orderResponse.Content.ReadFromJsonAsync<OrderResponse>();

            try
            {
                // STEP 2: Payment
                var paymentResponse = await _http.PostAsJsonAsync(
                    "http://localhost:5088/api/payments/charge",
                    new PaymentRequest(order!.OrderId, request.Amount));

                paymentResponse.EnsureSuccessStatusCode();

                // STEP 3: Inventory
                var inventoryResponse = await _http.PostAsJsonAsync(
                    "http://localhost:5053/api/inventory/reserve",
                    new InventoryRequest(order.OrderId, request.ProductId, request.Quantity));

                inventoryResponse.EnsureSuccessStatusCode();

                // STEP 4: Complete Order
                await _http.PostAsync(
                    $"http://localhost:5290/api/orders/{order.OrderId}/complete", null);

                return Ok("Order completed successfully");
            }
            catch
            {
                // Compensation logic
                await _http.PostAsJsonAsync(
                    "http://localhost:5088/api/payments/refund",
                    new PaymentRequest(order!.OrderId, request.Amount));

                await _http.PostAsync(
                    $"http://localhost:5290/api/orders/{order.OrderId}/cancel", null);

                return BadRequest("Order failed. Compensation executed.");
            }
        }
    }

}
