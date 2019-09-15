using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyNew.Models;

namespace VidlyNew.ViewModel
{
    public class RandomMovieViewModel
    {
        public Movie movie { get; set; }
        public List<Customer> customers { get; set; }
    }
}