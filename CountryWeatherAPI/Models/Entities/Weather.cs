

using System.Text.Json.Serialization;

namespace CountryWeatherAPI.Models;

public class Weather
{
    [JsonIgnore]
    public int Id { get; set; }
    public int? CountryId { get; set; }
    public string CountryName { get; set; }
    public int Latitude { get; set; }
    public int Longitude { get; set; }
    public string WeatherMain { get; set; }
    public string WeatherDescription { get; set; }
    public double Temperature { get; set; }
    public double FeelsLike { get; set; }
    public double Pressure { get; set; }
    public int Humidity { get; set; }
    public double WindSpeed { get; set; }
    public int WindDeg { get; set; }
    public double WindGust { get; set; }
    public DateTime Timestamp { get; set; }
    [JsonIgnore]
    public Country Country { get; set; }
}