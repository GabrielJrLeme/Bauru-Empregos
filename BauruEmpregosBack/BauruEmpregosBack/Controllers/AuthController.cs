using System.Threading.Tasks;
using BauruEmpregosBack.Models.Database;
using BauruEmpregosBack.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BauruEmpregosBack.Controllers
{

    [ApiController]
    [Route("api/auth")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _auth;

        public AuthController(AuthService auth)
        {
            _auth = auth;
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AuthenticateAsync([FromBody] UserLogin model)
        {

            if (!ModelState.IsValid || (string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Login)) && string.IsNullOrWhiteSpace(model.Password))
                return BadRequest("Modelo invalido");

            if (!await _auth.IsValidLoginAsync(model))
                return NotFound("Este usuario não existe");

            model.Token = _auth.AddToken(model);

            return Created("Usuario Logado", model);
        }

    }
}