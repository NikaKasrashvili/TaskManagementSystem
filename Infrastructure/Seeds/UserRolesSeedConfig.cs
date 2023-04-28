using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Seeds
{
    public class UserRolesSeedConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = "9a92589c-7415-4f0a-b98r-ad4d0d6iu174",
                    RoleId = "94522b4b-23eb-344a-2278-cg215d880e3c"
                },

                new IdentityUserRole<string>
                {
                    UserId = "94570a4b-25ed-454a-8278-ca715d850e5c",
                    RoleId = "42567b4b-33et-384r-5778-cg215d990e3c"
                }
            );
        }
    }
}
