using Microsoft.AspNetCore.Mvc;
using CountryWeatherAPI.Abstract;
using CountryWeatherAPI.Models;
using System;
using System.Collections.Generic;

namespace CountryWeatherAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResponsiblePersonController : ControllerBase
    {
        private readonly IResponsiblePersonRepository _responsiblePersonRepository;

        public ResponsiblePersonController(IResponsiblePersonRepository responsiblePersonRepository)
        {
            _responsiblePersonRepository = responsiblePersonRepository;
        }

        [HttpGet]
        public IActionResult GetAllResponsiblePersons()
        {
            var responsiblePersons = _responsiblePersonRepository.GetAllResponsiblePersons();
            return Ok(responsiblePersons);
        }

        [HttpGet("{id}")]
        public IActionResult GetResponsiblePersonById(int id)
        {
            var responsiblePerson = _responsiblePersonRepository.GetResponsiblePersonById(id);
            if (responsiblePerson == null)
            {
                return NotFound();
            }
            return Ok(responsiblePerson);
        }

        [HttpPost]
        public IActionResult AddResponsiblePerson([FromBody] ResponsiblePerson responsiblePerson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _responsiblePersonRepository.AddResponsiblePerson(responsiblePerson);
            return CreatedAtAction(nameof(GetResponsiblePersonById), new { id = responsiblePerson.Id }, responsiblePerson);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateResponsiblePerson(int id, [FromBody] ResponsiblePerson responsiblePerson)
        {
            if (id != responsiblePerson.Id)
            {
                return BadRequest("ResponsiblePerson ID mismatch");
            }

            var existingResponsiblePerson = _responsiblePersonRepository.GetResponsiblePersonById(id);
            if (existingResponsiblePerson == null)
            {
                return NotFound();
            }

            _responsiblePersonRepository.UpdateResponsiblePerson(responsiblePerson);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteResponsiblePerson(int id)
        {
            var responsiblePerson = _responsiblePersonRepository.GetResponsiblePersonById(id);
            if (responsiblePerson == null)
            {
                return NotFound();
            }

            _responsiblePersonRepository.DeleteResponsiblePerson(id);
            return NoContent();
        }
    }
}
