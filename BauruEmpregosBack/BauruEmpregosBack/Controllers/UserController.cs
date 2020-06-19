using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BauruEmpregosBack.Models.Database;
using BauruEmpregosBack.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BauruEmpregosBack.Controllers
{

    [ApiController]
    [Route("api/client")]
    public class UserController : ControllerBase
    {

        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }


        [HttpGet]
        [Route("all")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsersAsync()
            => Ok(_service);


    }
}