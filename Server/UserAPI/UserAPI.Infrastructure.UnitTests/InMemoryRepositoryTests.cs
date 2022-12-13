using Microsoft.EntityFrameworkCore;

namespace UserAPI.Infrastructure.UnitTests;

public abstract class InMemoryRepositoryTests
{
    private readonly DbContextOptions<UberEatContext> options;

    protected UberEatContext Context { get; }

    protected InMemoryRepositoryTests()
    {
        var databaseName = Guid.NewGuid().ToString();
        options = new DbContextOptionsBuilder<UberEatContext>().UseInMemoryDatabase(databaseName).Options;
        Context = new UberEatContext(options);
    }

    protected UberEatContext MakeDbContext() => new UberEatContext(options);
}