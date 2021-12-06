using System.ComponentModel.DataAnnotations;

namespace KinopoiskAPI.Dto.Comment
{
    public class AddCommentDto
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public int MovieId { get; set; }
    }
}