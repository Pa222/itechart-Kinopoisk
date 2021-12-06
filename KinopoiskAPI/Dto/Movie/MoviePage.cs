using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KinopoiskAPI.Dto.Movie
{
    public class MoviePage
    {
        [Required]
        public int PageNumber { get; set; }

        [Required]
        public int TotalPages { get; set; }

        [Required]
        public int PageSize { get; set; } = 8;

        public List<MovieInfo> Movies { get; set; }
    }
}