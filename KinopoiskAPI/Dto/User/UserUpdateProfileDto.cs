using System.Collections.Generic;
using KinopoiskAPI.Dto.CreditCard;

namespace KinopoiskAPI.Dto.User
{
    public class UserUpdateProfileDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Avatar { get; set; } = "https://res.cloudinary.com/pa2/image/upload/v1636535929/user_fhguim.png";
    }
}