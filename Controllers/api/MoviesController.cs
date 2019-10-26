using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyNew.Models;
using VidlyNew.Dtos;
using System.Data.Entity;

namespace VidlyNew.Controllers.api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _dbcontext;
        public MoviesController()
        {
            _dbcontext = new ApplicationDbContext();
        }

        public IEnumerable<MovieDto> GetMovies()
        {
            return _dbcontext.Movies.Include(m => m.Genre).ToList().Select(Mapper.Map<Movie, MovieDto>);
        }

        public IHttpActionResult GetMovie(int Id)
        {
            Movie movie = _dbcontext.Movies.Find(Id);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        public IHttpActionResult PutMovie(MovieDto moviedto)
        {
            Movie movieinDb = _dbcontext.Movies.Find(moviedto.Id);

            if (movieinDb == null)
                return NotFound();

            Mapper.Map<MovieDto, Movie>(moviedto, movieinDb);
            _dbcontext.SaveChanges();
            return Ok(movieinDb);
        }

        [HttpPost]
        public IHttpActionResult PostMovie(MovieDto moviedto)
        {
            _dbcontext.Movies.Add(Mapper.Map<MovieDto,Movie>(moviedto));
            _dbcontext.SaveChanges();

            return Ok();

        }
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int Id)
        {
            var movie = _dbcontext.Movies.Find(Id);
            if (movie == null)
                return BadRequest();
            _dbcontext.Movies.Remove(movie);
            _dbcontext.SaveChanges();

            return Ok();
        }

    }
}
