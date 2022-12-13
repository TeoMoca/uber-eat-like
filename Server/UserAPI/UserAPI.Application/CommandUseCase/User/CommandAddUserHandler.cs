using MediatR;
using UserAPI.Application.Interface;

namespace UserAPI.Application.CommandUseCase.User;

public record InputAddUserUseCase(Domain.User user) : IRequest<bool>{}
public class CommandAddUserHandler : IRequestHandler<InputAddUserUseCase, bool> {

    private readonly IUserRepository _userRepository;

    public CommandAddUserHandler(IUserRepository userRepository) {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(InputAddUserUseCase request, CancellationToken cancellationToken = default) {
        
        request.user.Id = Guid.NewGuid();
        await _userRepository.AddAsync(request.user);

        return true;
    }
}
