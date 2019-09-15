using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyNew.Models;
using System.Data.Entity;

namespace VidlyNew.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //List<Customer> customers = new List<Customer> {
        //        new Customer { Name = "Harald", Id = 1 },
        //        new Customer { Name = "John", Id = 2 },
        //    };
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);

        }
        public ActionResult Details(int Id)
        {
            var selectedcustomers = _context.Customers.Include(c => c.MembershipType).Where<Customer>(x => x.Id == Id).FirstOrDefault();
            
            return View(selectedcustomers);
        }
    }
}