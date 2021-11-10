using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Policy;
using System.Threading.Tasks;
using AutoMapper;
using KinopoiskAPI.Dto;
using KinopoiskAPI.Jwt;
using KinopoiskAPI.Services.Interfaces;
using KinopoiskAPI.Utils.Hasher;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace KinopoiskAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("get-user")]
        public async Task<IActionResult> GetUser()
        {
            var user = await _userService.GetUser(User.Identity?.Name);

            var response = new UserInfoDto();
            _mapper.Map(user, response);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("auth")]
        public async Task<IActionResult> Auth([FromBody] UserLoginDto info)
        {
            var user = await _userService.GetUser(info.Email);

            if (user == null || !Hasher.CheckPassword(info.Password, user.Password, user.Salt))
                return Unauthorized();

            var claims = new List<Claim>
            {
                new(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new(ClaimsIdentity.DefaultRoleClaimType, user.Role),
            };

            var identity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.Iss,
                audience: AuthOptions.Aud,
                notBefore: DateTime.UtcNow,
                claims: identity.Claims,
                expires: DateTime.UtcNow.AddMinutes(AuthOptions.LifeTime),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature)
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return Ok(token); ;
        }
    }
}