using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class MovieFormViewModel
    {
        [Required]
        public int? Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Relase Date")]
        public string RelaseDate { get; set; } 


        [Required]
        [Range(1,20)]
        [Display(Name = "Number Of Stock")]

        public byte? NumberOfStock { get; set; } 

    

        [Display(Name = "Genre")]
        [Required]

        public byte? GenreId { get; set; }

        public List<Genre> Genre { get; set; }

        public string Title
        {
            get { if ( Id != 0)
                    return "Edit Movie";
                    return "New Movie";
               
                        }
        }
        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            RelaseDate = movie.RelaseDate;
            NumberOfStock = movie.NumberOfStock;
            GenreId = movie.GenreId;
        }
    }
}