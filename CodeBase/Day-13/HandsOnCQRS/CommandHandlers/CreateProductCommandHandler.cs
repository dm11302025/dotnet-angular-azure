using HandsOnCQRS.Commands;
using HandsOnCQRS.Models;
using HandsOnCQRS.Repositories;
namespace HandsOnCQRS.CommandHandlers
{
    public class CreateProductCommandHandler
    {
        private readonly IProductRepository _repository;

        public CreateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(CreateProductCommand command)
        {
            //create product from command
            var product = new Product
            {
                Name = command.Name,
                Price = command.Price
            };

            await _repository.AddAsync(product);
        }
    }

}
