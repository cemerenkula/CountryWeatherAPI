using CountryWeatherAPI.Business.Abstract;
using CountryWeatherAPI.Models.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace CountryWeatherAPI.Controllers
{
    [ApiController]
    [Route("/weathers")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherBusiness _weatherBusiness;

        public WeatherController(IWeatherBusiness weatherBusiness)
        {
            _weatherBusiness = weatherBusiness;
        }

        [HttpGet]
        public IActionResult GetAllWeatherData()
        {
            return _weatherBusiness.GetAllWeatherData();
        }

        [HttpGet("country/{countryId}")]
        public IActionResult GetWeatherByCountryId(int countryId)
        {
            return _weatherBusiness.GetWeatherByCountryId(countryId);
        }

        [HttpGet("coordinates/{lat}/{lon}")]
        public IActionResult GetWeatherByCoordinates(int lat, int lon)
        {
            return _weatherBusiness.GetWeatherByCoordinates(lat, lon);
        }

        [HttpDelete("{countryId}")]
        public IActionResult DeleteWeatherData(int countryId)
        {
            return _weatherBusiness.DeleteWeatherData(countryId);
        }

        [HttpPost("update/{lat}/{lon}")]
        public IActionResult UpdateWeatherData(double lat, double lon)
        {
            return _weatherBusiness.UpdateWeatherData(lat, lon);
        }
    }
}