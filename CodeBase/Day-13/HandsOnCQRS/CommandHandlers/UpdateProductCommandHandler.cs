using HandsOnCQRS.Commands;
using HandsOnCQRS.Repositories;

namespace HandsOnCQRS.CommandHandlers
{
    public class UpdateProductCommandHandler
    {
        private readonly IProductRepository _repository;

        public UpdateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(UpdateProductCommand command)
        {
            var product = await _repository.FindByIdAsync(command.Id);

            if (product == null)
                throw new Exception("Product not found");

            product.Update(command.Name, command.Price); // domain behavior
            await _repository.UpdateAsync(product);
        }
    }
}