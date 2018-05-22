using ConsultaDB.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiSQL.Models;

namespace WebApiSQL.Controllers
{
    
    public class PersonController : ApiController
    {
        private IPersonRepository pr;

        public PersonController(IPersonRepository pr)
        {
            this.pr = pr;
        }

        // GET: api/Person
        public IEnumerable<Person> Get()
        {
            return pr.GetPersons("","");
        }

        public IEnumerable<Person> Get(string firstName, string lastName)
        {
            return pr.GetPersons(firstName, lastName);
        }

        // GET: api/Person/5
        public Person Get(int id)
        {
            var person = pr.GetPerson("" + id);
            return person;
        }

        // POST: api/Person
        public void Post([FromBody]string value)
        {
            Console.WriteLine(value);
        }

        public void Post(string firstName, string lastName, string middleName, string title)
        {
            var persona = new Person
            {
                id = 0,
                firstName = firstName,
                lastName = lastName,
                middleName = middleName,
                title = title
            };

            pr.SavePerson(persona);

        }

        public void Post(int id, string firstName, string lastName, string middleName, string title)
        {
            var persona = new Person
            {
                id =  id,
                firstName = firstName,
                lastName = lastName,
                middleName = middleName,
                title = title
            };

            pr.UpdatePerson(persona);
        }

        public void Post(int id)
        {
            pr.DelPerson(id);
        }

        // PUT: api/Person/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Person/5
        public void Delete(int id)
        {
        }
    }
}
