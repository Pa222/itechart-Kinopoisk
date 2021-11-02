using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Model
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}