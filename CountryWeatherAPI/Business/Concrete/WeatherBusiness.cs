using CountryWeatherAPI.Abstract;
using CountryWeatherAPI.Business.Abstract;
using CountryWeatherAPI.Models;
using CountryWeatherAPI.Models.DTOs.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CountryWeatherAPI.Business.Concrete
{
    public class WeatherBusiness : IWeatherBusiness
    {
        private readonly IWeatherRepository _weatherRepository;

        public WeatherBusiness(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        public IActionResult GetAllWeatherData()
        {
            var weatherData = _weatherRepository.GetAllWeatherData();
            var orderedWeatherData = weatherData.OrderBy(w => w.CountryId);
            return new OkObjectResult(orderedWeatherData);
        }

        public IActionResult GetWeatherByCountryId(int countryId)
        {
            var weather = _weatherRepository.GetWeatherByCountryId(countryId);
            if (weather == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(weather);
        }

        public IActionResult GetWeatherByCoordinates(int lat, int lon)
        {
            var weather = _weatherRepository.GetWeatherByCoordinates(lat, lon);
            if (weather == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(weather);
        }

        public IActionResult DeleteWeatherData(int countryId)
        {
            var weather = _weatherRepository.GetWeatherByCountryId(countryId);
            if (weather == null)
            {
                return new NotFoundResult();
            }

            _weatherRepository.DeleteWeatherData(weather);
            return new NoContentResult();
        }

        public IActionResult UpdateWeatherData(double lat, double lon)
        {
            try
            {
                _weatherRepository.UpdateWeatherWithRequest(lat, lon);
                return new OkObjectResult("Weather data updated successfully.");
            }
            catch (Exception ex)
            {
                return new ObjectResult($"Internal server error: {ex.Message}") { StatusCode = 500 };
            }
        }
    }
}
