using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CountryWeatherAPI.Models;

public class Country
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int LatitudeRangeStart { get; set; }
    public int LatitudeRangeEnd { get; set; }
    public int LongitudeRangeStart { get; set; }
    public int LongitudeRangeEnd { get; set; }
    public int? ResponsiblePersonId { get; set; }
    [JsonIgnore]
    public ResponsiblePerson ResponsiblePerson { get; set; }
    [JsonIgnore]
    public Weather Weather { get; set; }
}