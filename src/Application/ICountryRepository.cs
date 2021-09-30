
using Domain;
using Domain.NormalDomain;
using System;
using System.Collections.Generic;

namespace Application
{

    public interface ICountryRepository
    {
        ICollection<Country> GetAll();
        ICollection<Country> GetAllCountriesWithCities();
        ICollection<Country> GetAllCountries();
    }
}
