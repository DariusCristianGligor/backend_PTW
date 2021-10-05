using Domain.NormalDomain;
using System;
using System.Linq;

namespace Application
{
    public interface ICityRepository
    {
        IQueryable<City> GetCitiesByCountryId(Guid countryId);
        IQueryable<City> GetCities();

    }
}
