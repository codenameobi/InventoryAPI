using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryAPI.DTOs.Authentication;
using InventoryAPI.Models;
using InventoryAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthenticationController : Controller
	{
        private readonly IAuthManager authManager;

        public AuthenticationController(IAuthManager authManager)
		{
            this.authManager = authManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult> PostEvent(LoginDto loginDto)
        {

            var response = await authManager.Login(loginDto);

            if(response is null)
            {
                return Unauthorized();
            }
            return Ok(response);
        }
    }
}

