using Application;
using Domain.NormalDomain;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Infrastructure
{
    public class CountryRepository : ICountryRepository
    {

        private readonly ReviewNowContext _dbContext;

        public CountryRepository(ReviewNowContext dbContext)
        {

            _dbContext = dbContext;
        }
        public IQueryable<Country> GetAll()
        {

            return _dbContext.Countries;
        }
        public async void AddCountry(Country country)
        {
            await _dbContext.Countries.AddAsync(country);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Country> GetAllCountriesWithCities()
        {
            return _dbContext.Countries
                .Include(c => c.Cities);

            //eager loading
        }

        public IQueryable<Country> GetAllCountries()
        {
            return _dbContext.Countries;
        }
        public IQueryable<Country> GetAll(int page, int pageSize)
        {
            return _dbContext.Countries.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
