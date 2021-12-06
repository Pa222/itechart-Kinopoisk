using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Entity
{
    public class GenreMovie
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public int MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}