using System;
using System.IO;
using KinopoiskAPI.Dto;
using KinopoiskAPI.Services.Interfaces;
using KinopoiskAPI.Utils.Hasher;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using KinopoiskAPI.Utils.Jwt;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

namespace KinopoiskAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet("get-user")]
        public async Task<IActionResult> GetUser()
        {
            var token = Request.Headers[HeaderNames.Authorization].ToString();
            var email = JwtDecoder.GetEmail(token[7..]);
            var user = await _userService.GetUser(email);

            if (user == null)
                return Unauthorized();

            return Ok(_userService.GetUserInfo(user));
        }

        [Authorize]
        [HttpPost("upload-avatar")]
        public async Task<IActionResult> UploadAvatar()
        {
            try
            {
                var file = Request.Form.Files[0];
                if (file.Length > 0)
                {
                    //TODO: UPLOAD FILE TO CLOUDINARY
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("auth")]
        public async Task<IActionResult> Auth([FromBody] UserLoginDto info)
        {
            if (info == null)
                return BadRequest();

            var user = await _userService.GetUser(info.Email);

            if (user == null || !Hasher.CheckPassword(info.Password, user.Password, user.Salt))
                return Unauthorized();

            return Ok(_userService.GetToken(user));
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto info)
        {
            if (info == null)
                return BadRequest();

            var user = await _userService.GetUser(info.Email);
            if (user != null)
                return BadRequest();

            if (await _userService.AddUser(info))
                return Ok();
            return BadRequest();
        }
    }
}