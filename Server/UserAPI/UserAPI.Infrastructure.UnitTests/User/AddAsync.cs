using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using UserAPI.Infrastructure.Repository;

namespace UserAPI.Infrastructure.UnitTests.User;

public class AddAsync : InMemoryRepositoryTests {
    private UserRepository _repository;
    
    public AddAsync() {
        _repository = new UserRepository(context: this.Context);
    }

    [Fact] public async Task Should_Add_Not_Existing_User() {
        
        //Arrange
        var user = new Domain.User()
        {
            Id = Guid.NewGuid(), Email = "test@email", Name = "test", Password = "123"
        };

        await Act(user);
        
        //Act
        await using UberEatContext context = MakeDbContext();
        bool isUserExists = await context.Users.AnyAsync(o => o.Id == user.Id);
        
        //Assert
        isUserExists.Should().BeTrue();
    }

    private async Task Act(Domain.User user) 
        => await _repository.AddAsync(user);
}