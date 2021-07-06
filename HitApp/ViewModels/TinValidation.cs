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

        //public static bool ValidateTIN(string tin)
        //{
        //    int _numTIN = 0;
        //    if (tin.Length != 9 || !int.TryParse(tin, out _numTIN))
        //        return false;
        //    else
        //    {
        //        double sum = 0;
        //        int iter = tin.Length - 1;
        //        tin.ToCharArray().Take(iter).ToList().ForEach(c =>
        //        {
        //            sum += double.Parse(c.ToString()) * Math.Pow(2, iter);
        //            iter--;
        //        });
        //        if (sum % 11 == double.Parse(tin.Substring(8)) || double.Parse(tin.Substring(8)) == 0)
        //            return true;
        //        else
        //            return false;
        //    }
        //}
    }
}
