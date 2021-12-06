using System.ComponentModel.DataAnnotations;

namespace KinopoiskAPI.Dto.CreditCard
{
    public class DeleteCreditCardDto
    {
        [Required]
        [MaxLength(19)]
        public string Number { get; set; }
    }
}