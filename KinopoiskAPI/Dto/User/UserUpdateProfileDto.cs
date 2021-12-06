using System.ComponentModel.DataAnnotations;

namespace KinopoiskAPI.Dto.User
{
    public class UserUpdateProfileDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Gender { get; set; }
    }
}