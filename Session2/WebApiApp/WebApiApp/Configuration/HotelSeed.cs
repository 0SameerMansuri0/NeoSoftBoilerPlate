using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiApp.Context;

namespace WebApiApp.Configuration
{
    public class HotelSeed : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
                 new Hotel
                 {
                     Id = 1,
                     Name = "Novotel",
                     Address = "Mumbai",
                     Rating = 4,
                     CountryId = 1
                 },
                new Hotel
                {
                    Id = 2,
                    Name = "Hira",
                    Address = "Malegaon",
                    Rating = 5,
                    CountryId = 2
                },
                 new Hotel
                 {
                     Id = 3,
                     Name = "Taj",
                     Address = "Mumbai",
                     Rating = 5,
                     CountryId = 1
                 });
        }
    }
}