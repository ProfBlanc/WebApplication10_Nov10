using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace WebApplication10_Nov10.Models
{
    public class TemperatureModel
    {
        [Key]
        public int TemperatureId {get; set;}

        public int MonthId { get; set;}

        [ValidateNever]
        public virtual MonthModel Month { get; set;}
    }
}
