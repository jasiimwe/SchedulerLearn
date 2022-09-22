using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using ScheduleLearnApi.Models;
using ScheduleLearnApi.Models.Interfaces.Service;
using ScheduleLearnApi.Services;
using ScheduleLearnApi.Utils;
using System.Drawing.Printing;

namespace ScheduleLearnApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccount _accountService;
        
        public AccountController(IAccount accountService)
        {
            _accountService = accountService;
        }

        

        [HttpPost]
        [Route("accounts/signin")]
        public async Task<IActionResult> LoginAsync(string email, string password)
        {
            
            var _login = await _accountService.LoginAsync(email, password);

            return Ok(_login);
        }
        

        [HttpPost]
        [Route("accounts")]
        public IActionResult SaveAccount(string email, string password, string isadmin)
        {
            var _request = Request;
            var headers = _request.Headers;

            /*
            if (!headers.ContainsKey("xlog"))
            {
                return Ok(new { message = "Information is missing (xlog)" });
            }
            */

            var _account = _accountService.Add(email,  password, isadmin);
            
            
            
            return Ok(_account);
        }

        
        [HttpGet]
        [Route("account/{id}/changepassword")]
        public async Task<IActionResult> UpdateAccountPassword(string id, string newPassword)
        {
            var _request = Request;
            var headers = _request.Headers;

            /*
            if (!headers.ContainsKey("xlog"))
            {
                return Ok(new { message = "Information is missing (xlog)" });
            }
            
            var token = headers["xlog"].First();
            if (token != "my api")
            {
                return Ok(new { message = "Information is missing (xlog)" });
            }
            */
            

            var _account = await _accountService.UpdatePasswordAsync(id, newPassword);
            

            return Ok(_account);

        }


        [HttpGet]
        [Route("account/{id}/updateemail")]
        public async Task<IActionResult> UpdateAccountEmaild(string id, string newEmail)
        {
            var _request = Request;
            var headers = _request.Headers;

            /*
            if (!headers.ContainsKey("xlog"))
            {
                return Ok(new { message = "Information is missing (xlog)" });
            }
            
            var token = headers["xlog"].First();
            if (token != "my api")
            {
                return Ok(new { message = "Information is missing (xlog)" });
            }
            */


            var _account = await _accountService.UpdateEmailAsync(id, newEmail);


            return Ok(_account);

        }

        [HttpGet]
        [Route("accounts/{id}")]
        public async Task<IActionResult> GetAccountAsync(string id)
        {
            var _request = Request;
            var headers = _request.Headers;
            /*
            if (!headers.ContainsKey("xlog"))
            {
                return Ok(new { message = "Information is missing (xlog)" });
            }
            
            var token = headers["xlog"].First();
            if (token != "my api")
            {
                return Ok(new { message = "Information is missing (xlog)" });
            }
            */

            var _account = await _accountService.GetAsync(id);

            return Ok(_account);
        }

        [HttpGet]
        [Route("accounts/")]
        public async Task<IActionResult> GetAccountsAsync()
        {
            var _request = Request;
            var headers = _request.Headers;
            /*
            if (!headers.ContainsKey("xlog"))
            {
                return Ok(new { message = "Information is missing (xlog)" });
            }
            
            var token = headers["xlog"].First();
            if (token != "my api")
            {
                return Ok(new { message = "Information is missing (xlog)" });
            }
            */

            var _account = await _accountService.GetAsync();

            return Ok(_account);
        }

        [HttpDelete]
        [Route("api/delete_account")]
        public IActionResult DeleteAccount(string id)
        {
            var _delete = _accountService.Delete(id);
            return Ok(_delete);
        }

        
        
        public class AccountViewModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
        
    }
}
