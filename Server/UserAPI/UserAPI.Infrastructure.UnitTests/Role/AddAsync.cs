using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using UserAPI.Infrastructure.Repository;

namespace UserAPI.Infrastructure.UnitTests.Role;

public class AddAsync : InMemoryRepositoryTests {
    private RoleRepository _repository;
    
    public AddAsync() {
        _repository = new RoleRepository(context: this.Context);
    }

    [Fact] public async Task Should_Add_Not_Existing_Role() {
        
        //Arrange
        var role = new Domain.Role()
        {
            Id = 1, Label = "test@email", IsDisabled = true
        };

        await Act(role);
        
        //Act
        await using UberEatContext context = MakeDbContext();
        bool isRoleExists = await context.Roles.AnyAsync(o => o.Id == role.Id);
        
        //Assert
        isRoleExists.Should().BeTrue();
    }

    private async Task Act(Domain.Role role) 
        => await _repository.AddAsync(role);
}