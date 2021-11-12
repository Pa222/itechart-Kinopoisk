using System.Threading.Tasks;
using KinopoiskAPI.Dto.CreditCard;
using KinopoiskAPI.Services.Interfaces;
using KinopoiskAPI.Utils.CloudinaryApi;
using KinopoiskAPI.Utils.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

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

            var card = await _profileService.AddCreditCard(info, user.Id);
            return Ok(card);
        }
    }
}