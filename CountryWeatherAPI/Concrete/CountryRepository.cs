using CountryWeatherAPI.Abstract;
using CountryWeatherAPI.Models;
using CountryWeatherAPI.DataAccess;

namespace CountryWeatherAPI.Concrete;

public class CountryRepository : ICountryRepository
{
    
    private readonly CountryWeatherDbContext _context;
 
    public CountryRepository(CountryWeatherDbContext context)
    {
        _context = context;
    }
    
    public List<Country> GetAllCountries()
    {
        return _context.Countries.ToList();
    }

    public Country GetCountryByCoordinates(int lat, int lon)
    {
        throw new NotImplementedException();
    }
}