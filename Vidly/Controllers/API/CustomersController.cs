using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {

        private ApplicationDbContext _context;


        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

      

        //GET  /api/customers

        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
        }



        //GET /api/customers/1
        public CustomerDto GetCustomer(int id)
        {
            Customer customer = _context.Customers.SingleOrDefault(c=>c.Id==id);

            if(customer== null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Mapper.Map<Customer,CustomerDto>(customer);
        }


        //POST /api/customers
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto c1)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customer = Mapper.Map<CustomerDto, Customer>(c1);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            c1.Id = customer.Id;

            return c1;
        }


        //PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id,CustomerDto cDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDatabase = _context.Customers.SingleOrDefault(c=>c.Id == id);

            if(customerInDatabase == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }


            Mapper.Map<CustomerDto,Customer>(cDto, customerInDatabase);
           
            _context.SaveChanges();
        }


        //DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDatabase = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDatabase == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customerInDatabase);
            _context.SaveChanges();
        }
    }
}
