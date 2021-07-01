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
        [StringLength(80, MinimumLength = 3, ErrorMessage = "Name must be 3-80 characters")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Kinds Of Supplier")]
        public int KindsOfSupplierId { get; set; }

        public IEnumerable< KindsOfSupplier> KindsOfSuppliers { get; set; }

        [Required]
        [TinValidation]
        public string TIN { get; set; }

        [StringLength(100, MinimumLength = 5, ErrorMessage = "Adress must be 5-100 characters")]
        public string Address { get; set; }

        [Required]
        [PhoneValidation]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Email must be 5-50 characters")]
        public string Email { get; set; }

        [Required]
        [Display(Name ="Country")]
        public int CountryId  { get; set; }

        public IEnumerable<Country> Countries { get; set; }
        public bool? IsActive { get; set; }
    }
}