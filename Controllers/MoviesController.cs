using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyNew.Models;
using VidlyNew.ViewModel;

namespace VidlyNew.Controllers
{
    public class MoviesController : Controller
    {
        List<Movie> movies = new List<Movie>() {
                new Movie{ Id = 1, Name = "Shrek!"},
                new Movie{ Id = 2, Name = "Matrix"},

            };
        public ActionResult Random()
        {
            var movie = new Movie() { Id = 1, Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "customer1" },
                new Customer { Name = "customer2" }
            };


            var randomviewmodel = new RandomMovieViewModel()
            {
                customers = customers,
                movie = movie
            };

            return View(randomviewmodel);


        }
        public ActionResult Edit(int id)
        {

            return Content("Id =" + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {

            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (string.IsNullOrEmpty(sortBy))
                sortBy = "Name";

          

            return View(movies);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2})}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Details(int Id)
        {
            var selectedmovie = movies.Where<Movie>(s => s.Id == Id).FirstOrDefault();

            return View(selectedmovie);
        }
    }
}