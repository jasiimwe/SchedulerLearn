using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScheduleLearnApi.Models;
using ScheduleLearnApi.Models.Interfaces.Service;

namespace ScheduleLearnApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }

        [HttpGet]
        [Route("api/all_users")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var allUsers = await _user.GetUserAsync();
            return Ok(allUsers);
        }

        [HttpGet]
        [Route("api/get_user")]
        public async Task<IActionResult> GetUserAsync(string id)
        {
            var getUsers = await _user.GetUserAsync(id);
            return Ok(getUsers);
        }

        [HttpPost]
        [Route("api/create_user")]
        public async Task<IActionResult> CreateUserAsync([FromBody]User user)
        {
            var createUser = await _user.AddUserAsync(user);
            return Ok(createUser);
        }

        [HttpPatch]
        [Route("api/update_user")]
        public async Task<IActionResult> UpdateUserAsync(string id, [FromBody]User user)
        {
            var updateUser = await _user.UpdateUserAsync(id, user);
            return Ok(updateUser);
        }

        [HttpDelete]
        [Route("api/delete_user")]
        public async Task<IActionResult> DeleteUserAsync(string id)
        {
            var deleteUser = await _user.DeleteUserAsync(id);
            return Ok(deleteUser);
        }
    }
}
