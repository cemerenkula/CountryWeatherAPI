using System.Collections.Generic;
using System.Linq;
using CountryWeatherAPI.Abstract;
using CountryWeatherAPI.DataAccess;
using CountryWeatherAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CountryWeatherAPI.Concrete
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly CountryWeatherDbContext _context;

        public WeatherRepository(CountryWeatherDbContext context)
        {
            _context = context;
        }

        public List<Weather> GetAllWeatherData()
        {
            return _context.Weathers.ToList();
        }

        public Weather GetWeatherByCountryId(int countryId)
        {
            return _context.Weathers.FirstOrDefault(w => w.CountryId == countryId);
        }

        public Weather GetWeatherByCoordinates(int lat, int lon)
        {
            return _context.Weathers.FirstOrDefault(w => w.Latitude == lat && w.Longitude == lon);
        }

        public void AddWeatherData(Weather weather)
        {
            _context.Weathers.Add(weather);
            _context.SaveChanges();
        }

        public void UpdateWeatherData(Weather weather)
        {
            _context.Weathers.Update(weather);
            _context.SaveChanges();
        }

        public void DeleteWeatherData(int weatherId)
        {
            var weather = _context.Weathers.Find(weatherId);
            if (weather != null)
            {
                _context.Weathers.Remove(weather);
                _context.SaveChanges();
            }
        }
    }
}