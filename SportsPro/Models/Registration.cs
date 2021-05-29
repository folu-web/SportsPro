using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsPro.Models
{
    public class Registration
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
		public string Name { get; set; }
		public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class RegistrationManager
    {
        private static List<Registration> _registrations;

        static RegistrationManager()
        {
            _registrations = new List<Registration>
            {
               new Registration
                {
                    ID = 1,
                    ProductID = 1,
                    Name = "Draft Manager 1.0",
                    CustomerID = 1002,
                    FirstName = "Ania",
                    LastName = "Irvin"
                },
                new Registration
                {
                    ID = 2,
                    ProductID = 3,
                    Name = "League Scheduler 1.0",
                    CustomerID = 1002,
                    FirstName = "Ania",
                    LastName = "Irvin"
                }
            };
        }

        public static List<Registration> GetAll()
        {
            return _registrations;
        }
    }
}
