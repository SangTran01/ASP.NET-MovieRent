using MovieRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieRent.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        //GET /api/customers/1
        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
                return customer;
        }

        //POST /api/customers
        //returning customer because user may want the id of the customer
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
                _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        //PUT /api/customers/1
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

                if (customerInDb == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else {

                    customerInDb.Name = customer.Name;
                    customerInDb.DOB = customer.DOB;
                    customerInDb.MembershipTypeId = customer.MembershipTypeId;
                    customerInDb.Membership = customer.Membership;
                    customerInDb.IsSubcribedToNewsLetter = customer.IsSubcribedToNewsLetter;

                    _context.SaveChanges();
                }

            }
        }
    }
}
