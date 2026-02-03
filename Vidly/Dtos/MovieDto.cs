using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {

        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]

        public string RelaseDate { get; set; }

        public string DateAdded { get; set; }
        [Required]
       
        public byte NumberOfStock { get; set; }

        public GenreDto Genre { get; set; }

        public byte GenreId { get; set; }
    }
}