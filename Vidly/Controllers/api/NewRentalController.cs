using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.api
{
    public class NewRentalController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public NewRentalController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRentalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (newRentalDto.MovieId.Count == 0)
                return BadRequest("No MovieId Has Been Given.");
            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRentalDto.CustomerId);
            var movies = _context.Movies.Where(c => newRentalDto.MovieId.Contains(c.Id)).ToList();
            if (customer == null )
                return BadRequest("Customer Id Has Invalid");
            if (movies.Count != newRentalDto.MovieId.Count)
                return BadRequest("One Ore More MovieId is Invalid ");
            
            foreach (var movie in movies)
            {
                if (movie.NumberAvalibable == 0)
                    return BadRequest("Movie Is Not Avalible");
                movie.NumberAvalibable--;
                var newRental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(newRental);
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
