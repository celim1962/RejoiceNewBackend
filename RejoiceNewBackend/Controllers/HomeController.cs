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
        private readonly RepoTripCategory _repoTripCategory;
        private readonly RepoTripDetail _repoTripDetail;
        private readonly RepoTripDetailPrice _repoTripDetailPrice;
        private readonly RepoTripDetailSchedule _repoTripDetailSchedule;

        public HomeController(
            RepoPerson repoPerson, 
            RepoTripCategory repoTripCategory,
            RepoTripDetail repoTripDetail,
            RepoTripDetailPrice repoTripDetailPrice,
            RepoTripDetailSchedule repoTripDetailSchedule)
        {
            _repoPerson = repoPerson;
            _repoTripCategory = repoTripCategory;
            _repoTripDetail = repoTripDetail;
            _repoTripDetailPrice = repoTripDetailPrice;
            _repoTripDetailSchedule = repoTripDetailSchedule;
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

        #region TripCategory
        [HttpGet("tripCategories")]
        public async Task<ActionResult<IEnumerable<TripCategory>>> GetAllTripCategories()
        {
            return Ok(await _repoTripCategory.GetAllAsync());
        }

        [HttpGet("tripCategory/{id}")]
        public async Task<ActionResult<TripCategory>> GetTripCategoryById(int id)
        {
            var tripCategory = await _repoTripCategory.GetByIdAsync(id);
            if (tripCategory == null)
            {
                return NotFound(new { message = "TripCategory not found." });
            }
            return Ok(tripCategory);
        }

        [HttpPost("addTripCategory")]
        public async Task<ActionResult<TripCategory>> AddTripCategoryAsync(TripCategory tripCategory)
        {
            return Ok(await _repoTripCategory.AddAsync(tripCategory));
        }

        [HttpPut("updateTripCategory/{id}")]
        public async Task<ActionResult> UpdateTripCategoryAsync(int id, TripCategory tripCategory)
        {
            if (id != tripCategory.Id)
            {
                return BadRequest(new { message = "ID mismatch." });
            }
            var existingTripCategory = await _repoTripCategory.GetByIdAsync(id);
            if (existingTripCategory == null)
            {
                return NotFound(new { message = "TripCategory not found." });
            }
            await _repoTripCategory.UpdateAsync(tripCategory);
            return Ok(new { message = "TripCategory updated successfully." });
        }

        [HttpDelete("deleteTripCategory/{id}")]
        public async Task<ActionResult> DeleteTripCategoryAsync(int id)
        {
            var result = await _repoTripCategory.DeleteAsync(id);
            if (result)
            {
                return Ok(new { message = "TripCategory deleted successfully." });
            }
            else
            {
                return NotFound(new { message = "TripCategory not found." });
            }
        }



        #endregion

        #region TripDetail

        [HttpGet("tripDetails")]
        public async Task<ActionResult<IEnumerable<TripDetail>>> GetAllTripDetails()
        {
            return Ok(await _repoTripDetail.GetAllAsync());
        }

        [HttpGet("tripDetails/{categoryId}")]
        public async Task<ActionResult<IEnumerable<TripDetail>>> GetTripDetailsByCategoryId(int categoryId)
        {
            var tripDetails = await _repoTripDetail.GetAllAsync();
            var filteredTripDetails = tripDetails.Where(td => td.TripCategoryId == categoryId).ToList();
            return Ok(filteredTripDetails);
        }

        [HttpGet("tripDetail/{id}")]
        public async Task<ActionResult<TripDetail>> GetTripDetailById(int id)
        {
            var tripDetail = await _repoTripDetail.GetByIdAsync(id);
            if (tripDetail == null)
            {
                return NotFound(new { message = "TripDetail not found." });
            }
            return Ok(tripDetail);
        }

        [HttpPost("addTripDetail")]
        public async Task<ActionResult<TripDetail>> AddTripDetailAsync(TripDetail tripDetail)
        {
            return Ok(await _repoTripDetail.AddAsync(tripDetail));
        }

        [HttpPut("updateTripDetail/{id}")]
        public async Task<ActionResult> UpdateTripDetailAsync(int id, TripDetail tripDetail)
        {
            if (id != tripDetail.Id)
                return BadRequest(new { message = "ID mismatch." });

            var existing = await _repoTripDetail.GetByIdAsync(id);
            if (existing == null)
                return NotFound(new { message = "TripDetail not found." });

            await _repoTripDetail.UpdateAsync(existing, tripDetail);

            return Ok(new { message = "TripDetail updated successfully." });
        }


        [HttpDelete("deleteTripDetail/{id}")]
        public async Task<ActionResult> DeleteTripDetailAsync(int id)
        {
            var result = await _repoTripDetail.DeleteAsync(id);
            if (result)
            {
                return Ok(new { message = "TripDetail deleted successfully." });
            }
            else
            {
                return NotFound(new { message = "TripDetail not found." });
            }
        }





        #endregion

        #region TripDetailPrice
        [HttpGet("tripDetailPrices/{tripDetailId}")]
        public async Task<ActionResult<IEnumerable<TripDetailPrice>>> GetTripDetailPricesByTripDetailId(int tripDetailId)
        {
            var tripDetailPrices = await _repoTripDetailPrice.GetAllAsync();
            var filteredPrices = tripDetailPrices.Where(tdp => tdp.TripDetailId == tripDetailId).ToList();
            return Ok(filteredPrices);
        }

        [HttpPost("addTripDetailPrice")]
        public async Task<ActionResult<TripDetailPrice>> AddTripDetailPriceAsync(TripDetailPrice tripDetailPrice)
        {
            return Ok(await _repoTripDetailPrice.AddAsync(tripDetailPrice));
        }

        [HttpPut("updateTripDetailPrice/{id}")]
        public async Task<ActionResult> UpdateTripDetailPriceAsync(int id, TripDetailPrice tripDetailPrice)
        {
            if (id != tripDetailPrice.Id)
            {
                return BadRequest(new { message = "ID mismatch." });
            }
            var existingTripDetailPrice = await _repoTripDetailPrice.GetByIdAsync(id);
            if (existingTripDetailPrice == null)
            {
                return NotFound(new { message = "TripDetailPrice not found." });
            }
            await _repoTripDetailPrice.UpdateAsync(tripDetailPrice);
            return Ok(new { message = "TripDetailPrice updated successfully." });
        }

        [HttpDelete("deleteTripDetailPrice/{id}")]
        public async Task<ActionResult> DeleteTripDetailPriceAsync(int id)
        {
            var result = await _repoTripDetailPrice.DeleteAsync(id);
            if (result)
            {
                return Ok(new { message = "TripDetailPrice deleted successfully." });
            }
            else
            {
                return NotFound(new { message = "TripDetailPrice not found." });
            }
        }
        #endregion

        #region TripDetailSchedule
        [HttpGet("tripDetailSchedules")]
        public async Task<ActionResult<IEnumerable<TripDetailSchedule>>> GetAllTripDetailSchedules()
        {
            return Ok(await _repoTripDetailSchedule.GetAllAsync());
        }

        [HttpGet("tripDetailSchedules/{tripDetailId}")]
        public async Task<ActionResult<IEnumerable<TripDetailSchedule>>> GetTripDetailSchedulesByTripDetailId(int tripDetailId)
        {
            var tripDetailSchedules = await _repoTripDetailSchedule.GetAllAsync();
            var filteredSchedules = tripDetailSchedules.Where(tds => tds.TripDetailId == tripDetailId).ToList();
            return Ok(filteredSchedules);
        }

        [HttpPost("addTripDetailSchedule")]
        public async Task<ActionResult<TripDetailSchedule>> AddTripDetailScheduleAsync(TripDetailSchedule tripDetailSchedule)
        {
            return Ok(await _repoTripDetailSchedule.AddAsync(tripDetailSchedule));
        }

        [HttpPut("updateTripDetailSchedule/{id}")]
        public async Task<ActionResult> UpdateTripDetailScheduleAsync(int id, TripDetailSchedule tripDetailSchedule)
        {
            if (id != tripDetailSchedule.Id)
            {
                return BadRequest(new { message = "ID mismatch." });
            }
            var existingTripDetailSchedule = await _repoTripDetailSchedule.GetByIdAsync(id);
            if (existingTripDetailSchedule == null)
            {
                return NotFound(new { message = "TripDetailSchedule not found." });
            }
            await _repoTripDetailSchedule.UpdateAsync(tripDetailSchedule);
            return Ok(new { message = "TripDetailSchedule updated successfully." });
        }

        [HttpDelete("deleteTripDetailSchedule/{id}")]
        public async Task<ActionResult> DeleteTripDetailScheduleAsync(int id)
        {
            var result = await _repoTripDetailSchedule.DeleteAsync(id);
            if (result)
            {
                return Ok(new { message = "TripDetailSchedule deleted successfully." });
            }
            else
            {
                return NotFound(new { message = "TripDetailSchedule not found." });
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
