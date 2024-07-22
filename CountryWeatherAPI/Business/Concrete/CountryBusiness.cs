using AutoMapper;
using CountryWeatherAPI.Abstract;
using CountryWeatherAPI.Business.Abstract;
using CountryWeatherAPI.Models;
using CountryWeatherAPI.Models.DTOs.Request;
using CountryWeatherAPI.Models.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace CountryWeatherAPI.Business.Concrete;

public partial class CountryBusiness : ICountryBusiness
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;
    
    public CountryBusiness(ICountryRepository countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
    }
    
    public IActionResult AddCountry(CountryPostDto countryPostDto)
    {
        CountryBusinessValidation.AddCountryValidation(countryPostDto);

        var country = _mapper.Map<Country>(countryPostDto);
        _countryRepository.AddCountry(country);

        return new CreatedAtActionResult("GetCountryById", "Country", new { id = country.Id }, country);
    }
    
    public IActionResult GetAllCountries()
        {
            var countries = _countryRepository.GetAllCountries();
            var countryDtos = _mapper.Map<IEnumerable<CountryResponseDto>>(countries);
            var orderedCountries = countryDtos.OrderBy(c => c.Id);
            return new OkObjectResult(orderedCountries);
        }

        public IActionResult GetCountryById(int id)
        {
            var country = _countryRepository.GetCountryById(id);
            if (country == null)
            {
                return new NotFoundResult();
            }
            var countryDtos = _mapper.Map<CountryResponseDto>(country);
            return new OkObjectResult(countryDtos);
        }
        
        public IActionResult GetCountryByCoordinates(int lat, int lon)
        {
            var country = _countryRepository.GetCountryByCoordinates(lat, lon);
            if (country == null)
            {
                return new NotFoundResult();
            }
            var countryDtos = _mapper.Map<CountryResponseDto>(country);
            return new OkObjectResult(countryDtos);
        }

        public IActionResult UpdateCountry(int id, CountryPutDto countryPutDto)
        {
            CountryBusinessValidation.UpdateCountryValidation(id, countryPutDto);

            var existingCountry = _countryRepository.GetCountryById(id);
            if (existingCountry == null)
            {
                return new NotFoundResult();
            }
            
            existingCountry.Name = countryPutDto.Name;
            existingCountry.LatitudeRangeStart = countryPutDto.LatitudeRangeStart;
            existingCountry.LatitudeRangeEnd = countryPutDto.LatitudeRangeEnd;
            existingCountry.LongitudeRangeStart = countryPutDto.LongitudeRangeStart;
            existingCountry.LongitudeRangeEnd = countryPutDto.LongitudeRangeEnd;

            _countryRepository.UpdateCountry(existingCountry);
            return new NoContentResult();
        }

        public IActionResult DeleteCountry(int id)
        {
            var country = _countryRepository.GetCountryById(id);
            if (country == null)
            {
                return new NotFoundResult();
            }

            _countryRepository.DeleteCountry(id);
            return new NoContentResult();
        }
}