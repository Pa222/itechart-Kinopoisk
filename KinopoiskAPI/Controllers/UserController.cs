using System.Threading.Tasks;
using KinopoiskAPI.Dto;
using Microsoft.AspNetCore.Mvc;

namespace KinopoiskAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto info)
        {
            return Ok();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto info)
        {
            return Ok();
        }
    }
}