using Infrastructure.DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Seeds
{
    public class UsersSeedConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var hasher = new PasswordHasher<User>();

            builder.HasData(
                new User
                {
                    Id = "9a92589c-7415-4f0a-b98r-ad4d0d6iu174",
                    FirstName = "First",
                    LastName = "Admin",
                    UserName = "admin@taskmanagement.com",
                    NormalizedUserName = "ADMIN@TASKMANAGEMENT.COM",
                    Email = "admin@taskmanagement.com",
                    NormalizedEmail = "ADMIN@TASKMANAGEMENT.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "123456",
                    PasswordHash = hasher.HashPassword(null, "asdASD@123"),
                },

                new User
                {
                    Id = "94570a4b-25ed-454a-8278-ca715d850e5c",
                    FirstName = "User",
                    LastName = "Moderator",
                    UserName = "user@taskmanagement.com",
                    NormalizedUserName = "USER.TASKMANAGEMENT.COM",
                    Email = "user@taskmanagement.com",
                    NormalizedEmail = "USER@TASKMANAGEMENT.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "11223344",
                    PasswordHash = hasher.HashPassword(null, "asdASD@123"),
                }
             );
        }
    }
}
