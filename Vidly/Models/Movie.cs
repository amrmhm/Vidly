using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]

        [Display(Name = "Relase Date")]
        public string RelaseDate { get; set; }
       
        [Display(Name = "Date Added")]

        public string DateAdded { get; set; }
        [Required]
        [Display(Name = "Number Of Stock")]

        public byte NumberOfStock { get; set; }  
        [Required]
        [Display(Name = "Number Avalibable")]

        public byte NumberAvalibable { get; set; } 

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]

        public byte GenreId { get; set; }
    }
}