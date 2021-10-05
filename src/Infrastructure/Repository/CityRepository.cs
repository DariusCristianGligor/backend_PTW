using Application;
using Domain.NormalDomain;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;


namespace Infrastructure
{
    public class CityRepository : ICityRepository
    {

        private readonly ReviewNowContext _dbContext;

        public CityRepository(ReviewNowContext dbContext)
        {

            _dbContext = dbContext;
        }
        public IQueryable<City> GetCitiesByCountryId(Guid countryId)
        {
            return _dbContext.Cities.Where(x => x.CountryId == countryId);
        }
        public IQueryable<City> GetCities()
        {
            return _dbContext.Cities;
        }
        public async void AddCity(City city)
        {
            EntityEntry<City> cityFromDb = await _dbContext.Cities.AddAsync(city);
            await _dbContext.SaveChangesAsync();

        }
    }
}
