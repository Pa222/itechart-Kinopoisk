using KinopoiskAPI.Dto.Comment;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KinopoiskAPI.Dto.Movie
{
    public class MovieInfoDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(125)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [MaxLength(4)]
        public string CreateYear { get; set; }

        [Required]
        public string Image { get; set; }

        public List<string> GenreMovies { get; set; }
        public List<CommentInfoDto> Comments { get; set; }
        public List<int> Ratings { get; set; }
    }
}