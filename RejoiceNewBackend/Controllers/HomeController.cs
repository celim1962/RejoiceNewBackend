using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RejoiceNewBackend.Model;
using RejoiceNewBackend.Repo;

namespace RejoiceNewBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly RepoPerson _repoPerson;

        public HomeController(RepoPerson repoPerson)
        {
            _repoPerson = repoPerson;
        }

        [HttpGet(Name = "GetHome")]
        public string Index()
        {
            return "123";
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Person>>> GetAll()
        {
            return Ok(await _repoPerson.GetAllAsync());
        }
        [HttpPost("addPerson")]
        public async Task<ActionResult<Person>> AddAsync(Person person)
        {
            return Ok(await _repoPerson.AddAsync(person));
        }

    }
}
