using CountryWeatherAPI.Models.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace CountryWeatherAPI.Business.Abstract;

public interface ICountryBusiness
{
    IActionResult GetAllCountries();
    IActionResult GetCountryById(int id);
    IActionResult GetCountryByCoordinates(int lat, int lon);
    IActionResult AddCountry(CountryPostDto countryPostDto);
    IActionResult UpdateCountry(int id, CountryPutDto countryPutDto);
    IActionResult DeleteCountry(int id);
}