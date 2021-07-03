using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HitApp.Models
{
    public class Supplier
    {
        [Display(Name ="Id")]
        public int SupplierId { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "Adress must be 5-100 characters")]
        public string Name { get; set; }

        [Required]       
        public int KindsOfSupplierId { get; set; }
        public  KindsOfSupplier KindOfSupplier { get; set; }

        [Required]
        public string TIN { get; set; }

        [StringLength(100, MinimumLength = 5, ErrorMessage = "Adress must be 5-100 characters")]
        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Email must be 5-50 characters")]
        public string Email { get; set; }

        [Required]
        public int CountryId { get; set; }
        public  Country Country { get; set; }
        public bool? IsActive { get; set; }
    }
}