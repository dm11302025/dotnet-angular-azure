using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Contracts;
namespace Application.Commands
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
            var product = new Product(command.Name, command.Price);
            await _repository.AddAsync(product);
        }
    }
}
