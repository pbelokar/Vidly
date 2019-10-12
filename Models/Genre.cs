﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyNew.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Genre")]
        public string Name { get; set; }
    }
}