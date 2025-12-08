namespace CleanArch.Application.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CleanArch.Application.DTOs;


    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByIdAsync(int id);
        Task<ProductDto> CreateAsync(CreateProductDto dto);
        Task UpdatePriceAsync(int id, decimal newPrice);
        Task DeleteAsync(int id);
    }
}
