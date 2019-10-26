using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyNew.Dtos;
using VidlyNew.Models;

namespace VidlyNew.Controllers.api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _dbcontext;
        public NewRentalsController()
        {
            _dbcontext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newReltal)
        {
            var movies = _dbcontext.Movies.Where(m => newReltal.movieids.Contains(m.Id)).ToList();
            if (newReltal.movieids.Count <= 0)
                return BadRequest("No MovieIds has been given"); 

            var customer = _dbcontext.Customers.SingleOrDefault(c => c.Id == newReltal.customerid);
            if (customer == null)
                return BadRequest("CustomerID is not valid");

            if (movies.Count != newReltal.movieids.Count())
                return BadRequest("One or more movies are invalid"); 
            

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable <= 0)
                    return BadRequest("movie is not available");

                    movie.NumberAvailable--;
                    var rental = new Rental
                    {
                        customer = customer,
                        movie = movie,
                        DateRented = DateTime.Now
                    };

                    _dbcontext.Rentals.Add(rental);
                
            }
            _dbcontext.SaveChanges();

            return Ok();
        }

    }
}
