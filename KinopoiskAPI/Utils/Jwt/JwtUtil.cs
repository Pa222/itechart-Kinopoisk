using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace KinopoiskAPI.Jwt
{
    public class JwtUtil
    {
        public Dictionary<string, string> DecodeJwt(IHttpContextAccessor _httpContextAccessor)
        {
            var accessToken = (_httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString())?[7..];
            var handler = new JwtSecurityTokenHandler();
            var tokenS = handler.ReadJwtToken(accessToken) as JwtSecurityToken;
            var idUser = tokenS.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.NameId).Value;
            var email = tokenS.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Email).Value;
            var data = new Dictionary<string, string>{
                {"idUser", idUser},
                {"Email", email},
            };
            return data;
        }
    }
}