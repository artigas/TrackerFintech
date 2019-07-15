using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrackerFintech.Models
{
    public class Tracker
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Título")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 25 characters")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Categoría")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 25 characters")]
        public string Category { get; set; }
        [Required]
        [Display(Name = "Valor")]
        [DataType(DataType.Currency, ErrorMessage = "Value must be a number")]
        public decimal Value { get; set; }
    }
}
