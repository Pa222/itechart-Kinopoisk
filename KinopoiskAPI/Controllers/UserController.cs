using KinopoiskAPI.Dto.User;
using KinopoiskAPI.Services.Interfaces;
using KinopoiskAPI.Utils.CloudinaryApi;
using KinopoiskAPI.Utils.Hasher;
using KinopoiskAPI.Utils.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace KinopoiskAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICloudinaryApi _cloudinaryApi;

        public UserController(IUserService userService, ICloudinaryApi cloudinaryApi)
        {
            _userService = userService;
            _cloudinaryApi = cloudinaryApi;
        }

        private static string GetAuthorizationHeader(HttpRequest request)
        {
            return request.Headers[HeaderNames.Authorization].ToString();
        }

        [Authorize]
        [HttpGet("getUser")]
        public async Task<IActionResult> GetUser()
        {
            var token = GetAuthorizationHeader(Request);
            var email = JwtDecoder.GetEmail(token);
            var user = await _userService.GetUser(email);

            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(_userService.GetUserInfo(user));
        }

        [Authorize]
        [HttpPost("uploadAvatar")]
        public async Task<IActionResult> UploadAvatar()
        {
            var token = GetAuthorizationHeader(Request);
            var email = JwtDecoder.GetEmail(token);
            var user = await _userService.GetUser(email);

            if (await _userService.GetUser(email) == null)
            {
                return Unauthorized();
            }

            try
            {
                var file = Request.Form.Files[0];
                if (file.Length <= 0)
                {
                    return BadRequest();
                }

                var fileUrl = await _cloudinaryApi.UploadFile(file, email);

                if (fileUrl == null)
                {
                    return BadRequest();
                }

                user.Avatar = fileUrl;

                var updUser = await _userService.UpdateUser(user);
                if (updUser != null)
                {
                    return Ok(_userService.GetUserInfo(updUser));
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpPost("auth")]
        public async Task<IActionResult> Auth([FromBody] UserLogin info)
        {
            if (info == null)
            {
                return BadRequest();
            }

            var user = await _userService.GetUser(info.Email);

            if (user == null || !Hasher.CheckPassword(info.Password, user.Password, user.Salt))
            {
                return Unauthorized();
            }

            return Ok(_userService.GetToken(user));
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegister info)
        {
            if (info == null)
            {
                return BadRequest();
            }

            var user = await _userService.GetUser(info.Email);
            if (user != null)
            {
                return BadRequest();
            }

            return Ok(await _userService.AddUser(info));
        }
    }
}