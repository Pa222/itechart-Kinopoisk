using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace KinopoiskAPI.Utils.Jwt
{
    public static class JwtDecoder
    {
        public static string GetEmail(string token)
        {
            var jsonToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            return jsonToken.Claims.First(claim => claim.Type == ClaimsIdentity.DefaultNameClaimType).Value;
        }
    }
}