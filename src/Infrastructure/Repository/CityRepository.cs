using Application;
using Domain;
using Domain.NormalDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class CityRepository : ICityRepository
    {
    
        private readonly ReviewNowContext _dbContext;

        public CityRepository(ReviewNowContext dbContext)
        {

            _dbContext = dbContext;
        }
        public ICollection<City> GetCitiesByCountryId(Guid countryId)
        {
            return _dbContext.Cities.Where(x => x.CountryId==countryId).ToList();
        }
        public ICollection<City> GetCities()
        {

            return _dbContext.Cities.ToList();
        }
        public async void AddCity(City city)
        {
            await _dbContext.Cities.AddAsync(city);
            await _dbContext.SaveChangesAsync();
        }
    }
}
