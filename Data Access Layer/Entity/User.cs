using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Entity
{
    public class User
    {
        [Required]
        public int Id { get; set; }

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
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public byte[] Salt { get; set; }

        [Required]
        public string Avatar { get; set; }

        public List<CreditCard> Cards { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Rating> Ratings { get; set; }
    }
}