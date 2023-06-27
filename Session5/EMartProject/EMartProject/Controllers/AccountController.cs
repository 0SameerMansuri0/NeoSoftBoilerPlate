using EMartProject.Authorization;
using EMartProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMartProject.Controllers
{
    
    [ApiController]
    public class AccountController : ControllerBase
    {
        readonly IAuthManager _authManager;
        public AccountController(IAuthManager authManager)
        {
           _authManager = authManager;
        }

        [Route("api/Register")]
        [HttpPost]
        public async Task<ActionResult> Register(UserDto userDto)
        {
            var error=await _authManager.RegisterUser(userDto);
            if(error.Any())
            {
                foreach (var item in error)
                {
                    ModelState.AddModelError(item.Code,item.Description);
                }

                return BadRequest(error);
            }
           return Ok();
        }

        [Route("api/Login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var Response= await _authManager.Login(loginDto);  
            if(Response==null)
            {
                return Unauthorized();
            }
            else
                return Ok(Response);
        }


    }
}
