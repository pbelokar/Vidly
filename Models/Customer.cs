using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace VidlyNew.Models
{
    [KnownType(typeof(MembershipType))]
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        [Display(Name ="Date of Birth")]
        [ValidateIfAge18years]
        public DateTime? DateofBirth { get; set; }


        public bool IsSubscribedToNewsletter { get; set; }

        
        public  MembershipType MembershipType { get; set; }


        [Display(Name = "Membership Type")]
        [ForeignKey("MembershipType")]
        public int MembershipTypeId { get; set; }
    }
}