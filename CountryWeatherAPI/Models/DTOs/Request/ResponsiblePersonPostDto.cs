namespace CountryWeatherAPI.Models.DTOs.Request;

public class ResponsiblePersonPostDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}