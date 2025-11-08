using Microsoft.AspNetCore.Mvc;
using RejoiceNewBackend.Model;
using RejoiceNewBackend.Repo;

namespace RejoiceNewBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly RepoPerson _repoPerson;

        public HomeController(RepoPerson repoPerson)
        {
            _repoPerson = repoPerson;
        }
        #region 示範
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

        [HttpDelete("deletePerson/{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _repoPerson.DeleteAsync(id);
            if (result)
            {
                return Ok(new { message = "Person deleted successfully." });
            }
            else
            {
                return NotFound(new { message = "Person not found." });
            }
        }


        #endregion





        #region 後臺首頁
        [HttpGet("BackendIndex")]
        public IActionResult BackendIndex()
        {
            return Redirect("~/BackendIndex.html");
        }
        #endregion

    }
}
