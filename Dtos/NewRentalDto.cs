using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyNew.Dtos
{
    public class NewRentalDto
    {
        public int customerid { get; set; }
        public List<int> movieids { get; set; }
    }
}