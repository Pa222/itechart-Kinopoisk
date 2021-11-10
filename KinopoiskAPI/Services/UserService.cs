﻿using AutoMapper;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Model;
using KinopoiskAPI.Dto;
using KinopoiskAPI.Jwt;
using KinopoiskAPI.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using KinopoiskAPI.Utils.Hasher;

namespace KinopoiskAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private const string _defaultAvatar =
            "https://res.cloudinary.com/pa2/image/upload/v1636538257/kbroom135_gmail.com_xw2qe1.jpg";

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<User> GetUser(string email)
        {
            return await _unitOfWork.Users.GetByEmail(email);
        }

        public string GetToken(User user)
        {
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

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public UserInfoDto GetUserInfo(User user)
        {
            var result = new UserInfoDto();
            _mapper.Map(user, result);
            return result;
        }

        public async Task<bool> AddUser(UserRegisterDto info)
        {
            var salt = Hasher.GetSalt();
            return await _unitOfWork.Users.Create(new User()
            {
                Name = info.Name,
                Email = info.Email,
                Salt = salt,
                Password = Hasher.GetHash(info.Password, salt),
                Avatar = _defaultAvatar,
                Role = Role.User.ToString(),
            });
        }
    }
}