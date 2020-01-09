using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ADCD.Views.ViewModels
{
    public class OrderViewModel
    {
        // Selected Crane Info
        public int CraneId { get; set; }

        // Contact Info
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        // Company Info
        [Required]
        [Display(Name = "Company")]
        public string CompanyName { get; set; }
        public Address CompanyAddress { get; set; }

        // Jobsite Info
        [Required]
        [Display(Name = "Jobsite Name")]
        public string JobsiteName { get; set; }
        public Address JobsiteAddress { get; set; }

        // Order Info
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }

    public class Address
    {
        [Required]
        [Display(Name = "Street Address")]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
    }
}
