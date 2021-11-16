using System.Collections.Generic;

namespace KinopoiskAPI.Dto.Movie
{
    public class MoviePageDto
    {
        public List<MovieInfoDto> Movies { get; set; }

        public int PageNumber { get; set; }
        public int TotalPages { get; set; }

        public int PageSize { get; set; } = 8;
    }
}