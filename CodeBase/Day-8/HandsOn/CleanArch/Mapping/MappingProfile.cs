namespace CleanArch.Mapping
{
    using AutoMapper;
    using CleanArch.Application.DTOs;
    using CleanArch.Domain.Entities;


    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<CreateProductDto, Product>();
        }
    }
}
