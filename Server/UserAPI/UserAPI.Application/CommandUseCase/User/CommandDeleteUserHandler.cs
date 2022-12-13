using MediatR;
using UserAPI.Application.Interface;

namespace UserAPI.Application.CommandUseCase.User;

public record InputDeleteUserUseCase(Domain.User user) : IRequest<bool>;

public class CommandDeleteUserHandler : IRequestHandler<InputDeleteUserUseCase, bool>
{
    private IUserRepository _userRepository;

    public CommandDeleteUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(InputDeleteUserUseCase request, CancellationToken cancellationToken = default)
    {
        await _userRepository.DeleteAsync(request.user);

        return true;
    }
}