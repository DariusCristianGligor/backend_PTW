using Domain;
using Domain.NormalDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IPlaceRepository
    { 
        ICollection<Place> GetAllByCategoryIdAndCountryId(ICollection<Guid> categoriesId, Guid CountryId);

        ICollection<Place> GetAllByCityIdAndCategoryId(Guid cityId, ICollection<Guid> categoriesId);

        ICollection<Place> GetAllByCategoryId(ICollection<Guid> categoriesId);

        ICollection<Place> GetAllByCityId(Guid city);

        ICollection<Place> GetAllOrderedByRating();

        void Delete(Guid placeId);

        Task<Place> AddAsync(Place place);

        bool Find(Guid placeId);
    }
}
