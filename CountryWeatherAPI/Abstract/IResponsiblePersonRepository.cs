using System.Collections.Generic;
using CountryWeatherAPI.Models;

namespace CountryWeatherAPI.Abstract
{
    public interface IResponsiblePersonRepository
    {
        // Retrieves all responsible persons from the database
        List<ResponsiblePerson> GetAllResponsiblePersons();

        // Retrieves a responsible person by their ID
        ResponsiblePerson GetResponsiblePersonById(int id);

        // Adds a new responsible person to the database
        void AddResponsiblePerson(ResponsiblePerson responsiblePerson);

        void AssignResponsiblePerson(int responsiblePersonId, int countryId);

        // Updates an existing responsible person in the database
        void UpdateResponsiblePerson(ResponsiblePerson responsiblePerson);

        // Deletes a responsible person from the database
        void DeleteResponsiblePerson(int id);

        void Save();
    }
}