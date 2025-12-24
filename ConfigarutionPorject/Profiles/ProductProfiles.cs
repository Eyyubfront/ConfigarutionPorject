using AutoMapper;
using ConfigarutionPorject.Entities;
using ConfigarutionPorject.Entities.DTOs.ProductDtos;

namespace ConfigarutionPorject.Profiles
{
    public class ProductProfiles : Profile
    {
        public ProductProfiles()
        {
            CreateMap<Product, GetProductDto>();
            CreateMap<CreateProductDto, Category>();
            CreateMap<UpdateProductDto, Category>();
        }
    }
}