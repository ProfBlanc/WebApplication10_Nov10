using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication10_Nov10.Models;

namespace WebApplication10_Nov10.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<MonthModel> Months { get; set; }
        public DbSet<TemperatureModel> Temperatures { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
