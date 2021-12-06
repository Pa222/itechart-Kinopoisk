using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KinopoiskAPI.Dto.Movie
{
    public class MoviePageDto
    {
        [Required]
        public int PageNumber { get; set; }

        [Required]
        public int TotalPages { get; set; }

        [Required]
        public int PageSize { get; set; } = 8;

        public List<MovieInfoDto> Movies { get; set; }
    }
}