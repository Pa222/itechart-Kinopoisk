using AutoMapper;
using Data_Access_Layer.Entity;
using Data_Access_Layer.Interfaces;
using KinopoiskAPI.Dto.CreditCard;
using KinopoiskAPI.Dto.User;
using KinopoiskAPI.Services.Interfaces;
using KinopoiskAPI.Utils.Hasher;
using KinopoiskAPI.Utils.Jwt;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KinopoiskAPI.Services
{
    public class UserService : GenericService, IUserService
    {
        private readonly IMapper _mapper;

        private const string DefaultAvatar = "https://res.cloudinary.com/pa2/image/upload/v1636535929/UserAvatars/user_fhguim.png";

        public UserService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task<User> GetUser(string email)
        {
            return await UnitOfWork.Users.GetByEmail(email);
        }

        public string GetToken(User user)
        {
            var claims = new List<Claim>
            {
                new(ClaimsIdentity.DefaultNameClaimType, user.Email),
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

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public UserInfoDto GetUserInfo(User user)
        {
            var result = new UserInfoDto
            {
                CreditCards = new List<CreditCardInfoDto>()
            };

            _mapper.Map(user, result);
            _mapper.Map(user.Cards, result.CreditCards);

            return result;
        }

        public async Task<User> AddUser(UserRegisterDto info)
        {
            var salt = Hasher.GetSalt();
            return await UnitOfWork.Users.Create(new User()
            {
                Name = info.Name,
                Email = info.Email,
                Salt = salt,
                Password = Hasher.GetHash(info.Password, salt),
                Avatar = DefaultAvatar,
                Role = Role.User.ToString(),
                Gender = Gender.Undefined.ToString(),
            });
        }

        public async Task<User> UpdateUser(User user)
        {
            return await UnitOfWork.Users.Update(user);
        }
    }
}