using EMartProject.Configuration;
using EMartProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EMartProject.Context
{
    public class AppDbContext:IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> context) : base(context)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new RoleSeed());
           base.OnModelCreating(modelBuilder);

           
        }


        //create table

         public DbSet<Product> products { get; set; }

        public DbSet<Category> categories { get; set; }

        public DbSet<Order> orders { get; set; }
        
    }
}
