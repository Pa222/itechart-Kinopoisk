using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KinopoiskAPI.Dto
{
    public class MovieInfoDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(125)]
        public string Title { get; set; }

        public string Description { get; set; }

        public string CreateYear { get; set; }

        public List<string> GenreMovies { get; set; }

        public string Image { get; set; }
    }
}