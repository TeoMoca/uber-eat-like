using FluentAssertions;
using UserAPI.Infrastructure.Repository;

namespace UserAPI.Infrastructure.UnitTests.Role;

public class AllAsync : InMemoryRepositoryTests
{
    private RoleRepository _repository;

    public AllAsync()
    {
        _repository = new RoleRepository(context: this.Context);
    }
    
    public Domain.Role firstRole = new Domain.Role()
    {
        Id = 1, Label = "test1@email", IsDisabled = true
    };
    
    public Domain.Role secondRole = new Domain.Role()
    {
        Id = 2, Label = "test2@email", IsDisabled = true
    };
    
    public Domain.Role thirdRole = new Domain.Role()
    {
        Id = 3, Label = "test3@email", IsDisabled = false
    };

    [Fact]
    public async Task Should_Return_All_Role()
    {
        //Arrange
        await AddInMemory(firstRole);
        await AddInMemory(secondRole);
        await AddInMemory(thirdRole);
        
        var expectedResult = 3;
        
        //Act
        var result = await Act();
        
        //Assert
        result.Should().HaveCount(expectedResult);
    }
    
    private async Task AddInMemory(Domain.Role role) {
        await using UberEatContext context = MakeDbContext();
        await context.Roles.AddAsync(role);
        await context.SaveChangesAsync();
    }

    private async Task<List<Domain.Role>> Act() => await _repository.AllAsync();
}