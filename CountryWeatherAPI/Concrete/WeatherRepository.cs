using System.Collections.Generic;
using System.Linq;
using System.Net;
using CountryWeatherAPI.Abstract;
using CountryWeatherAPI.DataAccess;
using CountryWeatherAPI.Models;
using CountryWeatherAPI.Models.DTOs.Request;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CountryWeatherAPI.Concrete
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly CountryWeatherDbContext _context;
        private readonly string _apiKey;

        public WeatherRepository(CountryWeatherDbContext context, IConfiguration configuration)
        {
            _context = context;
            _apiKey = configuration["OpenWeatherMap:ApiKey"];
        }

        public void UpdateWeatherWithRequest(double latitude, double longitude)
        {
            using (WebClient web = new WebClient())
            {
                string url = $"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid={_apiKey}&units=metric";
                var json = web.DownloadString(url);
                WeatherInfo.root Info = JsonConvert.DeserializeObject<WeatherInfo.root>(json);

                Country country = _context.Countries
                    .FirstOrDefault(c => c.LatitudeRangeStart <= latitude && c.LatitudeRangeEnd >= latitude &&
                                         c.LongitudeRangeStart <= longitude && c.LongitudeRangeEnd >= longitude);

                if (country == null)
                {
                    throw new InvalidOperationException($"No country found for coordinates: ({latitude}, {longitude})");
                }

                Weather weather = new Weather
                {
                    CountryId = country.Id,
                    CountryName = country.Name,
                    Latitude = (int)Info.coord.lat,
                    Longitude = (int)Info.coord.lon,
                    WeatherMain = Info.weather[0].main,
                    WeatherDescription = Info.weather[0].description,
                    Temperature = Info.main.temp,
                    FeelsLike = Info.main.feels_like,
                    Pressure = Info.main.pressure,
                    Humidity = Info.main.humidity,
                    WindSpeed = Info.wind.speed,
                    WindDeg = Info.wind.deg,
                    WindGust = Info.wind.gust,
                    Timestamp = DateTime.UtcNow
                };

                var existingWeather = _context.Weathers
                    .FirstOrDefault(w => w.CountryId == country.Id);

                if (existingWeather == null)
                {
                    _context.Weathers.Add(weather);
                }
                else
                {
                    existingWeather.WeatherMain = weather.WeatherMain;
                    existingWeather.WeatherDescription = weather.WeatherDescription;
                    existingWeather.Temperature = weather.Temperature;
                    existingWeather.FeelsLike = weather.FeelsLike;
                    existingWeather.Pressure = weather.Pressure;
                    existingWeather.Humidity = weather.Humidity;
                    existingWeather.WindSpeed = weather.WindSpeed;
                    existingWeather.WindDeg = weather.WindDeg;
                    existingWeather.WindGust = weather.WindGust;
                    existingWeather.Timestamp = weather.Timestamp;
                    existingWeather.Latitude = weather.Latitude;
                    existingWeather.Longitude = weather.Longitude;
                    _context.Weathers.Update(existingWeather);
                }

                _context.SaveChanges();
            }
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
            var country = _context.Countries
                .FirstOrDefault(c => c.LatitudeRangeStart <= lat && c.LatitudeRangeEnd >= lat &&
                                     c.LongitudeRangeStart <= lon && c.LongitudeRangeEnd >= lon);
            
            if (country == null)
            {
                return null;
            }
            
            var weather = _context.Weathers.FirstOrDefault(w => w.CountryId == country.Id);

            return weather;
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

        public void DeleteWeatherData(Weather weather)
        {
                _context.Weathers.Remove(weather);
                _context.SaveChanges();
        }
    }
}