using System.ComponentModel.DataAnnotations;

namespace WebApplication10_Nov10.Models
{
    public class MonthModel
    {
        [Key]
        public int MonthId   { get; set; }

        [Required]
        [MinLength(3)]
        public string MonthName { get; set; } = string.Empty;
    }
}
