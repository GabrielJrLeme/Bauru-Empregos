﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BauruEmpregosBack.Models;
using BauruEmpregosBack.Services;
using Microsoft.AspNetCore.Mvc;

namespace BauruEmpregosBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VagaController : ControllerBase
    {


        private readonly Vacancy _services;

        public VagaController(Vacancy services)
        {
            _services = services;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllVacancyAsync()
            => Ok(await _services.SearchAllVacancyAsync());


        [HttpGet("{slug}")]
        public async Task<IActionResult> GetOneVacancyAsync(int slug)
        {           

            if (slug.Equals(0) || slug.Equals(null))
            {
                return BadRequest("Slug Nulo");
            }

            Vacancys vaga = await _services.SearchOneVacancySlugAsync(slug);

            if (vaga.Equals(null))
                return Ok("Vaga inesistente");

            return Ok(vaga);
        }


        [HttpPost]
        public async Task<ActionResult> PostNewVacancyAsync([FromBody] Vacancys vaga)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Modelo Invalido");
            }

            await _services.NewVacancyAsync(vaga);

            return Ok("Ok");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutVacancyAsync(string id,[FromBody]Vacancys editions)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("Id Nulo");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Modelo Invalido");
            }

            Vacancys vaga = await _services.SearchOneVacancyIdAsync(id);

            if (vaga.Equals(null))
            {
                return NotFound("Vaga inesistente");
            }

            await _services.ChangeOneVacancyAsync(vaga, editions);

            return Ok("Ok");
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVacancyAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("Id Nulo");
            }

            Vacancys vaga = await _services.SearchOneVacancyIdAsync(id);

            if (vaga.Equals(null))
            {
                return NotFound("Vaga inesistente");
            }

            await _services.DeleteOneVacancyAsync(vaga);

            return Ok("Ok");
        }

    }
}