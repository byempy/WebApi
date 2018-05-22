using ConsultaDB.Entities;
using ConsultaDB.Interfaces;
using ConsultaDB.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaBD.BL
{
    /// <summary>
    /// Clase que hace de intermediario entre la vista y la data.
    /// </summary>
    public class BL:IBL
    {
        private IDataHelper sh;

        public BL(IDataHelper sh)
        {
            this.sh = sh;
        }

        public List<Person> GetPersons(string firstName, string lastName)
        {
            Person persona = new Person()
            {
                firstName = firstName,
                lastName = lastName
            };

            return sh.GetListaPersonas(persona);
        }

        public void DelPersona(int id)
        {
            sh.DelPerson(id);
        }

        public Person GetPerson(string id)
        {
            return sh.GetPersonaDetallada(id);
        }

        public void AddPerson(Person person)
        {
            sh.AddPerson(person);
        }

        public void UpdatePerson(Person person)
        {
            sh.UpdatePerson(person);
        }

        public void DelPerson(int id)
        {
            sh.DelPerson(id);
        }
    }
}
