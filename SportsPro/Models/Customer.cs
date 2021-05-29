using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SportsPro.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [Required, MaxLength(51)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, MaxLength(51)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, MaxLength(51)]
        public string Address { get; set; }

        [Required, MaxLength(51)]
        public string City { get; set; }

        [Required, MaxLength(51)]
        public string State { get; set; }

        [Required, MaxLength(51)]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required]
        public string CountryID { get; set; }
        public Country Country { get; set; }

        [RegularExpression(@"^\(([0-9]{3})\)[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Phone number must be in (999) 999-9999 format.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is Required."), MaxLength(51)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string FullName => FirstName + " " + LastName;   // read-only property
    }

    public class CustomerManager
    {
        private static List<Customer> _customers;

        static CustomerManager()
        {
            _customers = new List<Customer>
            {
               new Customer
                {
                    CustomerID = 1002,
                    FirstName = "Ania",
                    LastName = "Irvin",
                    Address = "PO Box 96621",
                    City = "Washington",
                    State = "DC",
                    PostalCode = "20090",
                    CountryID = "US",
                    Phone = "(301) 555-8950",
                    Email = "ania@mma.nidc.com"
                },
                new Customer
                {
                    CustomerID = 1004,
                    FirstName = "Kenzie",
                    LastName = "Quinn",
                    Address = "1990 Westwood Blvd Ste 260",
                    City = "Los Angeles",
                    State = "CA",
                    PostalCode = "90025",
                    CountryID = "US",
                    Phone = "(800) 555-8725",
                    Email = "kenzie@mma.jobtrak.com"
                },
                new Customer
                {
                    CustomerID = 1006,
                    FirstName = "Anton",
                    LastName = "Mauro",
                    Address = "3255 Ramos Cir",
                    City = "Sacramento",
                    State = "CA",
                    PostalCode = "95827",
                    CountryID = "US",
                    Phone = "(916) 555-6670",
                    Email = "amauro@yahoo.org"
                },
                new Customer
                {
                    CustomerID = 1008,
                    FirstName = "Kaitlyn",
                    LastName = "Anthoni",
                    Address = "Box 52001",
                    City = "San Francisco",
                    State = "CA",
                    PostalCode = "94152",
                    CountryID = "US",
                    Phone = "(800) 555-6081",
                    Email = "kanthoni@pge.com"
                },
                new Customer
                {
                    CustomerID = 1010,
                    FirstName = "Kendall",
                    LastName = "Mayte",
                    Address = "PO Box 2069",
                    City = "Fresno",
                    State = "CA",
                    PostalCode = "93718",
                    CountryID = "US",
                    Phone = "(559) 555-9999",
                    Email = "kmayte@fresno.ca.gov"
                },
                new Customer
                {
                    CustomerID = 1012,
                    FirstName = "Marvin",
                    LastName = "Quintin",
                    Address = "4420 N. First Street, Suite 108",
                    City = "Fresno",
                    State = "CA",
                    PostalCode = "93726",
                    CountryID = "US",
                    Phone = "(559) 555-9586",
                    Email = "marvin@expedata.com"
                },
                new Customer
                {
                    CustomerID = 1015,
                    FirstName = "Gonzalo",
                    LastName = "Keeton",
                    Address = "27371 Valderas",
                    City = "Mission Viejo",
                    State = "CA",
                    PostalCode = "92691",
                    CountryID = "US",
                    Phone = "(214) 555-3647",
                    Email = ""
                }
            };
        }

        public static List<Customer> GetAll()
        {
            return _customers;
        }
    }
}