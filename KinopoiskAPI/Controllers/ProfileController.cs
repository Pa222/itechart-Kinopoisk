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
        [HttpPost("add-credit-card")]
        public async Task<IActionResult> AddCreditCard([FromBody] AddCreditCardDto info)
        {
            var token = Request.Headers[HeaderNames.Authorization].ToString();
            var email = JwtDecoder.GetEmail(token[7..]);
            var user = await _userService.GetUser(email);

            if (user == null || info == null)
                return BadRequest();

            var cards = await _profileService.AddCreditCard(info, user.Id);
            return Ok(cards);
        }

        [Authorize]
        [HttpDelete("delete-credit-card")]
        public async Task<IActionResult> DeleteCreditCard([FromBody] DeleteCreditCardDto info)
        {
            var token = Request.Headers[HeaderNames.Authorization].ToString();
            var email = JwtDecoder.GetEmail(token[7..]);
            var user = await _userService.GetUser(email);

            if (user == null || info == null)
                return BadRequest();

            var cards = await _profileService.DeleteCreditCard(info, user.Id);

            return Ok(cards);
        }

        [Authorize]
        [HttpPut("update-user-profile")]
        public async Task<IActionResult> UpdateUserProfile([FromBody] UserUpdateProfileDto info)
        {
            var token = Request.Headers[HeaderNames.Authorization].ToString();
            var email = JwtDecoder.GetEmail(token[7..]);
            var user = await _userService.GetUser(email);
            var updatedUser = await _profileService.UpdateUserProfile(user, info);
            return Ok(updatedUser);
        }
    }
}