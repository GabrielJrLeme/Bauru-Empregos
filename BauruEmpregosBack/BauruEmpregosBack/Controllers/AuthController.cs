using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BauruEmpregosBack.Models.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BauruEmpregosBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {


        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Auth([FromBody]User model)
        {
            return Ok();
        }


    }
}