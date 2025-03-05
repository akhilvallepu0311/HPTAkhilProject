using Microsoft.EntityFrameworkCore;
using WebApiPro2.Models;

namespace WebApiPro2.DBContext
{
    public class ProjectDB2Context : DbContext
    {
        public ProjectDB2Context(DbContextOptions<ProjectDB2Context> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
