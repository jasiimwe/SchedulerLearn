using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScheduleLearnApi.Models;
using ScheduleLearnApi.Models.Interfaces.Service;

namespace ScheduleLearnApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WardController : ControllerBase
    { 

        private readonly IWard _ward;
        public WardController(IWard ward)
        {
            _ward = ward;
        }

        [HttpGet]
        [Route("api/all_wards")]
        public async Task<IActionResult> GetAllWardsAsync()
        {
            var allWards = await _ward.GetWardAsync();
            return Ok(allWards);
        }

        [HttpGet]
        [Route("api/get_ward")]
        public async Task<IActionResult> GetWard(string id)
        {
            var getWard = await _ward.GetWardAsync(id);
            return Ok(getWard);
        }

        [HttpPost]
        [Route("api/create_ward")]
        public async Task<IActionResult> CreateWardAsync([FromBody] Ward ward)
        {
            var createWard = await _ward.AddWardAsync(ward);
            return Ok(createWard);
        }

        [HttpPatch]
        [Route("api/update_ward")]
        public async Task<IActionResult> UpdateWard(string id, [FromBody] Ward ward)
        {
            var updateWard = await _ward.UpdateWardAsync(id, ward);
            return Ok(updateWard);
        }

        [HttpDelete]
        [Route("api/delete_ward")]
        public async Task<IActionResult> DeleteWardAsync(string id)
        {
            var deleteWard = await _ward.DeleteWardAsync(id);
            return Ok(deleteWard);
        }
    }
}
