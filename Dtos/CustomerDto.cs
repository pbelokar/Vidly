using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyNew.Models;

namespace VidlyNew.Dtos
{
    public class CustomerDto
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        //[ValidateIfAge18years]
        public DateTime? DateofBirth { get; set; }
        
        public bool IsSubscribedToNewsletter { get; set; }

        public int MembershipTypeId { get; set; }

        public MembershipTypedto MembershipType { get; set; }
    }
}