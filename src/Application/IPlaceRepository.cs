using Domain.NormalDomain;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application
{
    public interface IPlaceRepository
    {
        IQueryable<Place> GetAllByCategoryIdAndCountryId(ICollection<Guid> categoriesId, Guid CountryId);

        IQueryable<Place> GetAllByCityIdAndCategoryId(Guid cityId, ICollection<Guid> categoriesId);

        IQueryable<Place> GetAllByCategoryId(ICollection<Guid> categoriesId);

        IQueryable<Place> GetAllByCityId(Guid city);


        IQueryable<Place> GetAllOrderedByRating(int page, int pageSize);

        IQueryable<Place> GetAllByCategoryIdAndCityId(ICollection<Guid> categoriesId, Guid cityId, int page, int pageSize);

        IQueryable<Place> GetAllByCategoryId(ICollection<Guid> categoriesId, int page, int pageSize);
        
        IQueryable<Place> GetAllByCityIdAndCategoryId(Guid cityId, ICollection<Guid> categoriesId, int page, int pageSize);
        
        IQueryable<Place> GetPlaceOrderedByRating(int page, int pageSize);
        
        IQueryable<Place> GetAllByCityId(Guid city, int page, int pageSize);
        
        void Delete(Guid placeId);
        
        Task<EntityEntry<Place>> AddAsync(Place place);
        
        public Place FindByPlaceId(Guid placeId);

        bool Find(Guid placeId);
        
        void UpdatePlace(Place place);
        int GetNumberOfPlace();
        Place GetPlace(Guid placeId);
        int NumberOfPlaceWithIdAndCategories(ICollection<Guid> categoriesId, Guid placeId);
    }
}
