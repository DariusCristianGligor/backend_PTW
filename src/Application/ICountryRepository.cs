using Domain.NormalDomain;
using System.Linq;

namespace Application
{

    public interface ICountryRepository
    {
        IQueryable<Country> GetAll();
        IQueryable<Country> GetAllCountriesWithCities();
        IQueryable<Country> GetAllCountries();
    }
}
