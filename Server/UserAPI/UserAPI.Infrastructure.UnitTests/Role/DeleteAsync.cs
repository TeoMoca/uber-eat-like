using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using UserAPI.Infrastructure.Repository;

namespace UserAPI.Infrastructure.UnitTests.Role;

public class DeleteAsync : InMemoryRepositoryTests
{
    private RoleRepository _repository;

    public DeleteAsync()
    {
        _repository = new RoleRepository(context: this.Context);
    }
    
    public Domain.Role firstRole = new Domain.Role()
    {
        Id = 1, Label = "test1@email", IsDisabled = true
    };
    
    [Fact]
    public async Task Should_Delete_Role_When_Match_Role()
    {
        //Arrange
        await AddInMemory(firstRole);
        await using UberEatContext context = MakeDbContext();
        //Act
        await Act(firstRole);
        
        //Assert
        var isExists = await context.Roles.AnyAsync(p => p.Id == firstRole.Id);
        isExists.Should().BeFalse();
    }
    
    private async Task AddInMemory(Domain.Role role) {
        await using UberEatContext context = MakeDbContext();
        await context.Roles.AddAsync(role);
        await context.SaveChangesAsync();
    }

    private async Task Act(Domain.Role role) => await _repository.DeleteAsync(role);
}