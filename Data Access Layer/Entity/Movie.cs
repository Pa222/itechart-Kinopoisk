using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Entity
{
    public class Movie
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

        public List<GenreMovie> GenreMovies { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Rating> Ratings { get; set; }
    }
}