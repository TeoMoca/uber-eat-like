using Microsoft.EntityFrameworkCore;
using UserAPI.Domain;

namespace UserAPI.Infrastructure;

public class UberEatContext: DbContext
{
    public DbSet<User> Users { get; set; }
    
    public UberEatContext(DbContextOptions<UberEatContext> options) : base(options)
    {

    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }
    
}