using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Entity
{
    public class Comment
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        [Required]
        public int UserId { get; set; }

        public User User { get; set; }
    }
}