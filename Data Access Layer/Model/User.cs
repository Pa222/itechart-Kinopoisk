using System.Collections.Generic;

namespace Data_Access_Layer.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
        public string Avatar { get; set; } = "https://res.cloudinary.com/pa2/image/upload/v1636535929/user_fhguim.png";
        public List<CreditCard> Cards { get; set; }
        public List<Comment> Comments { get; set; }
    }
}