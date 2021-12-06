using System.ComponentModel.DataAnnotations;

namespace KinopoiskAPI.Dto.Comment
{
    public class CommentInfo
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string UserAvatar { get; set; }
    }
}