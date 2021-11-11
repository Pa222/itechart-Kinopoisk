using System.Collections.Generic;
using Data_Access_Layer.Model;
using KinopoiskAPI.Dto.CreditCard;

namespace KinopoiskAPI.Dto
{
    public class UserInfoDto
    {
        public string Role { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public List<CreditCardInfoDto> CreditCards { get; set; }
        public string Avatar { get; set; } = "https://res.cloudinary.com/pa2/image/upload/v1636535929/user_fhguim.png";
    }
}