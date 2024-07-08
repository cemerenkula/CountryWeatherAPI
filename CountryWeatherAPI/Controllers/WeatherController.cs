using Microsoft.AspNetCore.Mvc;
using CountryWeatherAPI.Abstract;
using CountryWeatherAPI.Models;
using System;
using System.Collections.Generic;
using System.Net;
using CountryWeatherAPI.Models.DTOs.Request;
using Newtonsoft.Json;


namespace CountryWeatherAPI.Controllers
{
    [ApiController]
    [Route("/weathers")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherRepository _weatherRepository;
        
        public WeatherController(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        [HttpGet]
        public IActionResult GetAllWeatherData()
        {
            var weatherData = _weatherRepository.GetAllWeatherData();
            var orderedWeatherData = weatherData.OrderBy(w => w.CountryId);
            return Ok(orderedWeatherData);
        }

        [HttpGet("country/{countryId}")]
        public IActionResult GetWeatherByCountryId(int countryId)
        {
            var weather = _weatherRepository.GetWeatherByCountryId(countryId);
            if (weather == null)
            {
                return NotFound();
            }
            return Ok(weather);
        }

        [HttpGet("coordinates/{lat}/{lon}")]
        public IActionResult GetWeatherByCoordinates(int lat, int lon)
        {
            var weather = _weatherRepository.GetWeatherByCoordinates(lat, lon);
            if (weather == null)
            {
                return NotFound();
            }
            return Ok(weather);
        }

        [HttpDelete("{countryId}")]
        public IActionResult DeleteWeatherData(int countryId)
        {
            var weather = _weatherRepository.GetWeatherByCountryId(countryId);
            if (weather == null)
            {
                return NotFound();
            }

            _weatherRepository.DeleteWeatherData(weather);
            return NoContent();
        }
        
        [HttpPost("update/{lat}/{lon}")]
        public IActionResult UpdateWeatherData(double lat, double lon)
        {
            try
            {
                _weatherRepository.UpdateWeatherWithRequest(lat, lon);
                return Ok("Weather data updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
