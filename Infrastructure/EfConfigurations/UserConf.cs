using Infrastructure.DAL.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.EfConfigurations
{
    public class UserConf : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            #region Props

            builder.Property(x => x.FirstName).HasMaxLength(48).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(48).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(48).IsRequired();
            #endregion

            #region Indexes
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.UserName).IsUnique();
            #endregion
        }
    }
}
