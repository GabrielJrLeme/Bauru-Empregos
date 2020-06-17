using System.Threading.Tasks;
using BauruEmpregosBack.Models;
using BauruEmpregosBack.Services;
using Microsoft.AspNetCore.Mvc;

namespace BauruEmpregosBack.Controllers
{
    [ApiController]
    [Route("api/vacancy")]
    public class VacancyController : ControllerBase
    {

        private readonly VacancyService _services;

        public VacancyController(VacancyService services)
        {
            _services = services;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllVacancyAsync()
            => Ok(await _services.SearchAllVacancyAsync());


        /// <summary>
        /// 
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vaga"></param>
        /// <returns></returns>
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



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="editions"></param>
        /// <returns></returns>
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



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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