using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public partial class Technician
    {
		public int TechnicianID { get; set; }	   

		[Required(ErrorMessage = "Please provide your name")]
		public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a valid email adddress")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [RegularExpression(@"^\(([0-9]{3})\)[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Phone number must be in the (999)999-9999 format")]
        [Required(ErrorMessage = "Please enter your phone number"), Display(Name = "Phone number")]
        public string Phone { get; set; }
        public Technician()
        {
            Incidents = new HashSet<Incident>();
        }
        public virtual ICollection<Incident> Incidents { get; set; }
    }

    public class TechnicianManager
    {
        private static List<Technician> _technicians;

        static TechnicianManager()
        {
            _technicians = new List<Technician>
            {
               new Technician
                {
                    TechnicianID = 11,
                    Name = "Alison Diaz",
                    Email = "alison@sportsprosoftware.com",
                    Phone = "800-555-0443"
                },
                new Technician
                {
                    TechnicianID = 12,
                    Name = "Jason Lee",
                    Email = "jason@sportsprosoftware.com",
                    Phone = "800-555-0444"
                },
                new Technician
                {
                    TechnicianID = 13,
                    Name = "Andrew Wilson",
                    Email = "awilson@sportsprosoftware.com",
                    Phone = "800-555-0449"
                },
                new Technician
                {
                    TechnicianID = 14,
                    Name = "Gunter Wendt",
                    Email = "gunter@sportsprosoftware.com",
                    Phone = "800-555-0400"
                },
                new Technician
                {
                    TechnicianID = 15,
                    Name = "Gina Fiori",
                    Email = "gfiori@sportsprosoftware.com",
                    Phone = "800-555-0459"
                }
            };
        }

        public static List<Technician> GetAll()
        {
            return _technicians;
        }

    }
        
}
