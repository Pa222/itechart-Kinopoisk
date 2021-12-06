using System.ComponentModel.DataAnnotations;

namespace KinopoiskAPI.Dto.Rating
{
    public class UpdateRating
    {
        [Required]
        public int Value { get; set; }

        [Required]
        public int MovieId { get; set; }
    }
}