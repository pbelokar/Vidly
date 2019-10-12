using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyNew.Models;

namespace VidlyNew.ViewModel
{
    public class SaveMovieViewModel
    {
        public SaveMovieViewModel()
        {
            Id = 0;
        }

        public SaveMovieViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            DateAdded = movie.DateAdded;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Number in Stock should be between 1 to 20.")]
        [Display(Name = "Number In Stock")]
        public int? NumberInStock { get; set; }

        [Display(Name = "Genre")]
        public int? GenreId { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        public string Title {
            get
            {
                return (Id == 0) ? "New Movie" : "Edit Movie";
            }
                 
                
                }
    }
}