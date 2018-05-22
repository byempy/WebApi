using ConsultaDB.Entities;
using ConsultaDB.Interfaces;
using System.Collections.Generic;

namespace WebApiSQL.Models
{
    class PersonRepository:IPersonRepository
    {
        private IBL bl;

        public PersonRepository(IBL bl)
        {
            this.bl = bl;
        }

        public List<Person> GetPersons(string firstName, string lastName)
        {
            return bl.GetPersons(firstName, lastName);
        }

        public Person GetPerson(string id)
        {
            return bl.GetPerson(id);
        }

        public void SavePerson(Person person)
        {
            bl.AddPerson(person);
        }

        public void UpdatePerson(Person person)
        {
            bl.UpdatePerson(person);
        }

        public void DelPerson(int id)
        {
            bl.DelPerson(id);
        }
    }
}
