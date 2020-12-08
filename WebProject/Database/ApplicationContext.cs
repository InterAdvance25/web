using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Models;
using WebProject.Models.Users;
using WebProject.Models.Vehicle;

namespace WebProject.Database
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<PassengerCar> PassengerСars { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

             Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
