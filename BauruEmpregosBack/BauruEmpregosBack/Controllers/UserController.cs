﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BauruEmpregosBack.Models.Database;
using BauruEmpregosBack.Services;
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


        /*
        public async Task<IActionResult> PostCreateUserLoginAsync(UserLogin model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Dados incompletos");
            }

            // verificar se está logado


            //if (!await _service.CreateUserAsync(model))
                return NotFound("Houve um erro ao recarregar a página");

            return Created("Usuario criado com sucesso",model);
        }*/



    }
}