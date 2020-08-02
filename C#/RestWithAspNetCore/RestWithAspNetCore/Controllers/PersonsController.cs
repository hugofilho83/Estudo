using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestWithAspNetCore.Model;
using RestWithAspNetCore.Model.Context;
using RestWithAspNetCore.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET api/person
        [HttpGet]
        public async Task<ActionResult<List<Person>>> Get([FromServices] ApplicationDBContext context)
        {
            return await context.Persons.ToListAsync();
        }

        // GET api/person/id
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var person = _personService.FindById(id);
            if (person == null) return BadRequest("person not found.");
         
            return Ok(person);
        }

        //POST api/person/{person}
        [HttpPost]
        public ActionResult Post([FromServices] ApplicationDBContext context, [FromBody] Person person) 
        {
            if (person == null) return BadRequest("person not found.");
            return new ObjectResult(_personService.Create(person));
        }

        //PUT api/person/{person}
        [HttpPut]
        public ActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest("person not found.");
            return new ObjectResult(_personService.Update(person));
        }

        //DELETE api/person/id
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var person = _personService.FindById(id);
            if (person == null) return BadRequest("person not found.");

            _personService.Delete(id);

            return NoContent();
        }
    }
}
