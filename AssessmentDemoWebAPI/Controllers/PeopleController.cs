using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using AssessmentDemo.Foundation.Model;

namespace AssessmentDemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private static readonly ICollection<Person> People = new[] {new Person { Name = "Nadya" } };

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return People;
        }

        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return People.FirstOrDefault(p => p.Id == id);
        }

        [HttpPost]
        public void Post([FromBody] Person person)
        {
            person.Id = People.Count;
            People.Add(person);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Person person)
        {
            var existingPerson = People.FirstOrDefault(p => p.Id == id);
            if (existingPerson != null) People.Remove(existingPerson);
            People.Add(person);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var person = People.FirstOrDefault(p => p.Id == id);
            if (person != null) People.Remove(person);
        }
    }
}
