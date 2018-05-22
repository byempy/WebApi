using ConsultaDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaDB.Interfaces
{
    public interface IBL
    {
        Person GetPerson(string id);
        List<Person> GetPersons(string firstName, string lastName);
        void AddPerson(Person person);
        void UpdatePerson(Person person);
        void DelPerson(int id);
    }
}
