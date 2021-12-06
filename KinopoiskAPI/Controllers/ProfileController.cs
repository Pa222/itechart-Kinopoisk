using KinopoiskAPI.Dto.CreditCard;
using KinopoiskAPI.Dto.User;
using KinopoiskAPI.Services.Interfaces;
using KinopoiskAPI.Utils.CloudinaryApi;
using KinopoiskAPI.Utils.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Threading.Tasks;

namespace KinopoiskAPI.Controllers
{
    [Route("/api/[controller]")]
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;
        private readonly IProfileService _profileService;
        private readonly ICloudinaryApi _cloudinaryApi;

        public ProfileController(IUserService userService, IProfileService profileService, ICloudinaryApi cloudinaryApi)
        {
            _userService = userService;
            _profileService = profileService;
            _cloudinaryApi = cloudinaryApi;
        }

        [Authorize]
        [HttpPost("addCreditCard")]
        public async Task<IActionResult> AddCreditCard([FromBody] AddCreditCard info)
        {
            var token = Request.Headers[HeaderNames.Authorization].ToString();
            var email = JwtDecoder.GetEmail(token);
            var user = await _userService.GetUser(email);

            if (user == null || info == null)
            {
                return BadRequest();
            }

            var cards = await _profileService.AddCreditCard(info, user.Id);

            if (cards == null)
            {
                return BadRequest();
            }
            return Ok(cards);
        }

        [Authorize]
        [HttpDelete("deleteCreditCard")]
        public async Task<IActionResult> DeleteCreditCard([FromBody] DeleteCreditCard info)
        {
            var token = Request.Headers[HeaderNames.Authorization].ToString();
            var email = JwtDecoder.GetEmail(token);
            var user = await _userService.GetUser(email);

            if (user == null || info == null)
            {
                return BadRequest();
            }

            var cards = await _profileService.DeleteCreditCard(info, user.Id);

            if (cards == null)
            {
                return BadRequest();
            }

            return Ok(cards);
        }

        [Authorize]
        [HttpPut("updateUserProfile")]
        public async Task<IActionResult> UpdateUserProfile([FromBody] UserUpdateProfile info)
        {
            var token = Request.Headers[HeaderNames.Authorization].ToString();
            var email = JwtDecoder.GetEmail(token);
            var user = await _userService.GetUser(email);

            if (user == null)
            {
                return BadRequest();
            }

            var updatedUser = await _profileService.UpdateUserProfile(user, info);

            if (updatedUser == null)
            {
                return BadRequest();
            }

            return Ok(updatedUser);
        }
    }
}