using ConsultaDB.Entities;
using System.Collections.Generic;

namespace WebApiSQL.Models
{
    public interface IPersonRepository
    {
        Person GetPerson(string id);
        List<Person> GetPersons(string firstname, string lastname);
        void SavePerson(Person person);
        void UpdatePerson(Person person);
        void DelPerson(int id);
    }
}
