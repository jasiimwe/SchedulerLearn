using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScheduleLearnApi.Models;
using ScheduleLearnApi.Models.Interfaces.Service;

namespace ScheduleLearnApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionController : ControllerBase
    {
        private readonly IDivision _division;
        public DivisionController(IDivision division)
        {
            _division = division;
        }

        [HttpGet]
        [Route("api/all_division")]

        public async Task<IActionResult> GetAllDivisionsAsync()
        {
            var divisions = await _division.GetDivisionAsync();
            return Ok(divisions);
        }

        [HttpGet]
        [Route("api/get_division")]
        public async Task<IActionResult> GetDivisionAsync(string id)
        {
            var division = await _division.GetDivisionAsync(id);
            return Ok(division);
        }

        [HttpPost]
        [Route("api/create_division")]
        public async Task<IActionResult> CreateDivisionAsync([FromBody] Division division)
        {
            var create_division = await _division.AddDivisionAsync(division);
            return Ok(create_division);
        }

        [HttpPatch]
        [Route("api/update_division")]
        public IActionResult UpdateDvision(string id, Division division)
        {
            var update_division = _division.UpdateDivisionAsync(id, division);
            return Ok(update_division);
        }

        [HttpDelete]
        [Route("api/delete_division")]
        public async Task<IActionResult> DeleteDivisonAsync(string id)
        {
            var delete_division = await _division.DeleteDivisionAsync(id);
            return Ok(delete_division);
        }
    }
}
