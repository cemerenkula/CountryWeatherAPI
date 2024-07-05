namespace CountryWeatherAPI.Models;

public class Weather
{
    public int Id { get; set; }
    public int CountryId { get; set; }
    public Country Country { get; set; }
    public int Latitude { get; set; }
    public int Longitude { get; set; }
    public float Temperature { get; set; }
    public float FeelsLike { get; set; }
    public int Pressure { get; set; }
    public int Humidity { get; set; }
    public float DewPoint { get; set; }
    public float Uvi { get; set; }
    public int Clouds { get; set; }
    public int Visibility { get; set; }
    public float WindSpeed { get; set; }
    public int WindDeg { get; set; }
    public float WindGust { get; set; }
    public string WeatherMain { get; set; }
    public string WeatherDescription { get; set; }
    public string WeatherIcon { get; set; }
    public DateTime Timestamp { get; set; }
}