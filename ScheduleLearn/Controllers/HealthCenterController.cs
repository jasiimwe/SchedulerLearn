using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScheduleLearnApi.Models;
using ScheduleLearnApi.Models.Interfaces.Service;

namespace ScheduleLearnApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCenterController : ControllerBase
    {
        private readonly IHealthCenter _health;
        public HealthCenterController(IHealthCenter health)
        {
            _health = health;
        }

        [HttpGet]
        [Route("/all_healthcenters")]
        public async Task<IActionResult> ListHealthFacilitiesAsync()
        {
            var facilities = await _health.GetHealthCenterAsync();
            return Ok(facilities);
        }

        [HttpGet]
        [Route("api/get_healthcenter")]
        public async Task<IActionResult> GetSingleHealthCenterAsync(string id)
        {
            var facility = await _health.GetHealthCenterAsync(id);
            return Ok(facility);
        }

        [HttpPost]
        [Route("api/create_health_center")]
        public async Task<IActionResult> CreateHealthCenterAsync([FromBody] HealthCenter healthCenter)
        {
            var facility = await _health.AddHealthCenterAsync(healthCenter);
            return Ok(facility);
        }

        [HttpPatch]
        [Route("api/update_health_center")]
        public async Task<IActionResult> UpdateHealthCenter([FromBody] HealthCenter healthCenter)
        {
            var facility = await _health.UpdateHealthCenterAsync(healthCenter);
            return Ok(facility);
        }
    }
}
