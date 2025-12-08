using AutoMapper;
using HandsOnAPIWithModelsAndDTOs.DTOs;
using HandsOnAPIWithModelsAndDTOs.Models;
namespace HandsOnAPIWithModelsAndDTOs
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductReadDto>(); //convert Product to ProductReaddto
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
        }
    }

}
