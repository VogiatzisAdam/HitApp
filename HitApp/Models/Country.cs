using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HitApp.Models
{
    
    public class Country
    {
        public int CountryId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "More than 100 characters", MinimumLength = 2)]
        [Display(Name ="Country")]
        public string Name { get; set; }
    }
}