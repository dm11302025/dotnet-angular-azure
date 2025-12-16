using Application.Contracts;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDBContext _context;

    public ProductRepository(AppDBContext context)
    {
        _context = context;
    }

    public Task<List<Product>> GetAllAsync()
        => _context.Products.ToListAsync();

    public Task<Product?> GetByIdAsync(int id)
        => _context.Products.FindAsync(id).AsTask();

    public async Task AddAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await GetByIdAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
