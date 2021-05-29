using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SportsPro.Models
{
    public class Incident
    {
        public int IncidentID { get; set; }

        [Required]
        public int CustomerID { get; set; }     // foreign key property
        public Customer Customer { get; set; }  // navigation property

        [Required]
        public int ProductID { get; set; }     // foreign key property
        public Product Product { get; set; }   // navigation property

        public int? TechnicianID { get; set; }     // foreign key property - nullable
        public Technician Technician { get; set; }   // navigation property

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        [Display(Name = "Date Opened")]
        public DateTime DateOpened { get; set; } = DateTime.Now;

        public DateTime? DateClosed { get; set; } = null;
    }



    public class IncidentManager
    {
        private static List<Incident> _incidents;
        
        static IncidentManager()
        {
            _incidents = new List<Incident>
            {
               new Incident
                {
                   IncidentID = 1,
                   CustomerID = 1010,
                   DateClosed = new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                   DateOpened = new DateTime(2020, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                   Description = "Media appears to be bad.",
                   ProductID = 1,
                   TechnicianID = 11,
                   Title = "Could not install"
               },
              new Incident
                {
                  IncidentID = 2,
                  CustomerID = 1002,
                  DateOpened = new DateTime(2020, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                  Description = "Received error message 415 while trying to import data from previous version.",
                  ProductID = 4,
                  TechnicianID = 14,
                  Title = "Error importing data"
              },
              new Incident
                {
                   IncidentID = 3,
                   CustomerID = 1015,
                   DateClosed = new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                   DateOpened = new DateTime(2020, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                   Description = "Setup failed with code 104.",
                   ProductID = 6,
                   TechnicianID = 15,
                   Title = "Could not install"
               },
              new Incident
                {
                   IncidentID = 4,
                   CustomerID = 1010,
                   DateOpened = new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                   Description = "Program fails with error code 510, unable to open database.",
                   ProductID = 3,
                   Title = "Error launching program"
               },

            };
        }

        public static List<Incident> GetAll()
        {
            return _incidents;
        }

        //public static List<Incident> GetIncidentByTechnician(int id)
        //{
        //    var context = new SportsProContext();
        //    var tech = context.Incidents.Where(t => t.TechnicianID == id)
        //            .Include(r => r.Customer).Include(rp => rp.Product).ToList();
        //    return tech;

        //    //    //SELECT i.[Title], c.[FirstName], c.[LastName], p.[Name], i.[DateOpened] from[dbo].[Incidents] i JOIN[dbo].[Customers] c
        //    //    //} var incident = (from i in _context.Incidents join c in _context.Customers on i.CustomerID equals c.CustomerID
        //    //    //join p in _context.Products on i.ProductID equals p.ProductID
        //    //    //where i.IncidentID == idselect new { Title = i.Title, Customer = c.FullName, Product = p.Name, DateOpened = i.DateOpened }).ToList();

        //}
    }
}