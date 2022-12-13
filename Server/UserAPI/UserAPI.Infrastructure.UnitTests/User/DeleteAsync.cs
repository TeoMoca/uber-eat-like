using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using UserAPI.Infrastructure.Repository;

namespace UserAPI.Infrastructure.UnitTests.User;

public class DeleteAsync : InMemoryRepositoryTests
{
    private UserRepository _repository;

    public DeleteAsync()
    {
        _repository = new UserRepository(context: this.Context);
    }
    
    public Domain.User firstUser = new Domain.User()
    {
        Id = Guid.NewGuid(), Email = "test1@email", Name = "Test1", Password = "123"
    };
    
    [Fact]
    public async Task Should_Delete_User_When_Match_User()
    {
        //Arrange
        await AddInMemory(firstUser);
        await using UberEatContext context = MakeDbContext();
        //Act
        await Act(firstUser);
        
        //Assert
        var isExists = await context.Users.AnyAsync(p => p.Id == firstUser.Id);
        isExists.Should().BeFalse();
    }
    
    private async Task AddInMemory(Domain.User user) {
        await using UberEatContext context = MakeDbContext();
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }

    private async Task Act(Domain.User user) => await _repository.DeleteAsync(user);
}