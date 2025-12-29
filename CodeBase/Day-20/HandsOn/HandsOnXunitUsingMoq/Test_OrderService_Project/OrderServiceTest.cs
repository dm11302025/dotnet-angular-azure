using OrderService;
using OrderService.Repositories;
using Moq;
using OrderService.Services;
namespace Test_OrderService_Project
{
    public class OrderServiceTest
    {
        [Fact]  
        public void CanPlaceOrder_ReturnsTrue_WhenStockIsAvailable()
        {
            // Arrange
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(r => r.GetStock(1)).Returns(10);

            var service = new OrderService.Services.OrderService(mockRepo.Object);

            // Act
            var result = service.CanPlaceOrder(1);

            // Assert
            Assert.True(result);
        }

    }
}