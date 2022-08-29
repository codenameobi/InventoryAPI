using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthenticationController : Controller
	{
        private readonly UserManager<User> userManager;

        public AuthenticationController(UserManager<User> userManager)
		{
            this.userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult> PostEvent(LoginDto loginDto)
        {
            var user = await userManager.FindByEmailAsync(loginDto.UserName);
            if(user is null)
            {
                return Unauthorized();
            }
            bool isValidCredentials = await userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!isValidCredentials)
            {
                return Unauthorized();
            }

            //Generate Token Here...

            return Ok();
        }
    }

    public class LoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

