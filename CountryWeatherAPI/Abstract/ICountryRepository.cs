using System.Collections.Generic;
using CountryWeatherAPI.Models;

namespace CountryWeatherAPI.Abstract
{
    public interface ICountryRepository
    {
        // Retrieves all countries from the database
        List<Country> GetAllCountries();

        // Retrieves a country based on latitude and longitude coordinates
        Country GetCountryByCoordinates(int lat, int lon);

        // Adds a new country to the database
        void AddCountry(Country country);

        // Updates an existing country in the database
        void UpdateCountry(Country country);

        // Deletes a country from the database
        void DeleteCountry(int countryId);

        Country GetCountryById(int id);
    }
}