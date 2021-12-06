using System.ComponentModel.DataAnnotations;

namespace KinopoiskAPI.Dto.CreditCard
{
    public class AddCreditCardDto
    {
        [Required]
        [MaxLength(19)]
        public string Number { get; set; }

        [Required]
        [MaxLength(5)]
        public string Expiry { get; set; }

        [Required]
        [MaxLength(26)]
        public string CardHolderName { get; set; }

        [Required]
        [MaxLength(3)]
        public string Cvc { get; set; }

        [Required]
        public string Issuer { get; set; }
    }
}