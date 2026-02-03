using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.api
{
    public class CustomersController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult GetCustomer(string query = null)
        {
            var customerQuery = _context.Customers.Include(c => c.MemberShipType);

            if (!string.IsNullOrWhiteSpace(query))

                customerQuery = customerQuery.Where(c => c.Name.Contains(query));


              var customerDto = customerQuery.Select(Mapper.Map<Customer, CustomerDto>).ToList() ;
            return Ok(customerDto);
        }

        [HttpGet]

        public IHttpActionResult GetCustomer (int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
            var customerDto = Mapper.Map<Customer, CustomerDto>(customer);

            return Ok(customerDto);
        }
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id),customerDto);
        }

        [HttpPut]

        public IHttpActionResult UpdateCustomer (int id , CustomerDto customerDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return NotFound(); 
           
            var customerDb = Mapper.Map(customerDto, customerInDb);
  
            _context.SaveChanges();
            
            return Ok(customerDb);

        }
        [HttpDelete]
        public IHttpActionResult DeleteCUstomer (int id )
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return NotFound();
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
           var customerDto = Mapper.Map<Customer, CustomerDto>(customerInDb);
            return Ok(customerDto);
        }
    }
}
