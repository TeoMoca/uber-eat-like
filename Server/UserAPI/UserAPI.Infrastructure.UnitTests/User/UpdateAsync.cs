using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using UserAPI.Infrastructure.Repository;

namespace UserAPI.Infrastructure.UnitTests.User;

public class UpdateAsync : InMemoryRepositoryTests
{
    private UserRepository _repository;

    public UpdateAsync()
    {
        _repository = new UserRepository(context: Context);
    }
    
    public static Guid IdUser = Guid.NewGuid();
    
    public Domain.User firstUser = new Domain.User()
    {
        Id = IdUser, Email = "test1@email", Name = "Test1", Password = "123"
    };
    
    public Domain.User secondUser = new Domain.User()
    {
        Id = IdUser, Email = "test2@email", Name = "Test2", Password = "456"
    };

    [Fact]
    public async Task Should_Update_User_When_User_Is_Updated()
    {
        //Arrange
        await AddInMemory(firstUser);
        await using UberEatContext context = MakeDbContext();
        
        //Act
        await Act(secondUser);
        
        //Assert
        var userUpdated = await context.Users.Where(p => p.Id == IdUser).FirstOrDefaultAsync();

        userUpdated.Should().BeEquivalentTo(secondUser);
    }
    
    private async Task AddInMemory(Domain.User user) {
        await using UberEatContext context = MakeDbContext();
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }

    private async Task Act(Domain.User user) => await _repository.UpdateAsync(user);
}