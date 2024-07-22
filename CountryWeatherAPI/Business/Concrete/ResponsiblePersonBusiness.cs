using AutoMapper;
using CountryWeatherAPI.Abstract;
using CountryWeatherAPI.Business.Abstract;
using CountryWeatherAPI.Models;
using CountryWeatherAPI.Models.DTOs.Request;
using CountryWeatherAPI.Models.DTOs.Response;
using Microsoft.AspNetCore.Mvc;
using PhoneNumbers;
using System;
using System.Collections.Generic;

namespace CountryWeatherAPI.Business.Concrete
{
    public class ResponsiblePersonBusiness : IResponsiblePersonBusiness
    {
        private readonly IResponsiblePersonRepository _responsiblePersonRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public ResponsiblePersonBusiness(IResponsiblePersonRepository responsiblePersonRepository, ICountryRepository countryRepository, IMapper mapper)
        {
            _responsiblePersonRepository = responsiblePersonRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public IActionResult GetAllResponsiblePersons()
        {
            var responsiblePersons = _responsiblePersonRepository.GetAllResponsiblePersons();
            return new OkObjectResult(responsiblePersons);
        }

        public IActionResult GetResponsiblePersonById(int id)
        {
            var responsiblePerson = _responsiblePersonRepository.GetResponsiblePersonById(id);
            if (responsiblePerson == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(responsiblePerson);
        }

        public IActionResult AddResponsiblePerson(ResponsiblePersonPostDto responsiblePersonPostDto)
        {

            try
            {
                ResponsiblePersonBusinessValidation.AddResponsiblePersonValidation(responsiblePersonPostDto);
            }
            catch (Exception ex)
            {
                var error = new ValidationProblemDetails();
                error.Errors.Add("Validation", new[] { ex.Message });
                return new BadRequestObjectResult(error);
            }

            var responsiblePerson = _mapper.Map<ResponsiblePerson>(responsiblePersonPostDto);
            _responsiblePersonRepository.AddResponsiblePerson(responsiblePerson);

            return new CreatedAtActionResult("GetResponsiblePersonById", "ResponsiblePerson", new { id = responsiblePerson.Id }, responsiblePerson);
        }

        public IActionResult AssignResponsiblePersonToCountry(ResponsiblePersonAssignmentDto assignmentDto)
        {
            try
            {
                ResponsiblePersonBusinessValidation.ValidateAssignment(assignmentDto);
                _responsiblePersonRepository.AssignResponsiblePerson(assignmentDto.ResponsiblePersonId, assignmentDto.CountryId);
                return new NoContentResult();
            }
            catch (Exception ex)
            {
                return new NotFoundObjectResult(ex.Message);
            }
        }

        public IActionResult DeassignResponsiblePersonFromCountry(ResponsiblePersonAssignmentDto assignmentDto)
        {
            try
            {
                ResponsiblePersonBusinessValidation.ValidateDeassignment(assignmentDto);
                _responsiblePersonRepository.DeassignResponsiblePerson(assignmentDto.ResponsiblePersonId, assignmentDto.CountryId);

                var responsiblePerson = _responsiblePersonRepository.GetResponsiblePersonById(assignmentDto.ResponsiblePersonId);

                if (responsiblePerson == null)
                {
                    return new NotFoundObjectResult("Responsible person not found.");
                }

                return new OkObjectResult(responsiblePerson);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        public IActionResult UpdateResponsiblePerson(int id, ResponsiblePersonPutDto responsiblePersonPutDto)
        {
            try
            {
                ResponsiblePersonBusinessValidation.ValidateUpdate(id, responsiblePersonPutDto);
                var existingResponsiblePerson = _responsiblePersonRepository.GetResponsiblePersonById(id);
                if (existingResponsiblePerson == null)
                {
                    return new NotFoundResult();
                }

                existingResponsiblePerson.FirstName = responsiblePersonPutDto.FirstName;
                existingResponsiblePerson.LastName = responsiblePersonPutDto.LastName;
                existingResponsiblePerson.BirthDate = responsiblePersonPutDto.BirthDate;
                existingResponsiblePerson.Email = responsiblePersonPutDto.Email;
                existingResponsiblePerson.PhoneNumber = responsiblePersonPutDto.PhoneNumber;

                _responsiblePersonRepository.UpdateResponsiblePerson(existingResponsiblePerson);
                return new NoContentResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        public IActionResult DeleteResponsiblePerson(int id)
        {
            try
            {
                ResponsiblePersonBusinessValidation.ValidateDeletion(id);
                var responsiblePerson = _responsiblePersonRepository.GetResponsiblePersonById(id);
                if (responsiblePerson == null)
                {
                    return new NotFoundResult();
                }

                _responsiblePersonRepository.DeleteResponsiblePerson(id);
                return new NoContentResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
