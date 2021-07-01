using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HitApp.ViewModels
{
    public class TinValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string tin = value.ToString();
                if (tin.Length == 9)
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("TIL must contain 9 numbers");
        }
    }
}