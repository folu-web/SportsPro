using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsPro.BLL;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class TechnicianIncidenceController : Controller
    {
        private readonly SportsProContext _context;

        public TechnicianIncidenceController(SportsProContext context)
        {
            _context = context;
        }


        [Route("/gettechnicians")]
        [Authorize(Roles = "Technician")]
        // GET: TechnicianIncidence
        public  IActionResult List()
        {
            ViewData["TechnicianID"] = new SelectList(_context.Technicians, "TechnicianID", "Name");
            return View();
            //var technicians = TechnicianManager.GetAll();
            //var list = new SelectList(technicians, "TechnicianID", "Name");
            //ViewBag.Technicians = list;
            //return View(technicians);
        }

        public IActionResult IncTech()
        {
            try //technician selected case
            {

                var techID = Convert.ToInt32(Request.Form["ddl"]); 
                TempData["techID"] = techID.ToString();

                var technicians = UpdateIncidentManager.GetTechByName(techID); 
                TempData["Name"] = technicians.Name.ToString(); 


                var db = UpdateIncidentManager.GetIncidentByTechnician(techID); //GetAllIncidentsByTechnician
                return View(db);
            }
            catch //technician from session during redirection
            {
                var techID = Convert.ToInt32(TempData["techID"]); //retreive technicianID from tempdata
                TempData["techID"] = techID.ToString();//store technicianID in tempdata

                var technicians = UpdateIncidentManager.GetTechByName(techID); //get tech object        
                TempData["Name"] = technicians.Name.ToString(); //store tech name in tempdata

                var db = UpdateIncidentManager.GetIncidentByTechnician(techID); //GetAllIncidentsByTechnician
                return View(db);
            }
            //var technicians = IncidentManager.GetIncidentByTechnician(id);
            //var tech = technicians.SingleOrDefault(t => t.TechnicianID == id);

            //return View(tech);
        }

        //// GET: TechnicianIncidence/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var technician = await _context.Technicians
        //        .FirstOrDefaultAsync(m => m.TechnicianID == id);
        //    if (technician == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(technician);
        //}

       

        // GET: TechnicianIncidence/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var techID = Convert.ToInt32(TempData["techID"]); //retreive technicianID from tempdata
            TempData["techID"] = techID.ToString();////store technicianID in tempdata to maintain selected technician state
            TempData["techID"] = techID.ToString();

            var incident = UpdateIncidentManager.Find(id);
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "FullName", incident.CustomerID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "Name", incident.ProductID);
            return View(incident);
        }

        // POST: TechnicianIncidence/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Incident incident)
        {
            var techID = Convert.ToInt32(TempData["techID"]); //retreive technicianID from tempdata
            TempData["techID"] = techID.ToString();////store technicianID in tempdata to maintain selected technician state
            TempData["techID"] = techID.ToString();
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "FullName", incident.CustomerID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "Name", incident.ProductID);
            try
            {

                UpdateIncidentManager.Update(incident);

                return RedirectToAction(nameof(IncTech)); //redirect to incidents page
            }
            catch
            {
                return View(incident);
            }
        }

       
        
    }
}
