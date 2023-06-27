using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiApp.Context;

namespace WebApiApp.Configuration
{
    public class CountrySeed : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                  new Country
                  {
                      Id = 1,
                      Name = "India",
                      ShortName = "IND"



                  },
                  new Country
                  {
                      Id = 2,
                      Name = "America",
                      ShortName = "AMC"
                  },
                  new Country
                  {
                      Id = 3,
                      Name = "Australia",
                      ShortName = "AUS"
                  }
                );
        }
    }
}