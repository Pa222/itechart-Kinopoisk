using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Entity
{
    public class CreditCard
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(19)]
        public string Number { get; set; }

        [Required]
        [MaxLength(26)]
        public string CardHolderName { get; set; }

        [Required]
        [MaxLength(5)]
        public string Expiry { get; set; }

        [Required]
        [MaxLength(3)]
        public string Cvc { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string Image { get; set; }

        public User User { get; set; }
    }
}