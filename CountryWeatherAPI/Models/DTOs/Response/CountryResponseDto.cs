namespace CountryWeatherAPI.Models.DTOs.Response;

public class CountryResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int LatitudeRangeStart { get; set; }
    public int LatitudeRangeEnd { get; set; }
    public int LongitudeRangeStart { get; set; }
    public int LongitudeRangeEnd { get; set; }
    public int? ResponsiblePersonId { get; set; }
}