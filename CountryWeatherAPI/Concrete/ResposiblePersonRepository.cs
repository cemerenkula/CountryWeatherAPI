using System;
using System.Collections.Generic;
using System.Linq;
using CountryWeatherAPI.Abstract;
using CountryWeatherAPI.DataAccess;
using CountryWeatherAPI.Models;
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
            return _context.ResponsiblePersons.ToList();
        }

        public ResponsiblePerson GetResponsiblePersonById(int id)
        {
            return _context.ResponsiblePersons.Find(id);
        }

        public void AddResponsiblePerson(ResponsiblePerson responsiblePerson)
        {
            _context.ResponsiblePersons.Add(responsiblePerson);
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
    }
}