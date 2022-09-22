using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScheduleLearnApi.Models;
using ScheduleLearnApi.Models.Interfaces.Service;

namespace ScheduleLearnApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IDirector _directorService;
        public DirectorController(IDirector directorService)
        {
            _directorService = directorService;
        }

        [HttpGet]
        [Route("directors/")]
        public async Task<IActionResult> ShowDirectorsAsync()
        {
            var _director = await _directorService.GetAsync();
            return Ok(_director);
        }

        [HttpGet]
        [Route("api/get_director")]
        public async Task<IActionResult> GetDirectorAsync(string id)
        {
            var _getDirector = await _directorService.GetAsync(id);
            return Ok(_getDirector);
        }


        [HttpPost]
        [Route("add_director/")]
        public async Task<IActionResult> SaveDirectorAsync(Director director)
        {
            var _director = await _directorService.AddAsync(director);

            return Ok(_director);
        }

        [HttpPatch]
        [Route("update_director/")]
        public async Task<IActionResult> UpdateDirectorAsync(string name, DateTime dob, bool isDeleted)
        {
            var _director = await _directorService.UpdateAsync(name, dob, isDeleted);

            return Ok(_director);
        }

        [HttpDelete]
        [Route("api/delete_director")]
        public IActionResult DeleteDirector(string id)
        {
            var _deleteDirector = _directorService.Delete(id);
            return Ok(_deleteDirector);
        }
    }
}
