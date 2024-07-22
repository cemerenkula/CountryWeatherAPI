using CountryWeatherAPI.Models.DTOs.Request;
using Exception = System.Exception;

namespace CountryWeatherAPI.Business.Concrete;

public static class CountryBusinessValidation
{
    public static void AddCountryValidation(CountryPostDto dto)
    {
        if (dto == null)
            throw new Exception("Request cannot be empty.");

        if (dto.LongitudeRangeEnd > 180 || dto.LongitudeRangeEnd < -180)
            throw new Exception("LongitudeRangeEnd must be between -180 and 180");
        
        if (dto.LongitudeRangeStart > 180 || dto.LongitudeRangeStart < -180)
            throw new Exception("LongitudeRangeStart must be between -180 and 180");
        
        if (dto.LatitudeRangeEnd > 90 || dto.LatitudeRangeEnd < -90)
            throw new Exception("LatitudeRangeEnd must be between -90 and 90");
        
        if (dto.LatitudeRangeStart > 90 || dto.LatitudeRangeStart < -90)
            throw new Exception("LatitudeRangeStart must be between -90 and 90");
        
        if (string.IsNullOrWhiteSpace(dto.Name))
            throw new Exception("Name cannot be empty.");
        
        if (dto.Name.Length > 64)
            throw new Exception("Name cannot be more than 40 character.");

        if (dto.Name.Length < 3)
            throw new Exception("Name cannot be less than 3 character");
    }

    public static void UpdateCountryValidation(int id, CountryPutDto dto)
    {
        if (id != dto.Id)
            throw new Exception("Country ID mismatch");
        
        if (dto == null)
            throw new Exception("Request cannot be empty.");

        if (dto.LongitudeRangeEnd > 180 || dto.LongitudeRangeEnd < -180)
            throw new Exception("LongitudeRangeEnd must be between -180 and 180");
        
        if (dto.LongitudeRangeStart > 180 || dto.LongitudeRangeStart < -180)
            throw new Exception("LongitudeRangeStart must be between -180 and 180");
        
        if (dto.LatitudeRangeEnd > 90 || dto.LatitudeRangeEnd < -90)
            throw new Exception("LatitudeRangeEnd must be between -90 and 90");
        
        if (dto.LatitudeRangeStart > 90 || dto.LatitudeRangeStart < -90)
            throw new Exception("LatitudeRangeStart must be between -90 and 90");
        
        if (string.IsNullOrWhiteSpace(dto.Name))
            throw new Exception("Name cannot be empty.");
        
        if (dto.Name.Length > 64)
            throw new Exception("Name cannot be more than 40 character.");

        if (dto.Name.Length < 3)
            throw new Exception("Name cannot be less than 3 character");
    }
}
