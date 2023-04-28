using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = Infrastructure.DAL.Entities.Task;

namespace Infrastructure.DAL.EfConfigurations;
public class TaskConf : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Title).HasMaxLength(248);
        builder.Property(x => x.SmallDescription).HasMaxLength(248);
        builder.Property(x => x.UserId).IsRequired();

        //user can't be deleted if there are assigned task to the user.
        builder.HasOne(a => a.User)
               .WithMany(b => b.Tasks)
               .HasForeignKey(b => b.UserId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
