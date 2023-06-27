using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMartProject.Configuration
{
    public class RoleSeed : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                
                new IdentityRole
                {
                    Name="Administartor",
                    NormalizedName="ADMINISTRATOR"

                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"

                }

                );
        }
    }
}
