using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyNew.Models;
using VidlyNew.ViewModel;
using System.Data.Entity;

namespace VidlyNew.Controllers
{
    public class MoviesController : Controller
    {
        public ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Random()
        {
            var movie = _context.Movies.Where<Movie>(m => m.Id == 1).FirstOrDefault();
            var customers = _context.Customers.ToList();

            var randomviewmodel = new RandomMovieViewModel()
            {
                customers = customers,
                movie = movie,
            };

            return View(randomviewmodel);
        }

        
        public ActionResult Index()
        {
            if (User.IsInRole(RoleNames.canManageMovies))
                return View("Index");

                return View("ReadOnlyList");
        }

        [Route("movies/released/{year}/{month:regex(\\d{2})}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Details(int Id)
        {
            var selectedMovie = _context.Movies.Include(g => g.Genre).Where<Movie>(m => m.Id == Id).FirstOrDefault();
            return View(selectedMovie);
        }

        [Authorize(Roles = RoleNames.canManageMovies)]
        public ActionResult Save(int? Id)
        {
            var newmovie = new Movie();
            ViewBag.Title = "New Movie";
            if (Id.HasValue)
            {
                ViewBag.Title = "Edit Movie";
                newmovie = _context.Movies.Where<Movie>(m => m.Id == Id).Single();
            }

            var movieModel = new SaveMovieViewModel(newmovie)
            {
                Genres = _context.Genres.ToList()
            };

            TempData["SuccessMessage"] = "Saved Successfully";

            return View(movieModel);
        }

        [HttpPost]
        [Authorize(Roles = RoleNames.canManageMovies)]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var newMoviemodel = new SaveMovieViewModel(movie)
                {
                    Genres = _context.Genres.ToList(),
                };
                return View(newMoviemodel);
            }
            if (_context.Movies.Where<Movie>(m => m.Id == movie.Id).Count() > 0)
            {
                _context.Entry<Movie>(movie).State = EntityState.Modified;
            }
            else
            {
                _context.Movies.Add(movie);
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

    }
}