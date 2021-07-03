using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HitApp.Models
{
    public class KindsOfSupplier
    {
        public int KindsOfSupplierId { get; set; }

        [Required]
        [StringLength(100,ErrorMessage ="More than 100 characters",MinimumLength =2)]
        [Display(Name ="Suppliers Role")]
        public string Heading { get; set; }
    }
}