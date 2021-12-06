using System.ComponentModel.DataAnnotations;

namespace KinopoiskAPI.Dto.Comment
{
    public class DeleteCommentDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int MovieId { get; set; }
    }
}