using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Random()
        {
            Movie movie = new Movie()
            {
                id = 1,
                Name = "Shrek !"
            };

            RandomMovieViewModel newmovie = new RandomMovieViewModel() {
                customers = new List<Customer> {
                       new Customer(){ id =1, Name = "Customer1"},
                       new Customer(){ id =2, Name = "Customer2"},
                },
                movie = movie
            };

            return View(newmovie);
        }


    }
}