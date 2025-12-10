using HandsOnAPIUsingEFCodeFirst.Data;
using HandsOnAPIUsingEFCodeFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandsOnAPIUsingEFCodeFirst.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ClickCartContext _context;
        //Dependency Injection of ClickCartContext
        public ProductRepository(ClickCartContext context)
        {
            _context = context;
        }
        public async Task AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product= _context.Products.Find(productId);
            if(product!=null)
            {
                _context.Products.Remove(product);
                await SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            //var products= _context.Products.ToListAsync();
            //use stored procedure to get all products
            var products = _context.Products.FromSqlRaw("dbo.GetAll").ToListAsync();
            return await products;
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
           var product=await _context.Products.FindAsync(productId);
            return product;
        }

        public async Task<bool> SaveChangesAsync()
        {
           await _context.SaveChangesAsync();//update the database
            return await Task.FromResult(true);
        }

        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await SaveChangesAsync();

        }
    }
}
