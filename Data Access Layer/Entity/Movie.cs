using System.Collections.Generic;

namespace Data_Access_Layer.Entity
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreateYear { get; set; }
        public string Image { get; set; }
        public List<GenreMovie> GenreMovies { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Rating> Ratings { get; set; }
    }
}