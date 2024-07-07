using Microsoft.AspNetCore.Mvc;
using CountryWeatherAPI.Abstract;
using CountryWeatherAPI.Models;
using System;
using System.Collections.Generic;

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
            return Ok(weatherData);
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

        [HttpPost]
        public IActionResult AddWeatherData([FromBody] Weather weather)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _weatherRepository.AddWeatherData(weather);
            return CreatedAtAction(nameof(GetWeatherByCountryId), new { countryId = weather.CountryId }, weather);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateWeatherData(int id, [FromBody] Weather weather)
        {
            if (id != weather.Id)
            {
                return BadRequest("Weather ID mismatch");
            }

            var existingWeather = _weatherRepository.GetWeatherByCountryId(id);
            if (existingWeather == null)
            {
                return NotFound();
            }

            _weatherRepository.UpdateWeatherData(weather);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWeatherData(int id)
        {
            var weather = _weatherRepository.GetWeatherByCountryId(id);
            if (weather == null)
            {
                return NotFound();
            }

            _weatherRepository.DeleteWeatherData(id);
            return NoContent();
        }
    }
}
