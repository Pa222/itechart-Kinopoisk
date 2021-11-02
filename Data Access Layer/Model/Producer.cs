using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Model
{
    public class Producer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
    }
}