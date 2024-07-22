using CountryWeatherAPI.Business.Abstract;
using CountryWeatherAPI.Models.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace CountryWeatherAPI.Controllers
{
    [ApiController]
    [Route("/responsiblepersons")]
    public class ResponsiblePersonController : ControllerBase
    {
        private readonly IResponsiblePersonBusiness _responsiblePersonBusiness;

        public ResponsiblePersonController(IResponsiblePersonBusiness responsiblePersonBusiness)
        {
            _responsiblePersonBusiness = responsiblePersonBusiness;
        }

        [HttpGet]
        public IActionResult GetAllResponsiblePersons()
        {
            return _responsiblePersonBusiness.GetAllResponsiblePersons();
        }

        [HttpGet("{id}")]
        public IActionResult GetResponsiblePersonById(int id)
        {
            return _responsiblePersonBusiness.GetResponsiblePersonById(id);
        }

        [HttpPost]
        public IActionResult AddResponsiblePerson([FromBody] ResponsiblePersonPostDto responsiblePersonPostDto)
        {
            return _responsiblePersonBusiness.AddResponsiblePerson(responsiblePersonPostDto);
        }

        [HttpPost("assign")]
        public IActionResult AssignResponsiblePersonToCountry([FromBody] ResponsiblePersonAssignmentDto assignmentDto)
        {
            return _responsiblePersonBusiness.AssignResponsiblePersonToCountry(assignmentDto);
        }

        [HttpPost("deassign")]
        public IActionResult DeassignResponsiblePersonFromCountry([FromBody] ResponsiblePersonAssignmentDto assignmentDto)
        {
            return _responsiblePersonBusiness.DeassignResponsiblePersonFromCountry(assignmentDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateResponsiblePerson(int id, [FromBody] ResponsiblePersonPutDto responsiblePersonPutDto)
        {
            return _responsiblePersonBusiness.UpdateResponsiblePerson(id, responsiblePersonPutDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteResponsiblePerson(int id)
        {
            return _responsiblePersonBusiness.DeleteResponsiblePerson(id);
        }
    }
}
