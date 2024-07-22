using CountryWeatherAPI.Models.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace CountryWeatherAPI.Business.Abstract
{
    public interface IResponsiblePersonBusiness
    {
        IActionResult GetAllResponsiblePersons();
        IActionResult GetResponsiblePersonById(int id);
        IActionResult AddResponsiblePerson(ResponsiblePersonPostDto responsiblePersonPostDto);
        IActionResult AssignResponsiblePersonToCountry(ResponsiblePersonAssignmentDto assignmentDto);
        IActionResult DeassignResponsiblePersonFromCountry(ResponsiblePersonAssignmentDto assignmentDto);
        IActionResult UpdateResponsiblePerson(int id, ResponsiblePersonPutDto responsiblePersonPutDto);
        IActionResult DeleteResponsiblePerson(int id);
    }
}