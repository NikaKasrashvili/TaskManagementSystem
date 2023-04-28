using Infrastructure.DAL.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Constants;

namespace Infrastructure.DAL.Seeds
{
    public class RoleSeedConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role
                {
                    Id = "94522b4b-23eb-344a-2278-cg215d880e3c",
                    Name = RoleConsts.Admin,
                    NormalizedName = RoleConsts.Admin.ToUpper()
                },
                new Role
                {
                    Id = "42567b4b-33et-384r-5778-cg215d990e3c",
                    Name = RoleConsts.BasicUser,
                    NormalizedName = RoleConsts.BasicUser.ToUpper()
                },
                new Role
                {
                    Id = "64b1793f-2d1f-4e50-8af2-e266e1d78987",
                    Name = RoleConsts.Moderator,
                    NormalizedName = RoleConsts.Moderator.ToUpper()
                },
                new Role
                {
                    Id = "52da7c94-9844-482c-8c09-c5c07bda12f1",
                    Name = RoleConsts.Creator,
                    NormalizedName = RoleConsts.Creator.ToUpper()
                }
            );
        }
    }
}
