using Microsoft.EntityFrameworkCore;
using UserAPI.Domain;

namespace UserAPI.Infrastructure;

public class UberEatContext: DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Gender> Genders { get; set; }

    public UberEatContext(DbContextOptions<UberEatContext> options) : base(options)
    {

    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(builder => 
            builder.HasOne(f => f.Role)
                .WithMany(p => p.Users)
                .HasForeignKey(f => f.RoleId)
                .OnDelete(DeleteBehavior.Restrict));

        base.OnModelCreating(modelBuilder);
    }
}