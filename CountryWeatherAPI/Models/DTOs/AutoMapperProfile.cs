using AutoMapper;
using CountryWeatherAPI.Models.DTOs.Request;
using CountryWeatherAPI.Models.DTOs.Response;

namespace CountryWeatherAPI.Models.DTOs;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Country, CountryResponseDto>();
        CreateMap<CountryPostDto, Country>();
        CreateMap<CountryPutDto, Country>();
        CreateMap<ResponsiblePersonPostDto, ResponsiblePerson>();

    }
}