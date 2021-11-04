using System.Collections.Generic;

namespace KinopoiskAPI.Dto
{
    public class MoviePageDto
    {
        public List<MovieInfoDto> Movies { get; set; }

        public int PageNumber { get; set; }
        public int TotalPages { get; set; }

        public static readonly int PageSize = 8;
    }
}