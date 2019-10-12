using AutoMapper;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyNew.Dtos;
using VidlyNew.Models;

namespace VidlyNew.Controllers.api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _dbcontext;
        public CustomersController()
        {
            _dbcontext = new ApplicationDbContext();
        }
        //get // api/customer
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _dbcontext.Customers
                .Include(c=>c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
        }

        //GET / api/customer/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _dbcontext.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));

        }
        //POST // api/customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerdto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerdto);
            _dbcontext.Customers.Add(customer);
            _dbcontext.SaveChanges();

            customerdto.Id = customer.Id;

            return Created(Request.RequestUri + "/" + customer.Id, customerdto);
        }

        //PUT //api/customer
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto CustomerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerinDb = _dbcontext.Customers.SingleOrDefault(c => c.Id == id);
            if (customerinDb == null)
                return NotFound();

            Mapper.Map(CustomerDto, customerinDb);

            _dbcontext.SaveChanges();

            return Ok();
        }

        //delete /api/customer/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerinDb = _dbcontext.Customers.SingleOrDefault(c => c.Id == id);
            if (customerinDb == null)
                return NotFound();

            _dbcontext.Customers.Remove(customerinDb);
            _dbcontext.SaveChanges();

            return Ok();
        }

    }
}
