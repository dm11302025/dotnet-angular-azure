using Moq;
using Xunit;
using ProductApi.Models;
using ProductApi.Repositories;
using ProductApi.Services;
namespace XunitTestProject
{
    public class ProductServiceTests
    {
        [Fact]
        public async Task IsAvailableAsync_ReturnsTrue_WhenStockGreaterThanZero()
        {
            // Arrange
            var mockRepo = new Mock<IProductRepository>();

            mockRepo.Setup(r => r.GetByIdAsync(1))
                    .ReturnsAsync(new Product
                    {
                        Id = 1,
                        Name = "Laptop",
                        Price = 999.99M
                    });

            var service = new ProductService(mockRepo.Object);

            // Act
            var result = await service.IsAvailableAsync(1);

            // Assert
            Assert.True(result);
        }
        [Fact]
        public async Task CreateAsync_ReturnsProduct_WhenValidInput()
        {
            // Arrange
            var mockRepo = new Mock<IProductRepository>();

            var product = new Product { Id = 1, Name = "Laptop", Price = 50000 };

            mockRepo.Setup(r => r.AddAsync(product))
                    .ReturnsAsync(product);

            var service = new ProductService(mockRepo.Object);

            // Act
            var result = await service.CreateAsync(product);

            // Assert
            Assert.Equal("Laptop", result.Name);
        }
        [Fact]
        public async Task CreateAsync_ThrowsException_WhenPriceInvalid()
        {
            var mockRepo = new Mock<IProductRepository>();
            var service = new ProductService(mockRepo.Object);

            await Assert.ThrowsAsync<ArgumentException>(() =>
                service.CreateAsync(new Product { Price = 0 }));
        }
        [Fact]
        public async Task GetByIdAsync_ReturnsProduct_WhenExists()
        {
            var mockRepo = new Mock<IProductRepository>();

            mockRepo.Setup(r => r.GetByIdAsync(1))
                    .ReturnsAsync(new Product { Id = 1, Name = "Mouse", Price = 500 });

            var service = new ProductService(mockRepo.Object);

            var result = await service.GetByIdAsync(1);

            Assert.Equal("Mouse", result.Name);
        }
        [Fact]
        public async Task GetByIdAsync_ThrowsException_WhenNotFound()
        {
            var mockRepo = new Mock<IProductRepository>();

            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                    .ReturnsAsync((Product?)null);

            var service = new ProductService(mockRepo.Object);

            await Assert.ThrowsAsync<KeyNotFoundException>(() =>
                service.GetByIdAsync(99));
        }
        [Fact]
        public async Task GetAllAsync_ReturnsAllProducts()
        {
            var mockRepo = new Mock<IProductRepository>();

            mockRepo.Setup(r => r.GetAllAsync())
                    .ReturnsAsync(new List<Product>
                    {
                new Product { Id = 1, Name = "Keyboard", Price = 1000 },
                new Product { Id = 2, Name = "Monitor", Price = 15000 }
                    });

            var service = new ProductService(mockRepo.Object);

            var result = await service.GetAllAsync();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task UpdateAsync_CallsUpdate_WhenProductExists()
        {
            var mockRepo = new Mock<IProductRepository>();

            var product = new Product { Id = 1, Name = "Updated", Price = 2000 };

            mockRepo.Setup(r => r.GetByIdAsync(1))
                    .ReturnsAsync(product);

            var service = new ProductService(mockRepo.Object);

            await service.UpdateAsync(product);

            mockRepo.Verify(r => r.UpdateAsync(product), Times.Once);
        }
        [Fact]
        public async Task UpdateAsync_ThrowsException_WhenProductNotFound()
        {
            var mockRepo = new Mock<IProductRepository>();

            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                    .ReturnsAsync((Product?)null);

            var service = new ProductService(mockRepo.Object);

            await Assert.ThrowsAsync<KeyNotFoundException>(() =>
                service.UpdateAsync(new Product { Id = 10 }));
        }
        [Fact]
        public async Task DeleteAsync_CallsDelete_WhenProductExists()
        {
            var mockRepo = new Mock<IProductRepository>();

            mockRepo.Setup(r => r.GetByIdAsync(1))
                    .ReturnsAsync(new Product { Id = 1 });

            var service = new ProductService(mockRepo.Object);

            await service.DeleteAsync(1);

            mockRepo.Verify(r => r.DeleteAsync(1), Times.Once);
        }
        [Fact]
        public async Task DeleteAsync_ThrowsException_WhenProductNotFound()
        {
            var mockRepo = new Mock<IProductRepository>();

            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                    .ReturnsAsync((Product?)null);

            var service = new ProductService(mockRepo.Object);

            await Assert.ThrowsAsync<KeyNotFoundException>(() =>
                service.DeleteAsync(5));
        }
    }

}