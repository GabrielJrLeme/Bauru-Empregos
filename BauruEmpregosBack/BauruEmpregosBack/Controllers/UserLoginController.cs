using BauruEmpregosBack.Models.Database;
using BauruEmpregosBack.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BauruEmpregosBack.Controllers
{
    /// <summary>
    /// Rota de configurações do usuario Role user
    /// </summary>
    [ApiController]
    [Route("api/user")]
    public class UserLoginController : ControllerBase
    {

        private readonly UserLoginService _service;

        public UserLoginController(UserLoginService service)
        {
            _service = service;
        }



        [HttpPost("{model}")]
        public async Task<IActionResult> PostCreateUserLoginAsync(User model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Corpo invalido");
            }

            if(!await _service.CreateUserLoginAsync(model))
                return BadRequest("Este usuario ja existe");

            return Created("Usuario criado com sucesso", model);
        }


        [HttpPut("{model}")]
        public async Task<IActionResult> PutEditUserLoginAsync(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Corpo invalido");
            }

            await _service.ChengeUserLoginAsync(user);

            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("Corpo invalido");
            }

            await _service.DeleteUserLogin(id);

            return Ok();
        }

    }
}