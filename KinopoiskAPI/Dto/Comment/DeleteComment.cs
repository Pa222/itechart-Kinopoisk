using System.ComponentModel.DataAnnotations;

namespace KinopoiskAPI.Dto.Comment
{
    public class DeleteComment
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int MovieId { get; set; }
    }
}