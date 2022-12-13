using Bogus;
using FluentAssertions;
using Moq;
using UserAPI.Application.Interface;
using UserAPI.Application.QueryUseCase.User;

namespace UserAPI.Application.UnitTests.QueryUseCase.User;

public class QueryAllUsersHandlerTests
{
    [Fact]
    public async Task Should_Return_All_Users()
    {
        //Arrange
        var faker = new Faker();
        var users = new List<Domain.User>()
        {
            new Domain.User() { Id = Guid.NewGuid() }, new Domain.User() { Id = Guid.NewGuid() }
        };

        var repository = new Mock<IUserRepository>();
        repository.Setup(p => p.AllAsync()).ReturnsAsync(users);
        
        //Act
        var sut = new QueryAllUsersHandler(repository.Object);

        var result = await sut.Handle(new());
        
        //Assert
        result.Should().BeEquivalentTo(users);
    }
}