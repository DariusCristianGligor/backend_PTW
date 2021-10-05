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

        IQueryable<Place> GetAllOrderedByRating();

        void Delete(Guid placeId);

        Task<EntityEntry<Place>> AddAsync(Place place);
        public Place FindByPlaceId(Guid placeId);

        bool Find(Guid placeId);
        void UpdatePlace(Place place);
    }
}
