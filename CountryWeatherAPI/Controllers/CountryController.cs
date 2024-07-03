using Microsoft.AspNetCore.Mvc;
using CountryWeatherAPI.Abstract;
using CountryWeatherAPI.Models;
using System;
using System.Collections.Generic;

namespace CountryWeatherAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public IActionResult GetAllCountries()
        {
            var countries = _countryRepository.GetAllCountries();
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public IActionResult GetCountryById(int id)
        {
            var country = _countryRepository.GetCountryById(id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        [HttpPost]
        public IActionResult AddCountry([FromBody] Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _countryRepository.AddCountry(country);
            return CreatedAtAction(nameof(GetCountryById), new { id = country.Id }, country);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCountry(int id, [FromBody] Country country)
        {
            if (id != country.Id)
            {
                return BadRequest("Country ID mismatch");
            }

            var existingCountry = _countryRepository.GetCountryById(id);
            if (existingCountry == null)
            {
                return NotFound();
            }

            _countryRepository.UpdateCountry(country);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(int id)
        {
            var country = _countryRepository.GetCountryById(id);
            if (country == null)
            {
                return NotFound();
            }

            _countryRepository.DeleteCountry(id);
            return NoContent();
        }
    }
}
