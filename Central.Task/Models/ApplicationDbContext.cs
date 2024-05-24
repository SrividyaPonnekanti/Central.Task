using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Central.Task.Models
{
   




    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Registrations> Registrations { get; set; }
    }

}
