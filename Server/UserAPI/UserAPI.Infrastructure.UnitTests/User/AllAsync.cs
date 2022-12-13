using FluentAssertions;
using UserAPI.Infrastructure.Repository;

namespace UserAPI.Infrastructure.UnitTests.User;

public class AllAsync : InMemoryRepositoryTests
{
    private UserRepository _repository;

    public AllAsync()
    {
        _repository = new UserRepository(context: this.Context);
    }
    
    public Domain.User firstUser = new Domain.User()
    {
        Id = Guid.NewGuid(), Email = "test1@email", Name = "Test1", Password = "123"
    };
    
    public Domain.User secondUser = new Domain.User()
    {
        Id = Guid.NewGuid(), Email = "test2@email", Name = "Test2", Password = "456"
    };
    
    public Domain.User thirdUser = new Domain.User()
    {
        Id = Guid.NewGuid(), Email = "test3@email", Name = "Test3", Password = "789"
    };

    [Fact]
    public async Task Should_Return_All_User()
    {
        //Arrange
        await AddInMemory(firstUser);
        await AddInMemory(secondUser);
        await AddInMemory(thirdUser);
        
        var expectedResult = 3;
        
        //Act
        var result = await Act();
        
        //Assert
        result.Should().HaveCount(expectedResult);
    }
    
    private async Task AddInMemory(Domain.User user) {
        await using UberEatContext context = MakeDbContext();
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }

    private async Task<List<Domain.User>> Act() => await _repository.AllAsync();
}