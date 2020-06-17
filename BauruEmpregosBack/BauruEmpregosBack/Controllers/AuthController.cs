using BauruEmpregosBack.Models.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BauruEmpregosBack.Controllers
{

    /// <summary>
    /// Controller que vai logar ou deslogar usuario
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        /// <summary>
        ///  Endpoint de login de usuario
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult AuthLogin([FromBody]User model)
        {
            return Ok();
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