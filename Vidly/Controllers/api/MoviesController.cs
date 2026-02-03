using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.api
{
    public class MoviesController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [HttpGet]
        public IHttpActionResult GetMovie (string query = null)
        {
            var movieQuery = _context.Movies.Include(c => c.Genre);

            if (!string.IsNullOrWhiteSpace(query))
                movieQuery = movieQuery.Where(c => c.Name.Contains(query));
            var movie =  movieQuery.Select(Mapper.Map<Movie , MovieDto>).ToList();


            return Ok(movie);
        }
        [HttpGet]

        public IHttpActionResult GetMovie (int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return NotFound();
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }
        [HttpPost]
        [Authorize(Roles =RoleName.CanManageMovie)]
        public IHttpActionResult CreateMovie (MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return NotFound();
           var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id),movie);

           
        }
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovie)]

        public IHttpActionResult UpdateMovie (int id ,MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                return NotFound();
           var movieDb =  Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();
            return Ok(movieDb);

        }
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovie)]

        public IHttpActionResult DeleteMovie (int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                return NotFound();
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
            return Ok (Mapper.Map<Movie, MovieDto>(movieInDb));
        }
    }
}
