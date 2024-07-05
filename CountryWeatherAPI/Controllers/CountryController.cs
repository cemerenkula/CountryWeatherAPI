using Microsoft.AspNetCore.Mvc;
using CountryWeatherAPI.Abstract;
using CountryWeatherAPI.Models;
using System;
using System.Collections.Generic;
using AutoMapper;
using CountryWeatherAPI.Models.DTOs.Response;
using CountryWeatherAPI.Models.DTOs.Request;

namespace CountryWeatherAPI.Controllers
{
    [ApiController]
    [Route("/countries")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllCountries()
        {
            var countries = _countryRepository.GetAllCountries();
            var countryDtos = _mapper.Map<IEnumerable<CountryResponseDto>>(countries);
            return Ok(countryDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetCountryById(int id)
        {
            var country = _countryRepository.GetCountryById(id);
            if (country == null)
            {
                return NotFound();
            }
            var countryDtos = _mapper.Map<CountryResponseDto>(country);
            return Ok(countryDtos);
        }
        
        [HttpGet("{lat}/{lon}")]
        public IActionResult GetCountryByCoordinates(int lat, int lon)
        {
            var country = _countryRepository.GetCountryByCoordinates(lat, lon);
            if (country == null)
            {
                return NotFound();
            }
            var countryDtos = _mapper.Map<CountryResponseDto>(country);
            return Ok(countryDtos);
        }

        [HttpPost]
        public IActionResult AddCountry([FromBody] CountryRequestDto countryRequestDto)
        {
            var country = _mapper.Map<Country>(countryRequestDto);
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
