using Microsoft.AspNetCore.Mvc;
using CountryWeatherAPI.Abstract;
using CountryWeatherAPI.Models;
using System;
using System.Collections.Generic;
using AutoMapper;
using CountryWeatherAPI.Models.DTOs.Request;

namespace CountryWeatherAPI.Controllers
{
    [ApiController]
    [Route("/responsiblepersons")]
    public class ResponsiblePersonController : ControllerBase
    {
        private readonly IResponsiblePersonRepository _responsiblePersonRepository;
        private readonly IMapper _mapper;
        
        public ResponsiblePersonController(IResponsiblePersonRepository responsiblePersonRepository, IMapper mapper)
        {
            _responsiblePersonRepository = responsiblePersonRepository;
            _mapper = mapper;
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
        public IActionResult AddResponsiblePerson([FromBody] ResponsiblePersonPostDto responsiblePersonPostDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var responsiblePerson = _mapper.Map<ResponsiblePerson>(responsiblePersonPostDto);
            _responsiblePersonRepository.AddResponsiblePerson(responsiblePerson);

            return CreatedAtAction(nameof(GetResponsiblePersonById), new { id = responsiblePerson.Id },
                responsiblePerson);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateResponsiblePerson(int id, [FromBody] ResponsiblePersonPutDto responsiblePersonPutDto)
        {
            if (id != responsiblePersonPutDto.Id)
            {
                return BadRequest("ResponsiblePerson ID mismatch");
            }

            var existingResponsiblePerson = _responsiblePersonRepository.GetResponsiblePersonById(id);
            if (existingResponsiblePerson == null)
            {
                return NotFound();
            }

            var responsiblePerson = _mapper.Map<ResponsiblePerson>(responsiblePersonPutDto);
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
