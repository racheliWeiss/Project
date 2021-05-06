using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Repositories;
using Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeController : Controller
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
         //The function Login to server with jwt 
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
            int permission =Manager.Manager.Login(model);

            if (permission == 2)

                return NotFound(new { message = "User or password invalid" });
            
            var token = TokenService.CreateToken(model);
            model.login_password = "";
            return new
            {
                user = model,
                token = token
            };
        }
    }
}

