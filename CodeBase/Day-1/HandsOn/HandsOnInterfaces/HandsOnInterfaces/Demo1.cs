using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandsOnInterfaces;
namespace HandsOnInterfaces_Demo1
{
    //Define Repository Interface (IProductRepository)
    public interface IProductRepository
    {
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
        Product GetById(int id);
        IEnumerable<Product> GetAll();
    }
    //Implement Repository (Concrete Class)
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>();

        public void Add(Product product)
        {
            _products.Add(product);
            Console.WriteLine($"Product '{product.Name}' added.");
        }

        public void Update(Product product)
        {
            var existing = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Price = product.Price;
                Console.WriteLine($"Product '{product.Name}' updated.");
            }
        }

        public void Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
                Console.WriteLine($"Product '{product.Name}' deleted.");
            }
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }
    }
    //Usage (Business Layer Depends on Interface, Not Implementation)
    class Program
    {
        static void Main()
        {
            // Loose Coupling: depend on interface, not concrete class
           IProductRepository productRepo = new ProductRepository();
           // ProductRepository productRepository = new ProductRepository();

            Product p1 = new Product { Id = 1, Name = "Laptop", Price = 1200 };
            Product p2 = new Product { Id = 2, Name = "Headphones", Price = 150 };

            productRepo.Add(p1);
            productRepo.Add(p2);

            Console.WriteLine("\nAll Products:");
            foreach (var p in productRepo.GetAll())
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Price: {p.Price:C}");
            }

            // Update
            p2.Price = 140;
            productRepo.Update(p2);

            // Delete
            productRepo.Delete(1);

            Console.WriteLine("\nAfter Update/Delete:");
            foreach (var p in productRepo.GetAll())
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Price: {p.Price:C}");
            }
        }
    }


}
