using AutoMapper;
using ConfigarutionPorject.Entities;
using ConfigarutionPorject.Entities.DTOs.CagtegoryDtos;

namespace ConfigarutionPorject.Profiles
{
    public class BrandProfiles:Profile
    {
        public BrandProfiles()
        {
       CreateMap<Category,GetCategoryDto>();
            CreateMap<CreateCategoryDto,Category>();
            CreateMap<UpdateCategoryDto,Category>();

        }
    }
}
