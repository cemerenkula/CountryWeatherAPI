using System;
using System.Collections.Generic;
using System.Linq;
using CountryWeatherAPI.Abstract;
using CountryWeatherAPI.DataAccess;
using CountryWeatherAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CountryWeatherAPI.Concrete
{
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
        
        public Country GetCountryById(int id)
        {
            return _context.Countries.FirstOrDefault(c => c.Id == id);
        }

        public Country GetCountryByCoordinates(int lat, int lon)
        {
            return _context.Countries
                .FirstOrDefault(c => c.LatitudeRangeStart <= lat && c.LatitudeRangeEnd >= lat &&
                                     c.LongitudeRangeStart <= lon && c.LongitudeRangeEnd >= lon);
        }

        public void AddCountry(Country country)
        {
            _context.Countries.Add(country);
            _context.SaveChanges();
        }

        public void UpdateCountry(Country country)
        {
            _context.Countries.Update(country);
            _context.SaveChanges();
        }

        public void DeleteCountry(int countryId)
        {
            var country = _context.Countries.Find(countryId);
            if (country != null)
            {
                _context.Countries.Remove(country);
                _context.SaveChanges();
            }
        }
    }
}