using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Rental
    {
        public byte Id { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
        [Requierd]
        public Customer Customer { get; set; }
        [Requierd]
        public Movie Movie { get; set; }

    }
}