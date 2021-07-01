using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HitApp.ViewModels
{
    public class PhoneValidation: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                string phone = value.ToString();
                if (phone.Length == 10)
                {
                    return ValidationResult.Success;
                }              
            }
             return new ValidationResult("Phone must contain 10 numbers");
        }
        
    }
}