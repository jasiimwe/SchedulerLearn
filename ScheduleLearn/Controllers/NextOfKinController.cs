using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScheduleLearnApi.Models;
using ScheduleLearnApi.Models.Interfaces.Service;

namespace ScheduleLearnApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NextOfKinController : ControllerBase
    {
        private readonly INextOfKin _nextOfKin;
        public NextOfKinController(INextOfKin nextOfKin)
        {
            _nextOfKin = nextOfKin;
        }

        [HttpGet]
        [Route("api/all_next_of_kins")]
        public async Task<IActionResult> GetAllNextOfKinAsync()
        {
            var kins = await _nextOfKin.GetNextOfKinAsync();
            return Ok(kins);
        }

        [HttpGet]
        [Route("api/get_next_of_kin")]
        public IActionResult GetNextofKin(string id)
        {
            var kin = _nextOfKin.GetNextOfKinAsync(id);
            return Ok(kin);
        }

        [HttpPost]
        [Route("api/create_next_of_kin")]
        public IActionResult CreateNextOfKin([FromBody] NextOfKin nextOfKin)
        {
            var createKin = _nextOfKin.AddNextOfKinAsync(nextOfKin);
            return Ok(createKin);
        }

        [HttpPatch]
        [Route("api/update_next_of_kin")]
        public IActionResult UpdateNextOfKin(string id, [FromBody] NextOfKin nextOfKin)
        {
            var updateKin = _nextOfKin.UpdateNextOfKinAsync(id, nextOfKin);
            return Ok(updateKin);
        }

        [HttpDelete]
        [Route("api/delete_next_of_kin")]
        public IActionResult DeleteNextOfKin(string id)
        {
            var deleteKin = _nextOfKin.DeleteNextOfKinAsync(id);
            return Ok(deleteKin);
        }
    }
}
