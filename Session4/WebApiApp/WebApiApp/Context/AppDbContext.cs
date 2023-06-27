using Microsoft.EntityFrameworkCore;
using WebApiApp.Configuration;

using WebApiApp.Context;

namespace WebApiApp.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>context):base(context)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CountrySeed());
            modelBuilder.ApplyConfiguration(new HotelSeed());
            

        }


        public DbSet<Hotel> Hotels { get; set; }    
        public DbSet<Country> Country { get; set; }


     }
}
