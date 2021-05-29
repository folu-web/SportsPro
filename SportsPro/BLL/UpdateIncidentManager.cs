using Microsoft.EntityFrameworkCore;
using SportsPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsPro.BLL
{
    
    public class UpdateIncidentManager
    {
        public static Technician GetTechByName(int techID)
        {
            var context = new SportsProContext();
            var tech = context.Technicians.SingleOrDefault(t => t.TechnicianID == techID);
            return tech;
        }
        public static List<Incident> GetIncidentByTechnician(int techID)
        {
            var context = new SportsProContext();

            var tech = context.Incidents.Include(r => r.Customer).Include(rp => rp.Product)
                .Where(t => t.TechnicianID == techID).ToList();
            return tech;
        }

        public static Incident Find(int id)
        {
            var context = new SportsProContext();
            var runny = context.Incidents.Find(id);
            return runny;
        }

        public static void Update(Incident incident)
        {
            var context = new SportsProContext();
            var firstInci = context.Incidents.Find(incident.IncidentID);
            firstInci.Title = incident.Title;
            firstInci.CustomerID = incident.CustomerID;
            firstInci.ProductID = incident.ProductID;
            firstInci.DateOpened = incident.DateOpened;
            context.SaveChanges();
        }
    }
}
