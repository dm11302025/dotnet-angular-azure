using CosmosCrudApi.Contracts;
using CosmosCrudApi.Models;
using Microsoft.Azure.Cosmos;
using System.Text.Json;
namespace CosmosCrudApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Container _container;

        public ProductRepository(CosmosClient client, IConfiguration config)
        {
            _container = client.GetContainer(
                config["CosmosDb:DatabaseName"],
                config["CosmosDb:ContainerName"]);
        }

        // CREATE
        public async Task CreateAsync(Product product)
        {
            var json = JsonSerializer.Serialize(product);
            Console.WriteLine("JSON SENT TO COSMOS:");
            Console.WriteLine(json);

            await _container.CreateItemAsync(
                product,
                new PartitionKey(product.Category));
        }

        // READ ALL
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var query = _container.GetItemQueryIterator<Product>(
                "SELECT * FROM c");

            var results = new List<Product>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response);
            }
            return results;
        }

        // READ BY ID
        public async Task<Product> GetByIdAsync(string id, string category)
        {
            var response = await _container.ReadItemAsync<Product>(
                id,
                new PartitionKey(category));

            return response.Resource;
        }

        // UPDATE
        public async Task UpdateAsync(Product product)
        {
            await _container.UpsertItemAsync(product,
                new PartitionKey(product.Category));
        }

        // DELETE
        public async Task DeleteAsync(string id, string category)
        {
            await _container.DeleteItemAsync<Product>(
                id,
                new PartitionKey(category));
        }
    }

}
