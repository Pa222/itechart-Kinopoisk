using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Model
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string CreateYear { get; set; }

        public List<GenreMovie> GenreMovies { get; set; }

        public string Image { get; set; }
    }
}