using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Entity
{
    public class Faq
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }
    }
}