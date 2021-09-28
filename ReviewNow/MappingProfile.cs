using AutoMapper;
using Domain;
using Domain.NormalDomain;
using ReviewNow.ExportDtoClases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewNow
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<UserDto, User>();
            CreateMap<AdminDto, Admin>();
            CreateMap<CategoryDto, Category>();
            CreateMap<CityDto, City>();
            CreateMap<CountryDto, Country>();
            CreateMap<PlaceDto, Place>();
            CreateMap<ReviewDto, Review>();
            CreateMap<Admin, AdminExpDto>();
            CreateMap<Category, CategoryExpDto>();
            CreateMap<Place, PlaceExpDto>();
            CreateMap<Review, ReviewExpDto>();
            CreateMap<User, UserExpDto>();
        }
    }
}
