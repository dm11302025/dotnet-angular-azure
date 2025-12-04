using AutoMapper;
using HandsOnAPIWithModelsAndDTOs.DTOs;
using HandsOnAPIWithModelsAndDTOs.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace HandsOnAPIWithModelsAndDTOs
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
        }
    }

}
