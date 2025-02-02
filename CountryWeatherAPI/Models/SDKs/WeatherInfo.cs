namespace CountryWeatherAPI.Models.DTOs.Request;

public class WeatherInfo
{
    public class coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class weather
    {
        public string main { get; set; }
        public string description { get; set; }
    }

    public class main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double pressure { get; set; }
        public int humidity { get; set; }
    }

    public class wind
    {
        public double speed { get; set; }
        public int deg { get; set; }
        public double gust { get; set; }
    }

    public class root
    {
        public coord coord { get; set; }
        public List<weather> weather { get; set; }
        public main main { get; set; }
        public wind wind { get; set; }
    }
}