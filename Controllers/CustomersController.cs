using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyNew.Models;

namespace VidlyNew.Controllers
{
    public class CustomersController : Controller
    {
        List<Customer> customers = new List<Customer> {
                new Customer { Name = "Harald", Id = 1 },
                new Customer { Name = "John", Id = 2 },
            };
        public ActionResult Index()
        {

            return View(customers);

        }
        public ActionResult Details(int Id)
        {
            Customer customer = customers.Where<Customer>(x => x.Id == Id).FirstOrDefault();
            return View(customer);
        }
    }
}