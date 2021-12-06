using System.ComponentModel.DataAnnotations;

namespace KinopoiskAPI.Dto.Comment
{
    public class AddComment
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public int MovieId { get; set; }
    }
}