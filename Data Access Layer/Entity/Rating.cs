using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Entity
{
    public class Rating
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Value { get; set; }

        [Required]
        public int UserId { get; set; }

        public User User { get; set; }

        [Required]
        public int MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}