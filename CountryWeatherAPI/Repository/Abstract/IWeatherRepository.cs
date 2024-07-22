using System.Collections.Generic;
using CountryWeatherAPI.Models;

namespace CountryWeatherAPI.Abstract
{
    public interface IWeatherRepository
    {
        // Retrieves all weather data entries from the database
        List<Weather> GetAllWeatherData();

        // Retrieves weather data for a specific country based on its ID
        Weather GetWeatherByCountryId(int countryId);

        // Retrieves weather data for a specific coordinate (latitude and longitude)
        Weather GetWeatherByCoordinates(int lat, int lon);

        // Adds new weather data to the database
        void AddWeatherData(Weather weather);

        // Updates existing weather data in the database
        void UpdateWeatherData(Weather weather);

        // Deletes weather data from the database
        void DeleteWeatherData(Weather weather);

        void UpdateWeatherWithRequest(double latitude, double longitude);
    }
}