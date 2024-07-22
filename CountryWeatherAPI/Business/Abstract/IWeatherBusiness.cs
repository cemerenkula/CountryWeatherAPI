using Microsoft.AspNetCore.Mvc;

namespace CountryWeatherAPI.Business.Abstract
{
    public interface IWeatherBusiness
    {
        IActionResult GetAllWeatherData();
        IActionResult GetWeatherByCountryId(int countryId);
        IActionResult GetWeatherByCoordinates(int lat, int lon);
        IActionResult DeleteWeatherData(int countryId);
        IActionResult UpdateWeatherData(double lat, double lon);
    }
}