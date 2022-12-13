using MediatR;
using UserAPI.Application.Interface;

namespace UserAPI.Application.CommandUseCase.User;

public record InputUpdateUserUseCase(Domain.User user) : IRequest<bool>{}
public class CommandUpdateUserHandler : IRequestHandler<InputUpdateUserUseCase, bool>
{
    private readonly IUserRepository _userRepository;

    public CommandUpdateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(InputUpdateUserUseCase request, CancellationToken cancellationToken = default)
    { 
        await _userRepository.UpdateAsync(request.user);
        return true;
    }
}