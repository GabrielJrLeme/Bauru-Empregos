using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BauruEmpregosBack.Models.Database;
using BauruEmpregosBack.Services;
using Microsoft.AspNetCore.Mvc;

namespace BauruEmpregosBack.Controllers
{

    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {

        private readonly AdminService _service;

        public AdminController(AdminService service)
        {
            _service = service;
        }


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> PostCreateUserLoginAsync(UserAdmin model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Dados incompletos");
            }

            // verificar se está logado


            if (!await _service.CreateUserAsync(model))
                return NotFound("Houve um erro ao recarregar a página");

            return Created("Usuario criado com sucesso", model);
        }


    }
}