using HandsOnCQRS.Commands;
using HandsOnCQRS.Repositories;

namespace HandsOnCQRS.CommandHandlers
{
    public class DeleteProductCommandHandler
    {
        private readonly IProductRepository _repository;

        public DeleteProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(DeleteProductCommand command)
        {
            var product = await _repository.FindByIdAsync(command.Id);

            if (product == null)
                throw new Exception("Product not found");

            await _repository.DeleteByIdAsync(command.Id);
        }
    }
}