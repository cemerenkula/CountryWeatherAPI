using System;
using System.Collections.Generic;
using System.Linq;
using CountryWeatherAPI.Abstract;
using CountryWeatherAPI.DataAccess;
using CountryWeatherAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CountryWeatherAPI.Concrete
{
    public class ResponsiblePersonRepository : IResponsiblePersonRepository
    {
        private readonly CountryWeatherDbContext _context;

        public ResponsiblePersonRepository(CountryWeatherDbContext context)
        {
            _context = context;
        }

        public List<ResponsiblePerson> GetAllResponsiblePersons()
        {
            return _context.ResponsiblePersons.Include(rp => rp.Countries).ToList();
        }

        public ResponsiblePerson GetResponsiblePersonById(int id)
        {
            return _context.ResponsiblePersons
                .Include(rp => rp.Countries)
                .FirstOrDefault(rp => rp.Id == id);
        }

        public void AddResponsiblePerson(ResponsiblePerson responsiblePerson)
        {
            _context.ResponsiblePersons.Add(responsiblePerson);
            _context.SaveChanges();
        }

        public void AssignResponsiblePerson(int responsiblePersonId, int countryId)
        {
            var responsiblePerson = _context.ResponsiblePersons.Find(responsiblePersonId);
            var country = _context.Countries.Find(countryId);

            if (responsiblePerson == null)
            {
                throw new ArgumentException($"Responsible person with ID {responsiblePersonId} not found.");
            }

            if (country == null)
            {
                throw new ArgumentException($"Country with ID {countryId} not found.");
            }
            

            country.ResponsiblePersonId = responsiblePersonId;
            _context.Countries.Update(country);

            _context.SaveChanges();
        }
        
        public void DeassignResponsiblePerson(int responsiblePersonId, int countryId)
        {
            var responsiblePerson = _context.ResponsiblePersons
                .Include(rp => rp.Countries)
                .FirstOrDefault(rp => rp.Id == responsiblePersonId);

            var country = _context.Countries.Find(countryId);

            if (responsiblePerson == null)
            {
                throw new ArgumentException($"Responsible person with ID {responsiblePersonId} not found.");
            }

            if (country == null)
            {
                throw new ArgumentException($"Country with ID {countryId} not found.");
            }

            if (country.ResponsiblePersonId != responsiblePersonId)
            {
                throw new ArgumentException($"Country with ID {countryId} is not assigned to responsible person with ID {responsiblePersonId}.");
            }


            country.ResponsiblePersonId = null;
            country.ResponsiblePerson = null;

            _context.Countries.Update(country);
            
            responsiblePerson.Countries.Remove(country);

            _context.SaveChanges();
        }


        public void UpdateResponsiblePerson(ResponsiblePerson responsiblePerson)
        {
            _context.ResponsiblePersons.Update(responsiblePerson);
            _context.SaveChanges();
        }

        public void DeleteResponsiblePerson(int id)
        {
            var responsiblePerson = _context.ResponsiblePersons.Find(id);
            if (responsiblePerson != null)
            {
                _context.ResponsiblePersons.Remove(responsiblePerson);
                _context.SaveChanges();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        
    }
}