using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using UserAPI.Infrastructure.Repository;

namespace UserAPI.Infrastructure.UnitTests.Role;

public class UpdateAsync : InMemoryRepositoryTests
{
    private RoleRepository _repository;

    public UpdateAsync()
    {
        _repository = new RoleRepository(context: Context);
    }
    
    public static int IdRole = 1;
    
    public Domain.Role firstRole = new Domain.Role()
    {
        Id = IdRole, Label = "test1@email", IsDisabled = false
    };
    
    public Domain.Role secondRole = new Domain.Role()
    {
        Id = IdRole, Label = "test2@email", IsDisabled = false
    };

    [Fact]
    public async Task Should_Update_Role_When_Role_Is_Updated()
    {
        //Arrange
        await AddInMemory(firstRole);
        await using UberEatContext context = MakeDbContext();
        
        //Act
        await Act(secondRole);
        
        //Assert
        var userUpdated = await context.Roles.Where(p => p.Id == IdRole).FirstOrDefaultAsync();

        userUpdated.Should().BeEquivalentTo(secondRole);
    }
    
    private async Task AddInMemory(Domain.Role role) {
        await using UberEatContext context = MakeDbContext();
        await context.Roles.AddAsync(role);
        await context.SaveChangesAsync();
    }

    private async Task Act(Domain.Role role) => await _repository.UpdateAsync(role);
}