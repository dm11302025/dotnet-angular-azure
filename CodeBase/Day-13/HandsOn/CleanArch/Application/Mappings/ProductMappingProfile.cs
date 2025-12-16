using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Mappings;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        // Entity → DTO
        CreateMap<Product, ProductDto>();

        // DTO → Entity
        CreateMap<ProductDto, Product>();
        CreateMap<CreateProductDto, Product>();
    }
}
