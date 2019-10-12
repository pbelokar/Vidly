using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyNew.Models;
using System.Data.Entity;
using VidlyNew.ViewModel;

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

        //public ActionResult Edit(int Id)
        //{

        //    var viewModel = new NewCustomerViewModel
        //    {
        //        membershipTypes = _context.MembershipTypes.ToList(),
        //        customer = _context.Customers.Where<Customer>(c => c.Id == Id).FirstOrDefault()
        //    };

        //    return View(viewModel);
        //}

        public ActionResult New(int? Id)
        {
            var customer = new Customer();
            if (Id.HasValue)
            {
                customer = _context.Customers.Include(c => c.MembershipType).Where<Customer>(c => c.Id == Id).FirstOrDefault();
            }

            var viewModel = new NewCustomerViewModel
            {
                membershipTypes = _context.MembershipTypes.ToList(),
                customer = customer
            };
            return View(viewModel);
        }
        public ActionResult Index()
        {
            return View();

        }
        public ActionResult Details(int Id)
        {
            var selectedcustomers = _context.Customers.Include(c => c.MembershipType).Where<Customer>(x => x.Id == Id).FirstOrDefault();

            return View(selectedcustomers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var newCustomerViewModel = new NewCustomerViewModel() {
                    customer = customer,
                    membershipTypes = _context.MembershipTypes.ToList()
                };

                return View("New", newCustomerViewModel);
            }
            if (_context.Customers.Where<Customer>(c => c.Id == customer.Id).Count() > 0)
            {
                _context.Entry(customer).State = EntityState.Modified;
            }
            else
            {
                _context.Customers.Add(customer);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
    }
}