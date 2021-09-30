using Application;
using Domain.NormalDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
     public class PlaceRepository:IPlaceRepository
    {
        private readonly ReviewNowContext _dbContext;


        public PlaceRepository(ReviewNowContext dbContext)
        {

            _dbContext = dbContext;
            
        }
        public ICollection<Place> GetAllByCityId(Guid city)
        {
            return _dbContext.Places.Where(x => x.CityId == city).ToList();
        }
        public ICollection<Place> GetAllByCityId(Guid city,int page, int pageSize)
        {
            return _dbContext.Places.Where(x => x.CityId == city).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public ICollection<Place> GetPlaceOrderedByRating()
        {
            return _dbContext.Places.OrderByDescending(x => x.Rating).ToList();
        }
        public ICollection<Place> GetPlaceOrderedByRating(int page,int pageSize)
        {
            return _dbContext.Places.OrderByDescending(x => x.Rating).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public ICollection<Place> GetAllByCityIdAndCategoryId(Guid cityId, ICollection<Guid> categoriesId)
        {
            ICollection<Place> places = GetAllByCityId(cityId);
            return places.Where(x => x.Categories.Any(x => categoriesId.Contains(x.Id))).ToList();
        }
        public ICollection<Place> GetAllByCityIdAndCategoryId(Guid cityId, ICollection<Guid> categoriesId, int page, int pageSize)
        {
            ICollection<Place> places = GetAllByCityId(cityId);
            return places.Where(x => x.Categories.Any(x => categoriesId.Contains(x.Id))).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public ICollection<Place> GetAllByCategoryId( ICollection<Guid> categoriesId)
        {
            return _dbContext.Places.Where(x => x.Categories.Any(x => categoriesId.Contains(x.Id))).ToList();
        }
        public ICollection<Place> GetAllByCategoryId(ICollection<Guid> categoriesId, int page, int pageSize)
        {
            return _dbContext.Places.Where(x => x.Categories.Any(x => categoriesId.Contains(x.Id))).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public ICollection<Place> GetAllByCategoryIdAndCountryId(ICollection<Guid> categoriesId,Guid CountryId, int page, int pageSize)
        {
            ICollection<Place> places = new List<Place>();
            places = _dbContext.Places.Where(x => x.City.CountryId == CountryId).ToList();
            return places.Where(x => x.Categories.Any(x => categoriesId.Contains(x.Id))).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public ICollection<Place> GetAllByCategoryIdAndCountryId(ICollection<Guid> categoriesId, Guid CountryId)
        {
            ICollection<Place> places = new List<Place>();
            places = _dbContext.Places.Where(x => x.City.CountryId == CountryId).ToList();
            return places.Where(x => x.Categories.Any(x => categoriesId.Contains(x.Id))).ToList();
        }
        public ICollection<Place> GetAllOrderedByRating()
        {
            return _dbContext.Places.OrderByDescending(x=>x.Rating).ToList();
        }
        public ICollection<Place> GetAllOrderedByRating(int page,int pageSize)
        {
            return _dbContext.Places.OrderByDescending(x => x.Rating).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public void Add(Place place)
        {
            _dbContext.Places.Add(place);
        }

        public void Delete(Guid placeId)
        {
            _dbContext.Places.RemoveRange(_dbContext.Places.Where(x => x.Id == placeId));
             _dbContext.SaveChanges();
        }

        public async Task<Place> AddAsync(Place place)
        {
            await _dbContext.Places.AddAsync(place);
            await _dbContext.SaveChangesAsync();
            return place;
        }

        public bool Find(Guid placeId)
        {
            List<Place> list = _dbContext.Places.Where(x => x.Id == placeId).ToList();
            return (!(list.Count == 0));
        }
    }
}
