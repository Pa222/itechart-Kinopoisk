using KinopoiskAPI.Dto.CreditCard;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KinopoiskAPI.Dto.User
{
    public class UserInfoDto
    {
        [Required]
        public string Role { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Avatar { get; set; }

        public List<CreditCardInfoDto> CreditCards { get; set; }
    }
}