using Moq;
using UserAPI.Application.CommandUseCase.User;
using UserAPI.Application.Interface;

namespace UserAPI.Application.UnitTests.CommandUseCase.User;

public class CommandDeleteUserHandlerTests
{
    [Fact]
    public async Task Should_Delete_User_When_Delete_It()
    {
        //Arrange
        var user = new Domain.User();
        var repository = new Mock<IUserRepository>();
        repository.Setup(p => p.DeleteAsync(It.IsAny<Domain.User>())).Callback<Domain.User>(p => user = p);
        var input = new InputDeleteUserUseCase(user);
        var usecase = new CommandDeleteUserHandler(repository.Object);
        
        //Act
        await usecase.Handle(input);
        
        //Assert
        repository.Verify(p => p.DeleteAsync(It.IsAny<Domain.User>()), Times.Once);
    }
}