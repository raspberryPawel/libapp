using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibApp.Models;
using LibApp.ViewModels;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;

namespace LibApp.Controllers
{
    public class CustomersController : Controller
    {

        public readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context) {
            this._context = context;
        }

        public ViewResult Index()
        {
            var customers = this._context.Customers
                .Include(c=> c.MembershipType)
                .ToList();

            return View(customers);
        }

        public IActionResult Details(int id)
        {
            var customer = this._context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return Content("User not found");
            }

            return View(customer);
        }
        
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "Jan Kowalski" },
                new Customer { Id = 2, Name = "Monika Nowak" }
            };
        }
    }
}