using HitApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HitApp.ViewModels
{
    public class SupplierFormViewModel
    {
        [Required]
        [StringLength(80, ErrorMessage = "Adress must be 5-100 characters", MinimumLength = 3)]
        public string Name { get; set; }

        
        public int KindsOfSupplierId { get; set; }

        public IEnumerable< KindsOfSupplier> KindsOfSuppliers { get; set; }

        [Required]
        public string TIN { get; set; }

        [StringLength(100, ErrorMessage = "Adress must be 5-100 characters", MinimumLength = 5)]
        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Email must be 5-50 characters", MinimumLength = 5)]
        public string Email { get; set; }

        public int CountryId  { get; set; }

        public IEnumerable<Country> Countries { get; set; }
        public bool? IsActive { get; set; }
    }
}