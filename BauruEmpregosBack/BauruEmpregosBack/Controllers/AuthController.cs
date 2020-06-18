using BauruEmpregosBack.Models.Database;
using BauruEmpregosBack.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BauruEmpregosBack.Controllers
{

    /// <summary>
    /// Controller que vai logar ou deslogar usuario
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly AuthService _service;

        public AuthController(AuthService service)
        {
            _service = service;
        }



        /// <summary>
        ///  Endpoint de login de usuario
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> AuthLoginAsync([FromBody]User model)
        {

            if (!ModelState.IsValid)
                return BadRequest("Dados invalidos");

            User user = await _service.LoginUserAsync(model);

            if (user == null)
                return NotFound();

            return Ok(user);
        }


        /// <summary>
        /// Endpoint que vai deslogar o usuario
        /// </summary>
        /// <returns></returns>
        public IActionResult DestroyLogin()
        {
            return Ok();
        }

    }
}