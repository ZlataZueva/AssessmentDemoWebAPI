using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using AssessmentDemo.Foundation.Model;

namespace AssessmentDemoWebAPI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private static readonly IList<Person> People = new[] {new Person { Id = 1, Name = "Nadya" } };

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return People;
        }

        [HttpGet("{id:int}")]
        public Person Get(int id)
        {
            return People.FirstOrDefault(p => p.Id == id);
        }

        [HttpPost]
        public void Post(Person person)
        {
            person.Id = People.Count;
            People.Add(person);
        }

        [HttpPut("{id:int}")]
        public void Put(int id, Person person)
        {
            var existingPerson = People.FirstOrDefault(p => p.Id == id);
            if (existingPerson != null) People.Remove(existingPerson);
            People.Add(person);
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            var person = People.FirstOrDefault(p => p.Id == id);
            if (person != null) People.Remove(person);
        }
    }
}
