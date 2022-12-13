using Moq;
using UserAPI.Application.CommandUseCase.User;
using UserAPI.Application.Interface;

namespace UserAPI.Application.UnitTests.CommandUseCase.User;

public class CommandAddUserHandlerTests
{
    [Fact]
    public async Task Should_Create_User_When_Add_It()
    {
        //Arrange
        var user = new Domain.User();
        var repository = new Mock<IUserRepository>();
        repository.Setup(p => p.AddAsync(It.IsAny<Domain.User>())).Callback<Domain.User>(p => user = p);
        var input = new InputAddUserUseCase(user);
        var usecase = new CommandAddUserHandler(repository.Object);
        
        //Act
        await usecase.Handle(input);
        
        //Assert
        repository.Verify(p => p.AddAsync(It.IsAny<Domain.User>()), Times.Once);
    }
}