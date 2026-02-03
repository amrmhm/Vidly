using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        //public ActionResult Random()

        //{
        //    var movie = new Movie()
        //    {
        //        Name = "Amer!"
        //    };
        //    //ViewBag.movie = movie;
        //    //var viewResualt = new ViewResult();
        //    //viewResualt.ViewData.Model
        //    return View();
        //    //return Content("Hello World!");
        //    //return RedirectToAction("Index", "Home", new { Id = 1, Name = "Amer" });
        //    //return new EmptyResult();
        //    //return HttpNotFound();
        //}
        //public ActionResult Edit (int id)
        //{
        //    return Content("id = " + id) ;
        //}
        //public ActionResult Index(int?  pageIndex ,string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (string.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";
        //    return Content(string.Format("pageIndex = {0} & sortBy = {1}", pageIndex, sortBy));
        //}
        //[Route("movies/relesed/{year}/{month:regex(\\d{2}):range(1,12)}")]
        //public ActionResult ByRelesedDate(int year , int month)
        //{
        //    return Content(year + "/" + month);
        //}
        //public ActionResult Random()

        //{
        //    var movie = new Movie()
        //    {
        //        Name = "Amer!"
        //    };
        //    var customer = new List<Customer>()
        //    {
        //        new Customer(){Name = "Customer 1"},
        //        new Customer(){Name = "Customer 2"}
        //    };
        //    var viewModel = new RandomMovieViewModel()
        //    {
        //        Movie = movie ,
        //        Customer = customer
        //    };


        //    return View(viewModel);

        //}
        public ActionResult Index()
        {

            if (User.IsInRole(RoleName.CanManageMovie))
                return View(nameof(List));
            return View(nameof( ReadOnlyList));
        }

        [Authorize(Roles = RoleName.CanManageMovie)]
        public ActionResult List()
        {

          
            return View();
        }
        public ActionResult ReadOnlyList()
        {


            return View();
        }

        [Authorize(Roles = RoleName.CanManageMovie)]
        public ActionResult Details(int id )
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        [Authorize(Roles = RoleName.CanManageMovie)]
        public ActionResult MovieForm()
        {
            var viewModel = new MovieFormViewModel() {
               
                Genre = _context.Genres.ToList() 
                
                                        };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovie)]
        public ActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                
                var viewmodel = new MovieFormViewModel(movie)
                {

                    Genre = _context.Genres.ToList()
                };

                return View(nameof(MovieForm), viewmodel);

            }
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieIdDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieIdDb.Name = movie.Name;
                movieIdDb.RelaseDate = movie.RelaseDate;
                movieIdDb.DateAdded = movie.DateAdded;
                movieIdDb.GenreId = movie.GenreId;
            }
          
                _context.SaveChanges();
            
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles =RoleName.CanManageMovie)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();
            var viewModel = new MovieFormViewModel(movie)
            {
                
            

                Genre = _context.Genres.ToList()
            };

            return View(nameof(MovieForm), viewModel);
        }
    }
}