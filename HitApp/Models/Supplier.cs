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
        public string Name { get; private set; }

        [Required]       
        public int KindsOfSupplierId { get; private set; }
        public  KindsOfSupplier KindOfSupplier { get; set; }

        [Required]
        public string TIN { get; private set; }

        [StringLength(100, MinimumLength = 5, ErrorMessage = "Adress must be 5-100 characters")]
        public string Address { get; private set; }

        [Required]
        public string PhoneNumber { get; private set; }

        [Required]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Email must be 5-50 characters")]
        public string Email { get; private set; }

        [Required]
        public int CountryId { get; private set; }
        public  Country Country { get; set; }
        public bool? IsActive { get; private set; }

        protected Supplier(){ }

        public Supplier(string name,int kindOfSupplierId,string tin,string address,string phoneNumber,string email,int countryId,bool? isActive)
        {
            this.Name = name;
            this.KindsOfSupplierId = kindOfSupplierId;
            this.TIN = tin;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.CountryId = countryId;
            this.IsActive = isActive;

        }
        public void UpdateSupplier(string name, int kindOfSupplierId, string tin, string address, string phoneNumber, string email, int countryId, bool? isActive)
        {
            Name = name;
            KindsOfSupplierId = kindOfSupplierId;
            TIN = tin;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            CountryId = countryId;
            IsActive = isActive;
        }
     
    }
}