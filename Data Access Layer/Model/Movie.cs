using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Model
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(125)]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy}")]
        public DateTime CreateYear { get; set; }

        [Required]
        public Producer Producer { get; set; }

        [Required]
        public virtual ICollection<Genre> Genres { get; set; }
    }
}