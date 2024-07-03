using CountryWeatherAPI.Models;

namespace CountryWeatherAPI.Abstract;

public interface ICountryRepository
{
    List<Country> GetAllCountries();

    Country GetCountryByCoordinates(int lat, int lon);
    
    
}