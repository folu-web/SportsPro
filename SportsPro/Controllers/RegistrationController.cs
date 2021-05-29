using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    [Authorize]
    public class RegistrationController : Controller
    {
        private readonly SportsProContext _context;

        public RegistrationController(SportsProContext context)
        {
            _context = context;
        }

        // show technicians in dropdown list
        public IActionResult GetCustomer()
        {
            var customers = CustomerManager.GetAll();
            var list = new SelectList(customers, "CustomerID", "FullName");
            ViewBag.Customers = list;
            return View();
        }

        //List
        public async Task<IActionResult> List()
        {
            return View(await _context.Registrations.ToListAsync());
        }

        // GET: add product
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var products = ProductManager.GetAll();
            var list = new SelectList(products, "ProductID", "Name");
            ViewBag.Products = list;
            return View();
        }

        // POST: add product
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("ID", "ProductID", "Name", "CustomerID", "FirstName", "LastName")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registration);
                await _context.SaveChangesAsync();
                TempData["message"] = $"{registration.Name} was successfully created.";
                return RedirectToAction(nameof(List));
            }
            return View(registration);
        }

        // GET: delete registeration
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _context.Registrations
                .FirstOrDefaultAsync(m => m.ID == id);
            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        // POST: delete registeration
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registration = await _context.Registrations.FindAsync(id);
            TempData["message"] = $"{registration.Name} was successfully deleted.";
            _context.Registrations.Remove(registration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }
    }
}
