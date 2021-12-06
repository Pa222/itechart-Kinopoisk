using System.ComponentModel.DataAnnotations;

namespace KinopoiskAPI.Dto.CreditCard
{
    public class DeleteCreditCard
    {
        [Required]
        [MaxLength(19)]
        public string Number { get; set; }
    }
}