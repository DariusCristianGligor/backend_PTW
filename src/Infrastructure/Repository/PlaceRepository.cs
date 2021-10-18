using Application;
using Domain.NormalDomain;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly ReviewNowContext _dbContext;


        public PlaceRepository(ReviewNowContext dbContext)
        {

            _dbContext = dbContext;

        }
        public IQueryable<Place> GetAllByCityId(Guid city)
        {
            return _dbContext.Places.Where(x => x.CityId == city);
        }
        public IQueryable<Place> GetAllByCityId(Guid city, int page, int pageSize)
        {
            return _dbContext.Places.Where(x => x.CityId == city).Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IQueryable<Place> GetPlaceOrderedByRating()
        {
            return _dbContext.Places.OrderByDescending(x => x.Rating);
        }
        public IQueryable<Place> GetPlaceOrderedByRating(int page, int pageSize)
        {
            return _dbContext.Places.OrderByDescending(x => x.Rating).Skip((page - 1) * pageSize).Take(pageSize);
        }
        public IQueryable<Place> GetAllByCityIdAndCategoryId(Guid cityId, ICollection<Guid> categoriesId)
        {
            IQueryable<Place> places = GetAllByCityId(cityId);
            return places.OrderBy(x=>x.Name).Where(x => x.Categories.Any(x => categoriesId.Contains(x.Id)));
        }
        public IQueryable<Place> GetAllByCityIdAndCategoryId(Guid cityId, ICollection<Guid> categoriesId, int page, int pageSize)
        {
            IQueryable<Place> places = GetAllByCityId(cityId);
            return places.Where(x => x.Categories.Any(x => categoriesId.Contains(x.Id))).Skip((page - 1) * pageSize).Take(pageSize);
        }
        public IQueryable<Place> GetAllByCategoryId(ICollection<Guid> categoriesId)
        {
            return _dbContext.Places.Where(x => x.Categories.Any(x => categoriesId.Contains(x.Id)));
        }
        public IQueryable<Place> GetAllByCategoryId(ICollection<Guid> categoriesId, int page, int pageSize)
        {
            return _dbContext.Places.Where(x => x.Categories.Any(x => categoriesId.Contains(x.Id))).Skip((page - 1) * pageSize).Take(pageSize);
        }
        public IQueryable<Place> GetAllByCategoryIdAndCityId(ICollection<Guid> categoriesId, Guid cityId, int page, int pageSize)
        {
            IQueryable<Place> places = _dbContext.Places.Where(x => x.CityId== cityId);
            return places.OrderBy(x=>x.Name).Where(x => x.Categories.Any(x => categoriesId.Contains(x.Id))).Skip((page - 1) * pageSize).Take(pageSize);
        }
        public IQueryable<Place> GetAllByCategoryIdAndCountryId(ICollection<Guid> categoriesId, Guid CountryId)
        {
            IQueryable<Place> places = places = _dbContext.Places.Where(x => x.City.CountryId == CountryId);
            return places.Where(x => x.Categories.Any(x => categoriesId.Contains(x.Id)));
        }
        public int NumberOfPlaceWithIdAndCategories(ICollection<Guid> categoriesId, Guid placeId)
        {
            IQueryable<Place> places = places = _dbContext.Places.Where(x => x.CityId == placeId);
            return places.Where(x => x.Categories.Any(x => categoriesId.Contains(x.Id))).Count();
        }
        public IQueryable<Place> GetAllOrderedByRating()
        {
            return _dbContext.Places.OrderByDescending(x => x.Rating);
        }
        public IQueryable<Place> GetAllOrderedByRating(int page, int pageSize)
        {
            return _dbContext.Places.OrderByDescending(x => x.Rating).Skip((page - 1) * pageSize).Take(pageSize);
        }
        public void Delete(Guid placeId)
        {
            _dbContext.Places.RemoveRange(_dbContext.Places.Where(x => x.Id == placeId));
            _dbContext.SaveChanges();
        }

        public async Task<EntityEntry<Place>> AddAsync(Place place)
        {
            foreach (Category cat in place.Categories)
            {   
                cat.Places.Add(place);
                _dbContext.Categories.Update(cat);
            }
            EntityEntry<Place> placeFromDb = await _dbContext.Places.AddAsync(place);
            await _dbContext.SaveChangesAsync();
            return placeFromDb;
        }

        public bool Find(Guid placeId)
        {
            return (!(_dbContext.Places.Find(placeId) == null));
        }

        public Place GetPlace(Guid placeId)
        {
            return _dbContext.Places.Find(placeId);
        }
        public Place FindByPlaceId(Guid placeId)
        {
            return _dbContext.Places.Find(placeId);
        }
        public void UpdatePlace(Place place)
        {
            _dbContext.Update(place);
            _dbContext.SaveChanges();
        }

        public int GetNumberOfPlace()
        {
            
            return _dbContext.Places.Count();
        }
    }
}
