using Infrastructure.DAL.Entities;
using Infrastructure.DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task = Infrastructure.DAL.Entities.Task;

namespace Infrastructure.DAL;

public class ApplicationDbContext : IdentityDbContext<User, Role, string>
{

    public ApplicationDbContext(DbContextOptions options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public DbSet<Task> Tasks { get; set; }
}

