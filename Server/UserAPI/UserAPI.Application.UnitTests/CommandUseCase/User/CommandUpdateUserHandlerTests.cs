using Moq;
using UserAPI.Application.CommandUseCase.User;
using UserAPI.Application.Interface;

namespace UserAPI.Application.UnitTests.CommandUseCase.User;

public class CommandUpdateUserHandlerTests
{
    [Fact]
    public async Task Should_Update_User_When_Update_It()
    {
        //Arrange
        var user = new Domain.User();
        var repository = new Mock<IUserRepository>();
        repository.Setup(p => p.UpdateAsync(It.IsAny<Domain.User>())).Callback<Domain.User>(p => user = p);
        var input = new InputUpdateUserUseCase(user);
        var usecase = new CommandUpdateUserHandler(repository.Object);
        
        //Act
        await usecase.Handle(input); 
        
        //Assert
        repository.Verify(p => p.UpdateAsync(It.IsAny<Domain.User>()), Times.Once);
    }
}