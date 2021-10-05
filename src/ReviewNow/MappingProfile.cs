using AutoMapper;
using Domain;
using Domain.NormalDomain;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ReviewNow.ExportDtoClases;
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
            CreateMap<EntityEntry<Admin>, AdminExportDto>();
            CreateMap<EntityEntry<Category>, CategoryExportDto>();
            CreateMap<EntityEntry<Place>, PlaceExportDto>();
            CreateMap<EntityEntry<Review>, ReviewExportDto>();
            CreateMap<EntityEntry<User>, UserExportDto>();
        }
    }
}
