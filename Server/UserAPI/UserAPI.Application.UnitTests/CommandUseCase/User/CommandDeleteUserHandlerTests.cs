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
        var userId = Guid.NewGuid();
        var repository = new Mock<IUserRepository>();
        repository.Setup(p => p.DeleteAsync(It.IsAny<Guid>())).Callback<Guid>(p => userId = p);
        var input = new InputDeleteUserUseCase(userId);
        var usecase = new CommandDeleteUserHandler(repository.Object);
        
        //Act
        await usecase.Handle(input);
        
        //Assert
        repository.Verify(p => p.DeleteAsync(It.IsAny<Guid>()), Times.Once);
    }
}