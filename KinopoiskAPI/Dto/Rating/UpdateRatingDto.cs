using System.ComponentModel.DataAnnotations;

namespace KinopoiskAPI.Dto.Rating
{
    public class UpdateRatingDto
    {
        [Required]
        public int Value { get; set; }

        [Required]
        public int MovieId { get; set; }
    }
}