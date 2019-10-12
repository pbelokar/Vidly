using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyNew.Models;

namespace VidlyNew.ViewModel
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> membershipTypes { get; set; }
        public Customer customer { get; set; }
    }
}