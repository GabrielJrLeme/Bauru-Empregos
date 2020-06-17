using System.Threading.Tasks;
using BauruEmpregosBack.Models;
using BauruEmpregosBack.Services;
using Microsoft.AspNetCore.Mvc;

namespace BauruEmpregosBack.Controllers
{


    /// <summary>
    /// Controller de manipulação de oportunidades 
    /// </summary>
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
        /// Pegar todas as oportunidades ativas ou não
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        [Route("allVacancys")]
        public IActionResult AllVacancyAsync()
            => Ok();


        /// <summary>
        /// Pegar todas as oportunidades ativas no sistema
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllVacancyAsync()
            => Ok(await _services.SearchAllVacancyAsync());


        /// <summary>
        /// Pegar uma oportunidade especifica ativa no sistema
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

            Vacancy vaga = await _services.SearchOneVacancySlugAsync(slug);

            if (vaga.Equals(null))
                return Ok("Vaga inesistente");

            return Ok(vaga);
        }


        /// <summary>
        /// Gerar uma nova oportunidade
        /// </summary>
        /// <param name="vaga"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> PostNewVacancyAsync([FromBody] Vacancy model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Modelo Invalido");
            }

            await _services.NewVacancyAsync(model);

            return Created("Oportunidade gerada",model);
        }



        /// <summary>
        /// Edições de oportunidade
        /// </summary>
        /// <param name="id"></param>
        /// <param name="editions"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> PutVacancyAsync(string id,[FromBody]Vacancy editions)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("Id Nulo");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Modelo Invalido");
            }

            Vacancy vaga = await _services.SearchOneVacancyIdAsync(id);

            if (vaga.Equals(null))
            {
                return NotFound("Vaga inesistente");
            }

            await _services.ChangeOneVacancyAsync(vaga, editions);

            return Ok("Ok");
        }



        /// <summary>
        /// Oculta a oportunidade desejada
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

            Vacancy vaga = await _services.SearchOneVacancyIdAsync(id);

            if (vaga.Equals(null))
            {
                return NotFound("Vaga inesistente");
            }

            await _services.DeleteOneVacancyAsync(vaga);

            return Ok("Ok");
        }


    }
}