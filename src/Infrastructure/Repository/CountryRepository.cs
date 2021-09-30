using Application;
using Domain;
using Domain.NormalDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class CountryRepository : ICountryRepository
    {
        
        private readonly ReviewNowContext _dbContext;

        public CountryRepository(ReviewNowContext dbContext)
        {

            _dbContext = dbContext;
        }
        public ICollection<Country> GetAll()
        {
           
          return _dbContext.Countries.ToList();
        }
        public async void AddCountry(Country country)
        {
           await _dbContext.Countries.AddAsync(country);
            await _dbContext.SaveChangesAsync();
        }

        public ICollection<Country> GetAllCountriesWithCities()
        {
            List<Country> countries = _dbContext.Countries
                .Include(c => c.Cities)
                .ToList();
            return countries;
            //eager loading
        }

        public ICollection<Country> GetAllCountries()
        {
            return _dbContext.Countries.ToList();
        }
        public ICollection<Country> GetAll(int page, int pageSize)
        {
            return _dbContext.Countries.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
