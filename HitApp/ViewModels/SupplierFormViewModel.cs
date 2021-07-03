using HitApp.Controllers;
using HitApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace HitApp.ViewModels
{
    public class SupplierFormViewModel
    {
        public int Id { get; set; }
        public string Heading { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "Name must be 3-80 characters")]
        public string Name { get; set; }

        [Required]
        public int KindsOfSupplierId { get; set; }

        [Display(Name ="Suppliers Role")]
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
       
        public int CountryId  { get; set; }
        
        [Display(Name ="Country")]
        public IEnumerable<Country> Countries { get; set; }
        public bool? IsActive { get; set; }
        public string Action
        {
            get
            {
               // return (Id != 0) ? "Update" : "Create";
                Expression<Func<SupplierController, ActionResult>> update = (u => u.Update(this)); 
                Expression<Func<SupplierController, ActionResult>> create = (u => u.Create(this));

                var action = (Id != 0) ? update : create;
                var actionName = (action.Body as MethodCallExpression).Method.Name;

                return actionName;
            }
        }
    }
}