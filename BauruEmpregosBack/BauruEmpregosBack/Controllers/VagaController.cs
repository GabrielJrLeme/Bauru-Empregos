using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BauruEmpregosBack.Models;
using BauruEmpregosBack.Services;
using Microsoft.AspNetCore.Mvc;

namespace BauruEmpregosBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VagaController : ControllerBase
    {


        private readonly VagaServices _services;

        public VagaController(VagaServices services)
        {
            _services = services;
        }


        [HttpGet]
        public IActionResult Index()
        {

            List<Vagas> list = _services.ListAllVagas();

            return Ok(list);
        }
    }
}