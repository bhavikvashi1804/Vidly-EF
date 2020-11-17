using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList<Customer>();
        }



        //GET /api/customers/1
        public Customer GetCustomer(int id)
        {
            Customer customer = _context.Customers.SingleOrDefault(c=>c.Id==id);

            if(customer== null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return customer;
        }


        //POST /api/customers
        [HttpPost]
        public Customer CreateCustomer(Customer c1)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            _context.Customers.Add(c1);
            _context.SaveChanges();

            return c1;
        }


        //PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id,Customer c1)
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

            customerInDatabase.Name = c1.Name;
            customerInDatabase.DOB = c1.DOB;
            customerInDatabase.IsMember = c1.IsMember;
            customerInDatabase.MembershipTypeId = c1.MembershipTypeId;

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
