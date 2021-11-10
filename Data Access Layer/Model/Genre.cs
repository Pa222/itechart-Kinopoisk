using System.Collections.Generic;

namespace Data_Access_Layer.Model
{
    public class Genre
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<GenreMovie> GenreMovies { get; set; }
    }
}