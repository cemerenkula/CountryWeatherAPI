using Microsoft.AspNetCore.Mvc;
using CountryWeatherAPI.Abstract;
using CountryWeatherAPI.Models;
using System;
using System.Collections.Generic;
using AutoMapper;
using CountryWeatherAPI.Business.Abstract;
using CountryWeatherAPI.Models.DTOs.Response;
using CountryWeatherAPI.Models.DTOs.Request;

namespace CountryWeatherAPI.Controllers
{
    [ApiController]
    [Route("/countries")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryBusiness _countryBusiness;

        public CountryController(ICountryBusiness countryBusiness)
        {
            _countryBusiness = countryBusiness;
        }

        [HttpGet]
        public IActionResult GetAllCountries()
        {
            return _countryBusiness.GetAllCountries();
        }

        [HttpGet("{id}")]
        public IActionResult GetCountryById(int id)
        {
            return _countryBusiness.GetCountryById(id);
        }
        
        [HttpGet("{lat}/{lon}")]
        public IActionResult GetCountryByCoordinates(int lat, int lon)
        {
            return _countryBusiness.GetCountryByCoordinates(lat, lon);
        }

        [HttpPost]
        public IActionResult AddCountry([FromBody] CountryPostDto countryPostDto)
        {
            return _countryBusiness.AddCountry(countryPostDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCountry(int id, [FromBody] CountryPutDto countryPutDto)
        {
            return _countryBusiness.UpdateCountry(id, countryPutDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(int id)
        {
            return _countryBusiness.DeleteCountry(id);
        }
    }
}
