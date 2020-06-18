using BauruEmpregosBack.Models.Database;
using BauruEmpregosBack.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BauruEmpregosBack.Controllers
{

    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {

        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }



        [HttpPost("{model}")]
        public async Task<IActionResult> PostCreateUserLoginAsync(User model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("");
            }

            User user = await _service.CreateUserLoginAsync(model);

            if(user == null)
            {
                return BadRequest();
            }

            return Created("Usuario criado", user);
        }


    }
}