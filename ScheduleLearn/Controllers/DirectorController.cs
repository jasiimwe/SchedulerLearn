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
            return Ok(new { _director.message, data = _director.directors, _director.check });
        }

        [HttpPost]
        [Route("add_director/")]
        public async Task<IActionResult> SaveDirectorAsync(Director director)
        {
            var _director = await _directorService.AddAsync(director);

            return Ok(new {_director.director, _director.message, _director.check});
        }

        [HttpPost]
        [Route("update_director/")]
        public async Task<IActionResult> UpdateDirectorAsync(string name, DateTime dob, bool isDeleted)
        {
            var _director = await _directorService.UpdateAsync(name, dob, isDeleted);

            return Ok(new { _director.director, _director.message, _director.check });
        }
    }
}
