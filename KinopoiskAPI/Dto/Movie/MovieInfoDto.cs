using KinopoiskAPI.Dto.Comment;
using System.Collections.Generic;

namespace KinopoiskAPI.Dto.Movie
{
    public class MovieInfoDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string CreateYear { get; set; }
        public string Image { get; set; }

        public List<string> GenreMovies { get; set; }

        public List<CommentInfoDto> Comments { get; set; }

        public List<int> Ratings { get; set; }
    }
}