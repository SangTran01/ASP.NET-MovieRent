using MovieRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.Owin;

namespace MovieRent.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        //from Controller Class used to dispose context
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        public ActionResult Index()
        {

            var customers = _context.Customers
                .Include(c => c.Membership) //EAGER LOADING. Add include to 'include' the membershiptypes objects with customers
                .ToList();
            return View(customers);
        }

        //[Route("Details/{id}")]
        public ActionResult Details(int? id)
        {

            var customer = _context.Customers
                .Include(c => c.Membership)
                .SingleOrDefault(c => c.Id == id);

            //int index = customers.FindIndex(c => c.Id == id);
            return View(customer);
        }

        public ActionResult Create()
        {
            //when creating Customer with multiple Classes/Tables use viewmodels
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel {
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {

            try {
                if (ModelState.IsValid)
                {
                    _context.Customers.Add(customer);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Customer");
                }
                else
                    return View(customer);
            } catch {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer != null) {
                return View(customer);
            } else
                return HttpNotFound("Sorry. That customer doesn't exist. ID:" + id);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {

            try
            {
                if (ModelState.IsValid && customer != null)
                {
                    var customerToUpdate = _context.Customers.FirstOrDefault(c => c.Id == customer.Id);
                    customerToUpdate.Name = customer.Name;
                    customerToUpdate.DOB = customer.DOB;
                    customerToUpdate.MembershipTypeId = customer.MembershipTypeId;
                    customerToUpdate.Membership = customer.Membership;
                    customerToUpdate.IsSubcribedToNewsLetter = customer.IsSubcribedToNewsLetter;

                    _context.SaveChanges();

                    return RedirectToAction("Index", "Customer");
                }
                else
                    return View("Error");
            }
            catch {
                return View();
            }

        }

        public ActionResult Delete(int id)
        {
            Customer customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            return View(customer);
        }

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customerToDelete = _context.Customers.Find(id);

            if (customerToDelete != null)
            {
                _context.Customers.Remove(customerToDelete);
                _context.SaveChanges();
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                return HttpNotFound("This customer doesn't exist.");
            }
        }
    }
}