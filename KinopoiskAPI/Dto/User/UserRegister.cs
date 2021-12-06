using System.ComponentModel.DataAnnotations;

namespace KinopoiskAPI.Dto.User
{
    public class UserRegister
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}