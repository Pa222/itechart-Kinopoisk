﻿using System.ComponentModel.DataAnnotations;

namespace KinopoiskAPI.Dto.User
{
    public class UserLoginDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}